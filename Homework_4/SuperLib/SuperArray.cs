using System;
using System.IO;

namespace SuperLib
{

    public class SuperArray
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
            get
            {
                return innerArray[index];
            }
            set
            {
                innerArray[index] = value;
            }
        }

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

        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < innerArrayCount; i++)
                {

                    sum += innerArray[i];

                }
                return sum;
            }
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
        public int[] ToIntArray() // сделаем из нашего СУПЕР обычный
        {
            int[] buffer = new int[innerArrayCount];

            foreach (int i in innerArray)
                buffer[i] = innerArray[i];

            return buffer;

        }


        public int MaxCount
        {
            get
            {
                // присваиваем наименьшее возможное значение
                int maxValue = int.MinValue;
                // выставляем счётчик максимальных чисел на 0
                int count = 0;

                // перебираем все элементы в массиве
                for (int i = 0; i < innerArrayCount; i++)
                {
                    // если находится значение больше
                    if (maxValue < innerArray[i])
                    {
                        // записываем в счётчик единицу, так как это первое на столько большое значение
                        count = 1;
                        // присваиваем новое значение переменной
                        maxValue = innerArray[i];
                        // записываем это значение в переменную класса
                        this.maxElement = maxValue;
                    }
                    else if (maxValue == innerArray[i]) // если элемент равен сохранённому значению
                    {
                        // увеличиваем счётчик на единицу
                        count++;
                        // и на всякий случай пересохраняем значение
                        this.maxElement = maxValue;
                    }
                    // если меньше - нам пофиг, так, что не обрабатываем такой вариант
                }
                // возвращаем значение
                return count;
            }
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
