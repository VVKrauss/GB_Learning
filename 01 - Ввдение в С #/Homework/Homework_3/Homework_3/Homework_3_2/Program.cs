using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 3, задача 1
            Krauss.Utilities.Helper.PrintInfo(3, 2);

            // Основное тело программы
            int i;

            Console.Write("введите любое целое число (0 - завершение):");

            bool f = false;
            List<int> ints = new List<int>();   


            while (!f) {
                TryParseInt(out i);

                if (i != 0)
                {

                    if ((i % 2 == 0) && (i > 0))
                    {
                        ints.Add(i);
                    }

                }
                else {

                    int sum = 0;
                    for (int j = 0; j < ints.Count; j++) {

                        Console.Write($"{ints[j]}, ");
                        sum += ints[j];

                    }

                    Console.Write($"Сумма введённых положительных чётных чисел = {sum}");
                }

            }

        }
        
        
        
        private static void TryParseInt(out int num)
        {

            bool f = false;
            int n1;
            num = 0;

            while (!f)
            {
                string s = Console.ReadLine();

                if (int.TryParse(s, out n1))
                {
                    f = true;
                    num = n1;
                }
                else
                {
                    Console.Write("Вы ввели не целое число. Повторите ввод:");
                }
            }

        }

    }

}
