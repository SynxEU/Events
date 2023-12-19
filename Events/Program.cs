using System;
using System.Threading;
using System.Threading.Tasks;

namespace Events
{

    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Black;

            Thread timer = new Thread(Timer);
            timer.Start();
            
            string message = "Tryk på en tast for at afslutte.";
            int bredde = Console.WindowWidth;
            int hoejde = Console.WindowHeight;
            int x = (bredde - message.Length) / 2;
            int y = hoejde / 2;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(message);
            Console.ReadKey();

            timer.Abort();
        }

        static void Timer()
        {
            while (true)
            {
                SkiftFarve();
                Thread.Sleep(5000);
            }
        }

        static void SkiftFarve()
        {
            string message = "Skærmens baggrundsfarve ændret. Tryk på en tast for at afslutte.";
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            int x = (width - message.Length) / 2;
            int y = height / 2;
            Random random = new Random();
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            Console.BackgroundColor = colors[random.Next(colors.Length)];

            if (Console.BackgroundColor == ConsoleColor.Black)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.WriteLine(message);
        }
    }

}
