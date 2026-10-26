using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Server");
            var ip = IPAddress.Parse("127.0.0.1");
            var port = 27001;
            EndPoint ep = new IPEndPoint(ip, port);

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            try
            {
                while (true)
                {
                    Console.Write("Enter message: ");
                    var text = Console.ReadLine();
                    var bytes = Encoding.UTF8.GetBytes(text);
                    socket.SendTo(bytes, ep);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }





        }
    }
}
