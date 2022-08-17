using System.Net.Sockets;
using System.Text;

namespace Client
{
    class OurClient
    {
        // private TcpClient _client; // private чтобы не сбивать
        private TcpClient client; // _client - именов-е по нотации, правил-е. Перем-я, которая работает TCP.
        private StreamWriter sWriter; // для созд записи на сервере. StreamWriter - поток, который будем отправлять с клиента на сервер через перем-ю sReader.

        public OurClient() // class in class. public - чтобы был доступен в другом файле.
        {
            client = new TcpClient("127.0.0.1", 5555);
            sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8); // вытащить из нашего клиента поток.
        
            HandleCommunication(); // после создания, здесь держим соед-е
        }

        void HandleCommunication()
        {
            while (true) // бесконечный цикл
            {
                Console.Write("> "); // для красоты
                string? message = Console.ReadLine(); // ? - чтобы не ругалось
                sWriter.WriteLine(message);
                sWriter.Flush(); // значит, что надо отправить сообщ-е немедленно. Этой командой отправляем сооб-е немедленно.
            }
        }
    }
} 

