/**
 * 1. Написать метод, возвращающий минимальное из трёх чисел.
 * 
 * Краусс
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 2, задача 1
            Krauss.Utilities.Helper.PrintInfo(2,1);


            // Основное тело программы
            Console.Write("Введите 3 числа через запятую: ");
            string[] num = Console.ReadLine().Split(',') ;

            int min = int.MaxValue;


            for (int i = 0; i < num.Length; i++)
               if (int.Parse(num[i]) < min)                
                    min = int.Parse(num[i]);


            Console.WriteLine($"Минимальное число: {min}\n");





            // Завершаем программу
            Krauss.Utilities.Helper.EndProgramm();
            }
    }
}
