namespace DelegateBasicsExample
{
    class Program
    {
        delegate void LogDel(string text);
        static void LogTextToConsole(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        static void Main(string[] args)
        {
            LogDel logDel = new LogDel(LogTextToConsole);
            Console.WriteLine("Please enter your name: ");
            var name = Console.ReadLine();
            logDel(name);
            Console.ReadKey();
        }
    }
}