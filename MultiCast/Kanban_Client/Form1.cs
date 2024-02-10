using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanban_client
{
    public partial class Form1 : Form
    {
        private Thread listener; // Поток для прослушивания мультикаст-трафика
        private IPAddress brodcastAddress = IPAddress.Parse("224.5.5.5");
        private UdpClient client = new UdpClient(4000);

        public Form1()
        {
            InitializeComponent();

            // Инициализация и запуск потока слушателя  
            listener = new Thread(new ThreadStart(Listen));
            listener.IsBackground = true;
            listener.Start();
        }

        private async void Listen()
        {
            try
            {
                while (true)
                {
                    client.JoinMulticastGroup(brodcastAddress);
                    UdpReceiveResult result = await client.ReceiveAsync();
                    string message = Encoding.Unicode.GetString(result.Buffer);
                    if (message == "END") break;
                    Console.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений, например, вывод в консоль или логирование
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                client.DropMulticastGroup(brodcastAddress);
            }
        }

        // Изменение IP адреса исходя из выбора клиента
        private void cb_News_CheckedChanged(object sender, EventArgs e)
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
                default:
                    brodcastAddress = IPAddress.Parse("224.5.5.8");
                    break;
            }

            // Переподключение к новой мультикаст-группе
            client.DropMulticastGroup(brodcastAddress);
            client.JoinMulticastGroup(brodcastAddress);
        }
    }
}
