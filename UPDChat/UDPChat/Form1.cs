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

namespace UDPChat
{
    public partial class Form1 : Form
    {

        
        IPEndPoint remoteEndPoint;
        Thread threadRec;
        public Form1()
        {
            InitializeComponent();
          //  btnConnect_Click(null, null); // значения методов по дефолту для IP
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            remoteEndPoint = new IPEndPoint(IPAddress.Parse(tb_IP.Text), (int)nuPort.Value);
             threadRec = new Thread(new ThreadStart(ThreadReceive));
            threadRec.Start();
        }

        void ThreadReceive()
        {
            try
            {
                while (true)
                {
                    //прием сообщений через UDP
                    UdpClient udpClient = new UdpClient((int)nuPort.Value); //клиент, который принимает сообщения


                    //так как мы указали порт, мы можем не применять метод connect
                    IPEndPoint remEndPoint = new IPEndPoint(IPAddress.Any, (int)nuPort.Value);
                    byte[] response = udpClient.Receive(ref remoteEndPoint);

                    Invoke((MethodInvoker)delegate
                    {
                        //txtAllMess.Lines.Append(Encoding.Unicode.GetString(response));
                        txtAllMess.Text += remoteEndPoint.Address.ToString() +" "+ Encoding.Unicode.GetString(response) + "\r\n";
                        
                    });
                    udpClient.Close();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //клиент для отправки сообщений через UDP
            UdpClient udpClient = new UdpClient();
            byte[] buffer = Encoding.Unicode.GetBytes(txtMes.Text);
            udpClient.Send(buffer, buffer.Length, remoteEndPoint);
           //udpClient.Close();
            txtAllMess.Lines.Append("--"+txtMes.Text);
            txtMes.Text = "";



            ///

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadRec.Abort();
        }
    }
}
