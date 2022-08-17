using System.Net.Sockets;
using System.Net;
using System.Text;


namespace Server
{
    class OurServer
    {
        TcpListener server;

        public OurServer()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);
            server.Start();

            LoopClients(); // ловить клиентов, пост открыта ф-ция
        }

        void LoopClients()
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                Thread thread = new Thread(() => HandleClient(client)); // каждого клиента положить в отд поток
                thread.Start();
            }

        }

        void HandleClient(TcpClient client)
        {
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.UTF8);
            while (true)
            {
                string message = sReader.ReadLine(); // считать из потока от клиента строку
                Console.WriteLine($"Клиент написал - {message}");
            }

        }
    }
} 

