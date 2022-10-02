/*  
 * 4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль.
 * На выходе истина, если прошел авторизацию, и ложь, если не прошел 
 * (Логин: root, Password: GeekBrains). Используя метод проверки логина и пароля, 
 * написать программу: пользователь вводит логин и пароль, программа пропускает его
 * дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.
 * 
 *  * Краусс
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 2, задача 1
            Krauss.Utilities.Helper.PrintInfo(2, 4);

            // основное тело программы
            var login = "root";
            var password = "GeekBrains";

            int attempts = 3;

            do
            {
                Console.Write("Введите логин: ");
                string l = Console.ReadLine();

                Console.Write("Введите пароль: ");
                string p = Console.ReadLine();

                if ((l == login) && (p == password))
                {
                    attempts = 0;
                    Console.WriteLine($"\nДобро пожаловать\n");
                }
                else {
                    attempts--;
                    Console.WriteLine($"\nЛогин иили пароль не верны\n" +
                        $"Осталось попыток > {attempts} \n");
                }
            } while (attempts > 0);





            // Завершаем программу
            Krauss.Utilities.Helper.EndProgramm();

        }
    }
}
