namespace Server
{
    // как в старой версии .NET нужен класс
    class Program
    {
        static void Main(string[] args) // с этой ф-ции начало вып ПО
        {
            // здесь код для вып на сервере
            Console.WriteLine("Это наш сервер!");
            OurServer ourServer = new OurServer(); // пустые скобки, значит ничего отдавать не нужно.

        }
    }
}