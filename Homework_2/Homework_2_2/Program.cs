/**
 * 2. Написать метод подсчета количества цифр числа.
 * 
 * Краусс
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 2, задача 2
            Krauss.Utilities.Helper.PrintInfo(2, 2);

            // Основное тело программы

            Console.Write("Введите число: ");
            int num = int.Parse(Console.ReadLine());

            int counter = 0;

            while (num > 0) {
                num = num / 10;
                counter++;
            }

            Console.WriteLine($"Всего {counter} цифр в числе\n");


            // Завершаем программу
            Krauss.Utilities.Helper.EndProgramm();
        }
    }
}
