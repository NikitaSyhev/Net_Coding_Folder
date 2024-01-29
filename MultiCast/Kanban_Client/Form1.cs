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

namespace Kanban_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Инициализация и запуск потока слушателя
            listener = new Thread(new ThreadStart(Listen));
            listener.IsBackground = true;
            listener.Start();
        }

        Thread listener; // Поток для прослушивания мультикаст-трафика

        void Listen()
        {
            while (true)
            {
                // Создание нового UDP сокета
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // IP-адрес мультикаст-группы
                IPAddress dest = IPAddress.Parse("224.5.5.5");

                // Добавление сокета к мультикаст-группе
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(dest, IPAddress.Any));

                // Создание конечной точки (IP-адрес и порт)
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 1024);

                // Буфер для приема данных
                byte[] buffer = new byte[4096];

                // Привязка сокета к конечной точке
                socket.Bind(ep);

                // Получение данных через сокет
                socket.Receive(buffer);

                // Обновление UI в основном потоке
                this.Invoke((MethodInvoker)delegate
                {
                    textBox1.Text += "\r\n" + DateTime.Now + " " + Encoding.Unicode.GetString(buffer);
                });

                // Закрытие сокета
                socket.Close();
            }
        }
    }
}
