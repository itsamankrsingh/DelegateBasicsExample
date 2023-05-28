namespace DelegateBasicsExample
{
    class Program
    {
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            Log log = new Log();
            LogDel LogTextToConsoleDel, LogTextToTextFileDel;
            LogTextToConsoleDel = new LogDel(log.LogTextToConsole);
            LogTextToTextFileDel = new LogDel(log.LogToTextFile);

            LogDel multiLogDel = LogTextToConsoleDel + LogTextToTextFileDel;

            Console.WriteLine("Please enter your name: ");
            var name = Console.ReadLine();
            //multiLogDel(name);
            LogText(multiLogDel, name);
            Console.ReadKey();
        }

        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }

        //static void LogTextToConsole(string text)
        //{
        //    Console.WriteLine($"{DateTime.Now}: {text}");
        //}

        //static void LogToTextFile(string text)
        //{
        //    using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        //    {
        //        sw.WriteLine($"{DateTime.Now}: {text}");
        //    }
        //}

    }

    class Log
    {
        public void LogTextToConsole(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogToTextFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}