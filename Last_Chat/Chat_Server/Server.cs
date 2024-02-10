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

namespace Chat
{
    public partial class Server : Form
    {
        public Socket s;
        public IPAddress ip;
        public IPEndPoint ep;
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token; 
        public Server()
        {
            InitializeComponent();
            token= cancelTokenSource.Token;
            Task task = new Task(CreateSocket, token);            
        }
        void CreateSocket()
        {
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            ip = IPAddress.Parse("127.0.0.1");
            ep = new IPEndPoint(ip, 1024);
            s.Bind(ep);
            s.Listen(10);
            try
            {
                while (true)
                {
                    Socket ns = s.Accept();
                    new Thread(() => ConnectWithPass(ns)).Start();
                }
            }
            catch { }
            finally
            {
                s.Shutdown(SocketShutdown.Both);
                s.Close();
            }
        }
        void ConnectWithPass(Socket ns)
        {
            byte[] buffer = new byte[1024];
            int q = ns.Receive(buffer);
            bool isOk = false;
            string[] s = Encoding.Unicode.GetString(buffer, 0, q).Split(';');
            if (s[0]=="0") //вход существующего пользователя
            {
                //обработка входа: подключение к БД, проверка логин/пароль
                //при удаче меняем значение флага isOk
            }    
            else
            {
                //обработка регистрации: запись в БД логина/пароля пользователя
                //при удаче меняем значение флага isOk
            }
            string answer;
            if (isOk) { answer = "ok"; }
            else { answer = "error"; }
            ns.Send(Encoding.Unicode.GetBytes(answer));
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            cancelTokenSource.Cancel();
        }
    }
}
