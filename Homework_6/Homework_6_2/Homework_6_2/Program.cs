/*
2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить
минимум. Использовать массив (или список) делегатов, в котором хранятся различные функции.
б) *Переделать функцию LoadResultsFromFile, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр
(с использованием модификатора out).
 
Краусс 
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Homework_6_2
{
    internal class Program
    {
        public delegate double DelegateFunction(double value1);
        //delegate double DelegateMathFunction(double[] valuesArray);

        public static double Func1(double x) => x * x - 50 * x + 10;

        public static double Func2(double x) => x * x - 10 * x + 3;

        public static double Func3(double x) => x * x * x;

        public static double MinimumFunc(double[] valueArray)
        {

            double min = double.MaxValue;

            for (int i = 0; i < valueArray.Length; i++)
            {

                if (valueArray[i] < min)
                    min = valueArray[i];
            }

            return min;
        }


        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            Krauss.Utilities.Helper.PrintInfo(6, 2);

            string dialog = @"ВЫберите функцию:
 (1) x^2 - 50 * x + 10 
 (2) x^2 - 10 * x + 3;
 (3) x^3";

            Console.WriteLine(dialog);
            Console.Write("Выберете значение 1,2,3: ");

            int userInput = int.Parse(Console.ReadLine());
            DelegateFunction delegateFunction = UserDeside(userInput);

            if (delegateFunction != null)
            {

                Console.Write("Давайте определим нижнюю границу:");
                double startValue = double.Parse(Console.ReadLine());

                Console.Write("Теперь верхнюю границу:");
                double endValue = double.Parse(Console.ReadLine());

                Console.Write("И теперь шаг функции:");
                double stepValue = double.Parse(Console.ReadLine());

                SaveFunctionToFile("data.bin", delegateFunction, startValue, endValue, stepValue);
                double min;
                double[] entyries = LoadResultsFromFile("data.bin", out min);

                Console.WriteLine("\nВозвращаемый минимум:" + min + "\n");

                Console.WriteLine("\nА теперь считаем значения из файла и выведем на экран:");
                foreach (var line in entyries)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Не такого варианта. Всего доброго");
            }


            Krauss.Utilities.Helper.EndProgramm();
        }


        public static void SaveFunctionToFile(string fileName, DelegateFunction dFunction, double startRangeA, double endRangeB, double step)
        {

            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            double x = startRangeA;

            while (x <= endRangeB)
            {
                streamWriter.WriteLine(dFunction(x));
                x += step;
            }

            streamWriter.Close();
            fileStream.Close();

        }


        public static double[] LoadResultsFromFile(string fileName, out double min)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fileName);

            List<double> fileEntyres = new List<double>();

            while (!sr.EndOfStream)
                fileEntyres.Add(double.Parse(sr.ReadLine()));


            fileStream.Close();

            double[] results = new double[fileEntyres.Count];

            int i = 0;
            foreach (var lines in fileEntyres)
            {
                results[i] = lines;
                i++;
            }
            min = MinimumFunc(results);

            return results;
        }


        private static DelegateFunction UserDeside(int userInput)
        {

            switch (userInput)
            {
                case 1:
                    return Func1;
                case 2:
                    return Func2;
                case 3:
                    return Func3;
                default:
                    return null;

            }
        }
    }
}
