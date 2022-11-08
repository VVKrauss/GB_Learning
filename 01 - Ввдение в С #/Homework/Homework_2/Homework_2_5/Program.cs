/*
 *5.
    а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы
    и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
    б) Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса. 
   

    16 и менее	Выраженный дефицит массы тела
    16-18,5	Недостаточная (дефицит) масса тела
    18,5-25	Норма
    25-30	Избыточная масса тела (предожирение)
    30-35	Ожирение первой степени
    35-40	Ожирение второй степени
    40 и более	Ожирение третьей степени (морбидное)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 2, задача 1
            Krauss.Utilities.Helper.PrintInfo(2, 5);

            // основное тело программы (а)

            Console.Write("Введите Ваш рост (м): ");
            var height = float.Parse(Console.ReadLine());

            Console.Write("Введите Ваш вес (кг): ");
            var weight = float.Parse(Console.ReadLine());

            float IMT = weight / (height * height);

            Console.WriteLine($"Ваш Индекс Массы Тела {IMT:f2}");

            // (б)
            ChangeWeigth(height, weight);

            // Завершаем программу
            Krauss.Utilities.Helper.EndProgramm();
        }

        private static void ChangeWeigth(float heigth, float weight)
        {

            float iMT = weight / (heigth * heigth);

            float cv = Math.Abs(weight - 21 * (heigth * heigth));

            if (iMT < 16)
            {
                Console.WriteLine($"\nВыраженный дефицит массы тела \nВам нужно набрать {cv:f2} кг");
            }
            else if ((iMT >= 16) && (iMT < 18.5))
            {
                Console.WriteLine($"\nНедостаточная (дефицит) масса тела \nВам нужно набрать {cv:f2} кг");
            }
            else if ((iMT >= 18.5) && (iMT < 25))
            {
                Console.WriteLine("\nУ Вас идеальный вес!");
            }
            else if ((iMT >= 25) && (iMT < 30))
            {
                Console.WriteLine($"\nИзбыточная масса тела (предожирение) \nВам нужно сбросить {cv:f2} кг");
            }
            else if ((iMT >= 30) && (iMT < 35))
            {
                Console.WriteLine($"\nОжирение первой степени\nВам нужно сбросить {cv:f2} кг");
            }
            else if ((iMT >= 35) && (iMT < 40))
            {
                Console.WriteLine($"\nОжирение второй степени \nВам нужно сбросить {cv:f2} кг");
            }
            else {
                Console.WriteLine($"\nОжирение третьей степени (морбидное) \nВам нужно сбросить: {cv:f2} кг");
            }

            Console.WriteLine();


        }
    }
}
