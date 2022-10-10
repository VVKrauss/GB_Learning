/**
 * 4. 1
 * 
 * Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от
 * начального значения с заданным шагом.  * Создать свойство Sum, которое возвращает сумму элементов 
 * массива, метод Inverse, возвращающий * новый массив с измененными знаками у всех элементов массива
 * (старый массив, остается без  * изменений), метод Multi, умножающий каждый элемент массива на
 * определённое число, свойство MaxCount,  * возвращающее количество максимальных элементов.
 * 
 * Краусс
 */

using System;
using System.IO;

namespace Homework_4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 4, задача 1
            Krauss.Utilities.Helper.PrintInfo(4, 1);


            // Основное тело программы

            Console.Write("Введите количество значений нового массива со случайными числами: ");
            int size1;
            TryParseInt(out size1);
            SuperArray superArray1 = new SuperArray(size1);
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



            Console.Write("\nВведите количество значений нового массива: ");
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

            SuperArray superArray3 = new SuperArray(newArray);
            Console.WriteLine($"\n Массив созданнный при копировании нового массива внутри программы: {superArray3.ToString()}");


            SuperArray superArray4 = new SuperArray("beautiful.txt");
            Console.WriteLine($"\nА этот массив мы скоприовали из нашего \"прекрасного\" файла \n{superArray4.ToString()}");

            int sum = superArray4.Sum();
            Console.WriteLine($"\nКстати, сумма значений всех элементов = {sum}");


            SuperArray superArray5 = new SuperArray(superArray4.Inverse());
            Console.WriteLine($"\nЭто мы инвертировали все элементы: {superArray5.ToString()}");


            int[] array = new int[superArray4.InnerArrayCount];
            array = superArray4.Multi(3);

            Console.WriteLine($"\nА это мы все его значения умножили на \"3\" {new SuperArray(array).ToString()}");
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

        private static void CreateArrayFile(string v, SuperArray lines)
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




    class SuperArray
    {

        private int[] innerArray;
        private int innerArrayCount;
        private int maxElement = 0;

        public int MaxElement { get { return maxElement; } }

        public int InnerArrayCount
        {
            get
            {
                return innerArrayCount;
            }
        }


        public int this[int index]
        {
            get { return innerArray[index]; }
            set { innerArray[index] = value; }
        }

        /// <param name="size">Размерность массива</param>
        public SuperArray(int size) //создаём массив со случайными int элементами 
        {
            innerArray = new int[size];
            Random random = new Random();
            ;
            for (int i = 0; i < size; i++)
            {
                innerArray[i] = random.Next(int.MinValue, int.MaxValue);
            }
            innerArrayCount = size;
        }

        public SuperArray(int size, int firstNum, int step) //создаём массив с заданными элементами 
        {
            innerArray = new int[size];
            int tempStep = 0;

            for (int i = 0; i < size; i++)
            {
                innerArray[i] = firstNum + tempStep;
                tempStep += step;
            }
            innerArrayCount = size;
        }



        public SuperArray(int size, int minValue, int maxValue, bool isRandom) //со значениями внутри заданных рамок
        {

            innerArray = new int[size];
            Random random = new Random();
            ;
            for (int i = 0; i < size; i++)
            {
                innerArray[i] = random.Next(minValue, maxValue);
            }
            innerArrayCount = size;

        }


        public SuperArray(int[] outerArray) // просто корируем
        {
            innerArray = outerArray;
            innerArrayCount = outerArray.Length;
        }


        public SuperArray(string fileName) // забираем массив из файла
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int lines = 0;
            int[] buffer = new int[1000];

            if (File.Exists(fileName))
            {
                StreamReader streamReader = new StreamReader(path + fileName);

                while (!streamReader.EndOfStream)
                {
                    buffer[lines] = int.Parse(streamReader.ReadLine());
                    lines++;
                }

                innerArray = new int[lines];

                for (int i = 0; i < lines; i++)
                    innerArray[i] = buffer[i];

                streamReader.Close();
                innerArrayCount = lines;
            }
            else
            {

                Console.WriteLine("файла массива с таким именем нет в папке Вашего проекта");

            }


        }

        public int[] Inverse()
        {
            int[] buffer = new int[innerArrayCount];

            for (int i = 0; i < innerArrayCount; i++)
            {
                buffer[i] = -innerArray[i];
            }

            return buffer;
        }

        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < innerArrayCount; i++)
            {

                sum += innerArray[i];

            }
            return sum;

        }

        public int[] Multi(int multiplayValue)
        {
            int[] buffer = new int[innerArrayCount];

            for (int i = 0; i < innerArrayCount; i++)
            {
                buffer[i] = innerArray[i] * multiplayValue;
            }

            return buffer;

        }
        public int[] ToIntArray() // сделаем из нашего СУПЕР обычный, су
        {
            int[] buffer = new int[innerArrayCount];

            foreach (int i in innerArray)
                buffer[i] = innerArray[i];

            return buffer;

        }

        public int MaxCount()
        {
            int maxValue = int.MinValue;
            int count = 0;

            for (int i = 0; i < innerArrayCount; i++)
            {

                if (maxValue < innerArray[i])
                {
                    count = 1;
                    maxValue = innerArray[i];
                    this.maxElement = maxValue;
                }
                else if (maxValue == innerArray[i])
                {
                    count++;
                    this.maxElement = maxValue;
                }

            }

            return count;
        }

        public override string ToString()
        {

            string str = "[";

            for (int i = 0; i < innerArrayCount; i++)
            {

                if (i == innerArrayCount - 1)
                    str += $"{innerArray[i]}]";
                else
                    str += $"{innerArray[i]}, ";
            }




            return str;

        }


    }

}
