using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursePaper;
using System.Data;

namespace CoursePaper
{
    class tests
    {
        static void Main()
        {
            string username = Console.ReadLine();
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (key.Key != ConsoleKey.Enter)
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
                else if(key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                    Console.Write("\b \b");
                }
             }
            Console.WriteLine();
            Console.WriteLine(password.ToString());
        }
    }
}
