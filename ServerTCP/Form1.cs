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
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Net.Http;

namespace ServerTCP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        TcpListener listener;
        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(ip, 1024);
            listener = new TcpListener(ep);
            listener.Start();
            Thread thread = new Thread(new ThreadStart(ThreadClient));
            thread.IsBackground = true;
            thread.Start();
            button1.Enabled = false;
        }
        public void ThreadClient()
        {
            try
            {
                while (true)
                {
                    TcpClient ns = listener.AcceptTcpClient();
                    Invoke((MethodInvoker)delegate
                    {
                        textBox1.Text += (ns.Client.RemoteEndPoint.ToString()) + "  =>";
                    }
                    );
                    NetworkStream stream = ns.GetStream();

                    StreamReader sr = new StreamReader(stream, Encoding.Unicode);
                    StreamWriter writer = new StreamWriter(stream);
                    var line = sr.ReadToEndAsync();
                    Invoke((MethodInvoker)delegate
                    {
                        textBox1.Text += line + "\r\n";
                    }
                    );

                    //byte[] buffer = Encoding.Unicode.GetBytes(textBox1.Text);                    
                    writer.WriteAsync(textBox1.Text);
                    writer.FlushAsync();
                    ns.Close();
                }
            }
            catch { }
        }


    }
}