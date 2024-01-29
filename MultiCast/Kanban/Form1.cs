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

namespace Kanban
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создание нового UDP сокета
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            // Установка опции времени жизни для мультикастинга
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 1);

            // IP-адрес мультикаст-группы
            IPAddress dest = IPAddress.Parse("224.5.5.5");

            // Добавление сокета к мультикаст-группе
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(dest));

            // Создание конечной точки (IP-адрес и порт)
            IPEndPoint ep = new IPEndPoint(dest, 1024);

            // Установка соединения с конечной точкой
            socket.Connect(ep);

            // Отправка данных через сокет
            socket.Send(Encoding.Unicode.GetBytes(textBox1.Text));

            // Закрытие сокета
            socket.Close();

            // Очистка текстового поля ввода
            textBox1.Text = string.Empty;
        }
    }
}

