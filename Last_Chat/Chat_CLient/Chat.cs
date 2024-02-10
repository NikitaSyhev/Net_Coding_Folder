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

namespace Chat
{
    public struct ConnProp
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Command { get; set; }
        public IPAddress IP { get; set; }
    }
    public partial class Chat : Form
    {
        Socket socket;
        public ConnProp ConnProp = new ConnProp();
        public Chat()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnProps fm= new ConnProps();
            //fm.ShowDialog();
            if (fm.ShowDialog() != DialogResult.Cancel)
            {
                ConnProp = fm.ConnProp;
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                IPEndPoint ep = new IPEndPoint(ConnProp.IP, 1024);
                socket.Connect(ep);
                socket.Send(Encoding.Unicode.GetBytes(ConnProp.Command+";"+ConnProp.Login+";"+ConnProp.Password+";"));
                byte[] buffer = new byte[1024];
                int q = socket.Receive(buffer);
                string s = Encoding.Unicode.GetString(buffer, 0, q);
                if (s== "error") 
                {
                    MessageBox.Show("Ошибка соединения!");
                    socket.Close();
                }
            }

        }
    }
}
