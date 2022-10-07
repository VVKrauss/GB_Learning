
/*
 2. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
Создайте структуру Account, содержащую Login и Password.

Краусс
 */


using System;
using System.IO;

namespace Homework_4_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 2, задача 1
            Krauss.Utilities.Helper.PrintInfo(4, 3);

            // основное тело программы


            //

            Console.WriteLine("Попробуем взломать пентагон. убдитесь, что файл с доступом находится в одной папке с этой программой");
            Console.Write("Введите имя файла: ");

            string fileName = Console.ReadLine();
            bool exist = false;

                        while (!exist)
            {

                if (File.Exists(fileName))
                { //обрабатываем файл

                    StreamReader sr = new StreamReader(fileName);

                    TryToLogin(sr);
                    exist = true;
                }
                else
                {
                    Console.Write($"файл не найден... Положите файл {fileName} в папке с этой программой и нажмите Ввод\n");
                    Console.ReadLine();

                }
            }




            // Завершаем программу
            Krauss.Utilities.Helper.EndProgramm();


        }

        private static void TryToLogin(StreamReader sr)
        {
            Console.Write($"\n файл найден\n");

            string[] keyFile = new string[2];

            for (int i = 0; i < keyFile.Length; i++) { 
                keyFile[i] = sr.ReadLine(); 
            }


            string l = keyFile[0];  
            string p = keyFile[1];

            if (!Account.IsLoggedIn(l, p))
            {
                Console.Write($"Данные в файле не верны. Проверьте содержимое файла и нажмите \"Ввод\":");
            }

            sr.Close();


        }
    }



    struct Account
    {

        private static string login = "root";
        private static string password = "GeekBrains";

        public static bool IsLoggedIn(string log, string pass)
        {

            if ((log == login) && (pass == password))
            {
                Console.WriteLine("Добро пожаловать в Пентагон.\n Секретные Материалы распологаются на втором подвальном этаже." +
                    "Приготовьте ведро. Там затоплено");
                return true;
            }
            else
            {
                return false;

            }

        }
    }
}
