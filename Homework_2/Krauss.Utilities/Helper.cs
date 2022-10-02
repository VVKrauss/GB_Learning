using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krauss.Utilities
{
    public class Helper
    {
        public static void TextEncoding() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
        }

        public static void PrintInfo(int h, int l)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"=========================================================");
            Console.WriteLine($"Домашнее Задание {h} || Задача {l} || Студент: Виталий Краусс");
            Console.WriteLine($"=========================================================\n\n");

            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void EndProgramm()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\nPress any key for exit...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
}
}
}
