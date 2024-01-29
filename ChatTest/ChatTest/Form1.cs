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

namespace ChatTest
{
    public partial class Form1 : Form
    {

        public Socket socket;
        public IPEndPoint ep;
        public Form1()
        {
            InitializeComponent();
        }

        public void MsgRecive(IAsyncResult ar) // метод для принятия сообщений
        {
            Socket ns = ar.AsyncState as Socket;   
            Socket rs = ns.EndAccept(ar);
            byte[] buffer = new byte[1024];
            int i = rs.Receive(buffer);
            Invoke((MethodInvoker)delegate
            {
                textBox1.Text += System.Text.Encoding.Unicode.GetString(buffer, 0, i);
            });
           
            rs.Shutdown(SocketShutdown.Both);
            rs.Close();
        }

        private void button1_Click(object sender, EventArgs e) //кнопка для устновки подключения
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  // создали endpoint 
            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), (int)PortText.Value));
            socket.Listen(10);
            socket.BeginAccept(new AsyncCallback (MsgRecive), socket);
            //В качестве параметра метода BeginAccept передается делегат AsyncCallback, который
            //указывает на метод MsgRecive. Этот метод будет вызван, когда произойдет входящее соединение.

            //В итоге, при нажатии кнопки, ваш серверный сокет начинает прослушивание входящих
            //соединений асинхронно, и по мере поступления соединений вызывается метод MsgRecive.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Socket ss = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ep = new IPEndPoint(IPAddress.Parse(IPText.Text), (int)PortText.Value); //создали сокет
            
            if (socket.Connected)socket.Connect(ep);
            socket.Send(System.Text.Encoding.Unicode.GetBytes(MsgText.Text));
            textBox1.Text = MsgText.Text;
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
