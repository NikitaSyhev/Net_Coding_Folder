using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocetTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip=IPAddress.Parse("127.0.0.1");
            IPEndPoint ep=new IPEndPoint(ip, 1024);
            Socket s=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            s.Bind(ep);
            s.Listen(10);

            try
            {
                while (true)
                {
                    //принимает сокет с клиента
                    Socket ns = s.Accept();
                    Console.WriteLine(ns.RemoteEndPoint.ToString());

                    byte[] buffer = new byte[1024];
                    int q = ns.Receive(buffer);
                    Console.WriteLine(System.Text.Encoding.Unicode.GetString(buffer, 0, q));
                    ns.Send(System.Text.Encoding.Unicode.GetBytes("Привет, клиент"));
                    ns.Shutdown(SocketShutdown.Both);
                    ns.Close();
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
