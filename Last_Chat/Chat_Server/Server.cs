using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace Chat
{
    public partial class Server : Form
    {
        //стандартно создали сокет, IP, конечную точку
        public Socket s;
        public IPAddress ip;
        public IPEndPoint ep;
        public static string login;
        public static string password;
        string connectionString = "Data Source=users.db3";
        private string show_all_users = $"SELECT NAME, PASSWORD FROM users;"; //строка запроса логина и пароля в таблице USERS
        //строка для добавления логина и пароля в базу данных
        private string add_login_pass = "INSERT INTO users (" +
            $"name, password) VALUES (" +
            $"'{login}', '{password}');";

       
        

        //токены нужны для закрытия потоков
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token; 
        public Server()
        {
            InitializeComponent();
            token= cancelTokenSource.Token; //инициализировали токен и таск для закрытия потока
            Task task = new Task(CreateSocket, token);            
        }

        //метод для создания сокета
        void CreateSocket()
        {
            //инициализировали сокет
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            //инициализиция АйПи адреса
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            //инициализация конечной точки
            ep = new IPEndPoint(ip, 1024);
            //связывает объект Socket с локальной конечной точкой
            s.Bind(ep);
            //начинем слущать
            s.Listen(10);
            try
            {
                //бесконечная прослушка
                while (true)
                {
                    Socket ns = s.Accept(); //создает новый объект Socket для обработки входящего подключения
                    new Thread(() => ConnectWithPass(ns)).Start();//для каждого подключения создаем свой поток, в него пробрасываем метод ConnectWithPass ( подключиться с паролем)
                    Console.WriteLine(ns.RemoteEndPoint.ToString());

                    byte[] buffer = new byte[1024];
                    int q = ns.Receive(buffer);
                    Console.WriteLine(System.Text.Encoding.Unicode.GetString(buffer, 0, q));
                    ns.Send(System.Text.Encoding.Unicode.GetBytes("TEST MESSAGE"));
                    ns.Shutdown(SocketShutdown.Both);
                    ns.Close();
                }
            }
            catch { }
            finally
            {
                //закрываем сокет 
                s.Shutdown(SocketShutdown.Both);
                s.Close();
            }
        }
       //метод для соединения с введенным паролем
        void ConnectWithPass(Socket ns)
        {
            //создали буфер для передачи данных
            byte[] buffer = new byte[1024];
            //количество байт
            int q = ns.Receive(buffer);
            bool isOk = false;//поставили флаг
            //получили сообщение
            string[] s = Encoding.Unicode.GetString(buffer, 0, q).Split(';');
            if (s[0]=="0") //вход существующего пользователя
            {

                //обработка входа: подключение к БД, проверка логин/пароль
                //при удаче меняем значение флага isOk

                //сохранили логин и пароль, полученный с сервера в строку
                login = s[1];
                password = s[2];
                //подключение БД
                
                try
                {
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        using (SQLiteCommand command = new SQLiteCommand(show_all_users, connection))
                        {
                            command.Parameters.Add(new SQLiteParameter("@name", DbType.String) { Value = login });
                            command.Parameters.Add(new SQLiteParameter("@pass", DbType.String) { Value = password });
                            //создали адаптер для подключения к БД

                            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                            {
                                DataTable table = new DataTable();
                                //в адаптер записали логин и пароль
                                adapter.Fill(table);

                                if (table.Rows.Count > 0)
                                {
                                    //здесь мы подключились меняем флаг на true, чтобы отправить ответ на клиент - ОК
                                 isOk = true;
                                }
                                else
                                {
                                    MessageBox.Show("У вас нет доступа");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }

            }    
            else
            {
                login = s[1];
                password = s[2];
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    //добавили логин и пароль в базу данных
                    SQLiteCommand command = new SQLiteCommand(); //объект класса КОмманд для команды Insert
                    command.Connection = connection;
                    command.CommandText = add_login_pass;//запрос к базе создали ВЫШЕ
                    command.ExecuteNonQuery(); //выполнили запрос
                }
                isOk = true;
                
                
                //обработка регистрации: запись в БД логина/пароля пользователя
                //при удаче меняем значение флага isOk
            }
            string answer;
            if (isOk) { answer = "ok"; }
            else { answer = "error"; }
            //отправляем сообщение
            ns.Send(Encoding.Unicode.GetBytes(answer));
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)//закрыли сервер
        {
            cancelTokenSource.Cancel();
        }
    }
}
