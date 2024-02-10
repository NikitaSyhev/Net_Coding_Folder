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

namespace NetGamesServer
{
    public partial class Form1 : Form
    {
        Socket socket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        int id = 0;
        public Form1()
        {
            InitializeComponent();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1024);
            socket.Bind(ep);
            socket.Listen(10);
            Thread thread = new Thread(ServerFunction);
            thread.IsBackground = true;
            thread.Start();
        }
        void ServerFunction()
        {
            Boolean flag = true;
            while (flag) 
            {
                Socket ns=socket.Accept();
                this.Invoke((MethodInvoker)delegate { textBox1.Text += ns.RemoteEndPoint; });
                ++id;
                ns.Send (Encoding.Unicode.GetBytes(id.ToString()));
                byte[] buffer = new byte[4096];
                ns.Receive(buffer);
                this.Invoke((MethodInvoker)delegate { textBox1.Text += Encoding.Unicode.GetString(buffer); });
            }
        }
    }
}
