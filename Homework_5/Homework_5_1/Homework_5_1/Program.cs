/*
 Создать программу, которая будет проверять корректность ввода логина.
Корректным логином будет строка от 2 до 10 символов, содержащая только
буквы латинского алфавита или цифры, при этом цифра не может быть первой.
 
Краусс 
 
 */


using System;
using System.Text.RegularExpressions;

namespace Homework_5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            Krauss.Utilities.Helper.PrintInfo(5, 1);


            // Основное тело программы

            Regex regexStartSymbol = new Regex("^[a-zA-Z]");
            Regex regexCorrectSymbols = new Regex("^[a-zA-Z0-9]+$");

            Console.WriteLine("Придумайте логин. Он должен быть от 2 до 10 символов длинной. Содержащать только буквы латинского алфавита " +
                "или цифры, при этом цифра не может быть первой");

            bool loginCorrect = false;
            while (!loginCorrect)
            {

                Console.Write("\nПишите логин тут: ");
                string login = Console.ReadLine();

                bool countOfSymboles = false;

                if ((10 > login.Length) && (login.Length > 1))
                    countOfSymboles = true;


                if ((regexStartSymbol.IsMatch(login)) && (countOfSymboles) && regexCorrectSymbols.IsMatch(login))
                {
                    loginCorrect = true;
                    Console.WriteLine($"Отличный логин");
                }
                else {

                    Console.Write($"Логин не подходит. ");

                    if (!regexStartSymbol.IsMatch(login))
                    {
                        Console.Write($"Он должен начинаться с английской буквы. ");
                    }
                    if (!countOfSymboles)
                    {
                        Console.Write($"Он должен состоять из не менее чем 2 символов или больше 10.");
                    }
                    if (!regexCorrectSymbols.IsMatch(login))
                    {
                        Console.Write($"Ипользуйте только английский алфовит и цифры\n");
                    }

                }

            }


            Krauss.Utilities.Helper.EndProgramm();

        }
    }
}
