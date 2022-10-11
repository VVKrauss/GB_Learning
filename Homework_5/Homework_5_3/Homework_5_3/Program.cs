/*
 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
Например: badc являются перестановкой abcd.
  
Краусс
 */

using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework_5_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            Krauss.Utilities.Helper.PrintInfo(5, 3);

            // Основное тело программы

            Console.Write("Введите строку 1:");
            string str1 = Console.ReadLine();
            Console.Write("Введите строку 2:");
            string str2 = Console.ReadLine();

            // только если строки не равны
            if (str1 != str2)
            {
                if (Compared(str1, str2))
                    Console.WriteLine("строки явялются перестановкой друг друга");
                else
                    Console.WriteLine("строки НЕ явялются перестановкой друг друга");
            } else
                Console.WriteLine("строки одинаковы");


            Krauss.Utilities.Helper.EndProgramm();
        }

        private static bool Compared(string str1, string str2)
        {

            StringBuilder sb = new StringBuilder(str1);

            foreach (var c in str2) {
                int pos = sb.ToString().IndexOf(c);
                if (pos != -1)
                    sb.Remove(pos, 1);
            }

            if (sb.Length == 0)
                return true;  
            else
                return false; 

        }
    }
}
