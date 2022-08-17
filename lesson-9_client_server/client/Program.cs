namespace Client
{
    // как в старой версии .NET нужен класс
    class Program
    {
        static void Main(string[] args) // с этой ф-ции начало вып ПО
        {
            // здесь код для вып на клиенте
            Console.WriteLine("Это наш клиент!");
            OurClient ourClient = new OurClient();
        }
    }
}