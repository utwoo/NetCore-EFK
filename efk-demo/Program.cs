using System;

namespace efk_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new FluentSender();
            Console.WriteLine("Please press message:");

            while (true)
            {
                var message = Console.ReadLine();
                if (message == "exit") break;

                sender.SendEvent(message);
            }
        }
    }
}