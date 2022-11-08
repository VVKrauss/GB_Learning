/*
 * 3. С клавиатуры вводятся числа, пока не будет введен 0.
 * Подсчитать сумму всех нечетных положительных чисел.
 * 
 * 
 * Краусс 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 2, задача 1
            Krauss.Utilities.Helper.PrintInfo(2, 3);


            // основное тело программы
            int num;
            int counter = 0;

            do {

                Console.Write("Введите число: ");
                num = int.Parse(Console.ReadLine());

                if (((num % 2) == 0) && (num != 0))
                    counter++;
                

            } while (num != 0);

            Console.WriteLine($"\nВсего чётных чисел: {counter}"); 


            // Завершаем программу
            Krauss.Utilities.Helper.EndProgramm();
        }
    }
}
