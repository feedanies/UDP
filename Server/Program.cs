using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
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
            socket.Bind(ep);

            while (true)
            {
                Console.WriteLine("Listening...");
                var bytes = new byte[socket.ReceiveBufferSize];
                var length = socket.ReceiveFrom(bytes, ref ep);

                var text = Encoding.UTF8.GetString(bytes, 0, length);
                Console.WriteLine("From client: " + text);
            }




        }
    }
}
