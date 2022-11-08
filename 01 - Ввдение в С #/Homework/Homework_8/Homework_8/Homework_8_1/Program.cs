/*
 1. С помощью рефлексии выведите все свойства структуры DateTime.

Краусс
 */

using System;
using System.Reflection;

namespace Homework_8_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Krauss.Utilities.Helper.TextEncoding();
            Krauss.Utilities.Helper.PrintInfo(8, 1);

            Type type = typeof(DateTime);

            PropertyInfo[] propertyInfo = type.GetProperties();

            Console.WriteLine("Все свойства DateTime: ");

            // специально для даункаста оставил Object
            foreach (Object property in propertyInfo)
            {
                Console.WriteLine($"{((PropertyInfo)property).Name}");
            }

            Console.WriteLine("\nА теперь все методы: ");

            // просто потому, что могу
            foreach (var method in type.GetMethods())
            {
                Console.WriteLine($"{method.Name}");
            }


            Krauss.Utilities.Helper.EndProgramm();
        }
    }
}
