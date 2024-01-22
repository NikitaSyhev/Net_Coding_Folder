using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClientTest
{
    internal class Program
    {
        static void Main(string[] args)



        {
            IPAddress ip=IPAddress.Parse("127.0.0.1"); //адрес
            IPEndPoint ep=new IPEndPoint(ip, 1024); // адрес + порт
            Socket s=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);//Этот
            //код на языке программирования C# создает новый объект Socket для установки сетевого соединения. 
            try
            {
                s.Connect(ep); // соединение с сервером
                if (s.Connected)
                {
                    s.Send(System.Text.Encoding.Unicode.GetBytes("Привет, сервер")); // отправка сообщения на сервер
                    byte[] buffer = new byte[1024]; //буффер для принятия данных с клиента ( массив байтов ) - передача идет байтами ( 
                    //соответственно сообщение кодируется в байты - передается - далее раскодируется
                    int q = s.Receive(buffer);// кохраняется количество прнятых байтов
                    Console.WriteLine(System.Text.Encoding.Unicode.GetString(buffer,0,q)); // осуществляется раскодировка данных из буффера
                }
            }
            catch { }
            finally 
            { 
                s.Shutdown(SocketShutdown.Both);
                s.Close(); 
            }
            Console.ReadLine();
        }
    }
}
