/*
 1. Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double).
Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
 
 Краусс
 */

using System;

namespace Homework_6_1
{
    internal class Program
    {

        delegate double MakeFunction(double value1, double value2);

        public static double AX2(double a, double x) => a * x * x;
        public static double ASinusX(double a, double x) => a * Math.Sin(x);


        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            Krauss.Utilities.Helper.PrintInfo(6, 1);

            MakeFunction makeFunctionAx2 = AX2;
            MakeFunction makeFunctionASinusX = ASinusX;

            Console.WriteLine(makeFunctionAx2(10, 2));
            Console.WriteLine(makeFunctionASinusX(3, 12));


            //Just for fun
            MakeFunction makeFunctionTwoFunctions;

            makeFunctionTwoFunctions = AX2;
            makeFunctionTwoFunctions += ASinusX;
            Console.WriteLine("\n" + makeFunctionTwoFunctions(10, 2));


            Krauss.Utilities.Helper.EndProgramm();

        }
    }
}
