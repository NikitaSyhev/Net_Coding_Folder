using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanban
{
    public partial class Form1 : Form
    {
        private IPAddress brodcastAddress = IPAddress.Parse("224.5.5.8");
        private UdpClient server = new UdpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Создание конечной точки (IP-адрес и порт)
                IPEndPoint ep = new IPEndPoint(brodcastAddress, 4000);

                // Отправка данных через сокет
                byte[] data = Encoding.Unicode.GetBytes(textBox1.Text);
                await server.SendAsync(data, data.Length, ep);

                // Очистка текстового поля ввода
                textBox1.Text = string.Empty;
            }
            catch (Exception ex)
            {
                // Обработка исключений, например, вывод в консоль или логирование
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Изменение IP адреса исходя из выбора сервера
        private void cb_News_Server_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            switch (checkBox.Text)
            {
                case "News":
                    brodcastAddress = IPAddress.Parse("224.5.5.5");
                    break;
                case "Business":
                    brodcastAddress = IPAddress.Parse("224.5.5.6");
                    break;
                case "Teammates":
                    brodcastAddress = IPAddress.Parse("224.5.5.7");
                    break;
                case "Alarm":
                    brodcastAddress = IPAddress.Parse("224.5.5.8");
                    break;
            }

            // Закрытие текущего соединения и установка нового
            server.Close();
            server = new UdpClient();
            server.Connect(new IPEndPoint(brodcastAddress, 4000));
        }
    }
}
