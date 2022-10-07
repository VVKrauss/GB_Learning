/* 
 * б)**Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки

    Краусс
 
 */
using SuperLib;
using System;
using System.IO;

namespace HomeWork_4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 4, задача 1
            Krauss.Utilities.Helper.PrintInfo(4, 2);



            // Основное тело программы
            Console.WriteLine("\n\nА тперь через Библиотеку SuperLib");



            Console.Write("Введите количество значений нового массива (доступен весь диапазон int): ");
            int size1;
            TryParseInt(out size1);
            SuperLib.SuperArray superArray1 = new SuperLib.SuperArray(size1);
            Console.WriteLine(superArray1.ToString());

            Console.Write("\nВведите количество значений нового массива: ");
            int size, val, step;
            TryParseInt(out size);
            Console.Write("Введите первое значение элемента массива: ");
            TryParseInt(out val);
            Console.Write("Введите шаг: ");
            TryParseInt(out step);
            SuperArray superArray = new SuperArray(size, val, step);

            Console.Write("Массив создан. Вот какой замечательнй:");
            Console.WriteLine(superArray.ToString());



            Console.Write("\nВведите количество значений нового массива со случайными элементами типа int: ");
            int size2, minValue, maxValue;
            TryParseInt(out size2);
            Console.Write("Введите минимально возможное значение элемента массива: ");
            TryParseInt(out minValue);
            Console.Write("Введите максимально возможное значение элемента массива: ");
            TryParseInt(out maxValue);

            SuperArray superArray2 = new SuperArray(size2, minValue, maxValue, true);
            Console.WriteLine(superArray2.ToString());

            Console.WriteLine("\nПрекрасный массив получился. Сохраним его в файл: beautiful.txt");
            CreateArrayFile("beautiful.txt", superArray2);


            int[] newArray = { 150, 17, 0, -215, 124 };

            SuperLib.SuperArray superArray3 = new SuperLib.SuperArray(newArray);
            Console.WriteLine($"\n Массив созданнный при копировании из нового массива внутри программы: {superArray3.ToString()}");


            SuperLib.SuperArray superArray4 = new SuperLib.SuperArray("beautiful.txt");
            Console.WriteLine($"\nА этот массив мы скоприовали из нашего \"прекрасного\" файла \n{superArray4.ToString()}");

            int sum = superArray4.Sum();
            Console.WriteLine($"\nКстати, сумма значений всех элементов = {sum}");


            SuperLib.SuperArray superArray5 = new SuperLib.SuperArray(superArray4.Inverse());
            Console.WriteLine($"\nЭто мы инвертировали все элементы: {superArray5.ToString()}");


            int[] array = new int[superArray4.InnerArrayCount];
            array = superArray4.Multi(3);

            Console.WriteLine($"\nА это мы все его значения умножили на \"3\" {new SuperLib.SuperArray(array).ToString()}");
            Console.WriteLine($"\nЗаметьте, сам массив не изменился {superArray4.ToString()}");



            Console.WriteLine($"\nИ самое интересное - количество максимальных элементов = {superArray4.MaxCount()}," +
                $" (Мксимальный элемент: {superArray4.MaxElement})");


            Krauss.Utilities.Helper.EndProgramm();
            DeleteFile("beautiful.txt");
        }

        private static void DeleteFile(string v)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + v;

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        private static void CreateArrayFile(string v, SuperLib.SuperArray lines)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + v;



            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            else
            {
                StreamWriter streamWriter = new StreamWriter(fileName);

                for (int i = 0; i < lines.InnerArrayCount; i++)
                {
                    streamWriter.WriteLine(lines[i]);
                }

                streamWriter.Close();

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

