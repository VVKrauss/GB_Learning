/*
 * 6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
 * «Хорошим» называется число, которое делится на сумму своих цифр. Реализовать подсчёт времени
 * выполнения программы, используя структуру DateTime. Достаточно решить 4 задачи. Разбивайте
 * программы на подпрограммы. Переписывайте в начало программы условие и свою фамилию. Все
 * программы делайте в одном решении.
 * 
 * Краусс
 *
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 2, задача 1
            Krauss.Utilities.Helper.PrintInfo(2, 6);

            // основное тело программы
            var counter = 0;
            var dt1 = DateTime.Now;

            for (int i = 1; i < 1_000_000; i++)
                if (isbeautiful(i))
                    counter++;

            var dt2 = DateTime.Now - dt1;

            Console.WriteLine($"Количество \"Хороших\" чисел в диапозоне от 0 до 1 000 000: {counter + 1} (включая 0)\n");
            Console.WriteLine($"числа подсчитаны за {dt2}");


            // Завершаем программу
            Krauss.Utilities.Helper.EndProgramm();

        }

        private static bool isbeautiful(int num)
        {
            int tNum = num;
            int c = num.ToString().Length;

            int temp = 0;
            for (int i = 0; i < c; i++) { 
                
                temp = temp + num % 10;
                num = num / 10;
            
            }

            if (tNum % temp == 0)
                return true;
            else 
                return false;

        }
    }
}
