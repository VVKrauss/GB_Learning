using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3_1
{
    internal partial class Program
    {

        static void Main(string[] args)
        {

            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 3, задача 1
            Krauss.Utilities.Helper.PrintInfo(3, 1);

            // Основное тело программы

            Complex complex1, complex2, complex3, complex4;

            complex1 = new Complex(1, 2);
            complex2 = new Complex(3, 4);

            complex3 = Complex.Plus(complex1, complex2);
            complex4 = Complex.Minus(complex1, complex2);

            Console.WriteLine($"Результат cложения комплексных чисел {complex1} и {complex2} = {complex3}");
            Console.WriteLine($"Результат вычитания комплексных чисел {complex1} и {complex2} = {complex4}");



            // ДЗ 3, задача 2
            Krauss.Utilities.Helper.PrintInfo(3, 2);

            ComplexClass complexClass1, complexClass2, complexClass3, complexClass4, complexClass5;

            complexClass1 = new ComplexClass(12, 21);
            complexClass2 = new ComplexClass(4, 2);

            complexClass3 = ComplexClass.Plus(complexClass1, complexClass2);
            complexClass4 = ComplexClass.Minus(complexClass1, complexClass2);
            complexClass5 = ComplexClass.Multy(complexClass1, complexClass2);

            Console.WriteLine($"Результат cложения комплексных чисел в классе {complexClass1} и {complexClass2} = {complexClass3}");
            Console.WriteLine($"Результат вычитания комплексных чисел в классе {complexClass1} и {complexClass2} = {complexClass4}");
            Console.WriteLine($"Результат умножения комплексных чисел в классе {complexClass1} и {complexClass2} = {complexClass5}");



            // ДЗ 3, задача 3
            Krauss.Utilities.Helper.PrintInfo(3, 3);

            int re, im;

            Console.Write("введите вещественную часть комплексного числа 1:");
            TryParseInt(out re);
            Console.Write("введите мнимую часть комплексного числа 1:");
            TryParseInt(out im);

            ComplexClass complexC1 = new ComplexClass(re, im);


            int re2, im2;

            Console.Write("введите вещественную часть комплексного числа 2:");
            TryParseInt(out re2);
            Console.Write("введите мнимую часть комплексного числа 2:");
            TryParseInt(out im2);

            ComplexClass complexC2 = new ComplexClass(re2, im2);


            ComplexMathOperation(complexC1, complexC2);



            Console.ReadLine();
        }

        private static void ComplexMathOperation(ComplexClass complexC1, ComplexClass complexC2)
        {

            Console.WriteLine("Какую операцию проведём?");
            Console.WriteLine("Сложение     Введите (1)");
            Console.WriteLine("Вычитание    Введите (2)");
            Console.WriteLine("Умножение    Введите (3)");

            int operation;

            TryParseInt(out operation);
            bool f = false;


            while (!f)
            {
                if ((operation == 1) || (operation == 2) || (operation == 3))
                {
                    f = true;
                    switch (operation)
                    {

                        case 1:
                            Console.WriteLine($"\nРезультат cложения комплексных чисел в классе {complexC1} и {complexC2} = {ComplexClass.Plus(complexC1, complexC2)}");
                            break;

                        case 2:
                            Console.WriteLine($"\nРезультат вычитания комплексных чисел в классе {complexC1} и {complexC2} = {ComplexClass.Minus(complexC1, complexC2)}");
                            break;

                        case 3:
                            Console.WriteLine($"\nРезультат умножения комплексных чисел в классе {complexC1} и {complexC2} = {ComplexClass.Multy(complexC1, complexC2)}");
                            break;


                    }
                }
                else
                {
                    TryParseInt(out operation);
                    Console.Write("\nПожалуйста внимательнее! Выберете 1, 2 или 3:");
                }
            }

        }

        private static void TryParseInt(out int num)
        {
            
            bool f = false;
            int n1;
            num = 0;


            while  (!f) {
                string s = Console.ReadLine();

                if (int.TryParse(s, out n1))
                {
                    f = true;
                    num = n1;
                }
                else {
                    Console.Write("Вы ввели не целое число. Повторите ввод:");
                }
            }
            

        }

    }
}
