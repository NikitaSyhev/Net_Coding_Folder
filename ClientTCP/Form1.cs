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
using System.IO;

namespace ClientTCP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(maskedTextBox1.Text), (Int32)numericUpDown1.Value);
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(ep);
            NetworkStream stream = tcpClient.GetStream();
            byte[] buffer = Encoding.Unicode.GetBytes(textBox1.Text);
            stream.Write(buffer, 0, buffer.Length);
            StreamReader sr = new StreamReader(stream, Encoding.Unicode);
            var line = sr.ReadToEndAsync();
            allMes.Text += line;
            tcpClient.Close();
            textBox1.Clear();
        }
    }
}