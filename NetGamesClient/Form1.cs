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

namespace NetGamesClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Socket socket;
        IPEndPoint ep;

        private void button1_Click(object sender, EventArgs e)
        {
            socket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ep = new IPEndPoint(IPAddress.Parse(address.Text), 1024);
            byte[] buffer = new byte[4096];
            socket.Connect(ep);
            if (socket.Connected) 
            {                 
                socket.Receive(buffer);
                gamer.Text= Encoding.Unicode.GetString(buffer);
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = groupBox1.Controls.OfType<RadioButton>().Where(x => x.Checked);
            socket.Send(Encoding.Unicode.GetBytes((result as RadioButton).Tag.ToString()));
        }
    }
    


}
