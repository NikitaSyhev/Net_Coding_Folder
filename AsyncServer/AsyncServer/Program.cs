using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;ФВ

namespace AsyncServer
{
    internal class Program
    {
        IPEndPoint endP;

        public void SendCallBack(IAsyncResult ar)//В вашем методе SendCallBack происходит завершение асинхронной операции отправки данных
        {
            Socket ns = ar.AsyncState as Socket;//- Вы извлекаете сокет (Socket), представляющий соединение, из объекта состояния
                                                //асинхронной операции (ar.AsyncState).
            int n = ns.EndSend(ar);//авершение асинхронной операции отправки данных и получение количества успешно отправленных байтов
            ns.Shutdown(SocketShutdown.Send);// Вы закрываете отправку для данного сокета
            ns.Close(); //закрытие сокета
        }

        public void SocketCallback(IAsyncResult ar) //извлекаем объект Socket из объекта IAsyncResult
        {
            Socket socket = ar.AsyncState as Socket;
            Socket ns = socket.EndAccept(ar);
            Console.WriteLine(ns.RemoteEndPoint.ToString());
            byte[] buffer = System.Text.Encoding.Unicode.GetBytes(DateTime.Now.ToString());
            ns.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(SendCallBack), ns);
            //асинхронная отправка данных из буфера (buffer) на соединенный сокет (ns).
            socket.BeginAccept(new AsyncCallback(SocketCallback), socket);
        }


        public void Main(string[] args)
        {
            endP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1024);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            socket.Bind(endP);
            socket.Listen(10);
            socket.BeginAccept(new AsyncCallback(SocketCallback), socket); //синхронный метод, используемый для начала ожидания
                                                                           //асинхронного запроса на принятие входящего соединения.
                                                                           //Вот более подробное объяснение:
                                                                           // это делегат AsyncCallback, который указывает метод
                                                                           // обратного вызова, который будет вызываться, когда
                                                                           // операция завершится. В данном случае, SocketCallback
                                                                           // - это метод, который будет обрабатывать результат асинхронной операции.

        }
    }
}
