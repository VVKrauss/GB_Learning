using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 3, задача 1
            Krauss.Utilities.Helper.PrintInfo(3, 3);



            Console.WriteLine("Введите числитель 1 (отличный от 0):");
            int chis;
            TryParseNonZeroInt(out chis);

            Console.WriteLine("Введите знаменатель 1 (отличный от 0):");
            int znam;
            TryParseNonZeroInt(out znam);


            Drob drob = new Drob(chis, znam);

            // вариант 1 нахождения НОД
            Console.WriteLine($"Наибольший общий делитель дроби (решение 1): {Drob.Nod(drob)}");

            // вариант 2 нахождения НОД 
            Console.WriteLine($"Наибольший общий делитель дроби (решение 2): {Drob.Nod(chis, znam)}");



            Console.WriteLine("Введите числитель 2 (отличный от 0): ");
            int chis2;
            TryParseNonZeroInt(out chis2);

            Console.WriteLine("Введите знаменатель 2 (отличный от 0): ");
            int znam2;
            TryParseNonZeroInt(out znam2);

            Drob drob2 = new Drob(chis2, znam2);


            // вариант 2 нахождения НОД
            Console.WriteLine($"Наибольший общий делитель дроби (решение 3): {drob2.Nod()}");




            Console.WriteLine($"\n\nработаем с дробями: {drob.ToString()} И {drob2.ToString()}");

            Console.WriteLine($"Сумма дробей {Drob.Sum(drob, drob2).ToString()}");
            Console.WriteLine($"Разница дробей {Drob.Minus(drob, drob2).ToString()}");
            Console.WriteLine($"Произведение дробей {Drob.Multy(drob, drob2).ToString()}");
            Console.WriteLine($"Деление дробей {Drob.Divide(drob, drob2).ToString()}\n\n");

            Console.WriteLine($"Сумма дробей в виде вещественного числа: {Drob.ToFloatString(Drob.Sum(drob, drob2))}");
            Console.WriteLine($"Разница дробей в виде вещественного числа: {Drob.ToFloatString(Drob.Minus(drob, drob2))}");
            Console.WriteLine($"Произведение дробей в виде вещественного числа: {Drob.ToFloatString(Drob.Multy(drob, drob2))}");
            Console.WriteLine($"Деление дробей в виде вещественного числа: {Drob.ToFloatString(Drob.Divide(drob, drob2))}");


            Console.ReadLine();



        }


        private static void TryParseNonZeroInt(out int num)
        {

            bool f = false;
            int n1;
            num = 0;

            while (!f)
            {
                string s = Console.ReadLine();

                if (int.TryParse(s, out n1))
                {

                    if (n1 != 0)
                    {
                        f = true;
                        num = n1;
                    }
                    else {
                        Console.Write("Введите число отличное от 0: ");
                    }
                }
                else
                {
                    Console.Write("Вы ввели не целое число. Повторите ввод:");
                }
            }

        }
    }
}
