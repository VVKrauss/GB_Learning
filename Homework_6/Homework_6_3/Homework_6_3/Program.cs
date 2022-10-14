/*
 3. **Считайте файл различными способами. Смотрите “Пример записи файла различными способами”.
Создайте методы, которые возвращают: 
массив byte (FileStream, BufferedStream), 
строку для StreamReader и
массив int для BinaryReader.

Краусс
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Homework_6_3
{
    internal class Program
    {
        public static byte[] BytesArray(string fileName)
        {

            byte[] bytes = new byte[1024];




            return null; //TODO - replace
        }

        //public static string[] StringArray(string fileName)
        //{
        //    FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        //    StreamReader streamReader = new StreamReader(fileStream);

        //    List<string> stringsCollection = new List<string>();

        //    while (!streamReader.EndOfStream) {
        //        stringsCollection.Add(streamReader.ReadLine());
        //    }

        //    string[] lines = new string[stringsCollection.Count];

        //    int i = 0;
        //    foreach (var line in stringsCollection)
        //    {
        //        lines[i] = line;
        //        i++;
        //    }

        //    streamReader.Close();
        //    fileStream.Close();

        //    return lines; 
        //}

        public static void BinaryArray(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);

            List<int> intCollection = new List<int>();

            int count = (int)fileStream.Length;
            Console.WriteLine($"байт {count}");

            for (int i = 0; i < count - 1; i++)
            {

                int intValue = (int) binaryReader.ReadByte();

                intCollection.Add(intValue);

                Console.WriteLine($"байт {intValue}");
            }


            //int[] lines = new int[count];


            //for (int i = 0; i < count; i++)
            //{
            //    lines[i] = (int) binaryReader.ReadSingle();

            //foreach (var line in lines) 
            //    Console.WriteLine($"байт {lines}");

            //}





            //   return lines;
        }

        static void Main(string[] args)
        {

            Krauss.Utilities.Helper.TextEncoding();

            Krauss.Utilities.Helper.PrintInfo(6, 3);

            string fileName1 = "pushkin.txt";
            string fileName2 = "dostoevskiy.txt";
            string fileName3 = "chislafibonachi.txt";


            byte[] bytes = BytesArray(fileName1);
            // string[] strings = StringArray(fileName2);
            //int[] ints = 
            BinaryArray(fileName3);


            //Console.WriteLine($"\nВыводим содержимое файла {fileName1}");
            //foreach (var byteElement in bytes)
            //    Console.WriteLine(byteElement);

            //Console.WriteLine($"\nВыводим содержимое файла {fileName2}");
            //foreach (var stringElement in strings)
            //    Console.WriteLine(stringElement);

            Console.WriteLine($"\nВыводим содержимое файла {fileName3}");
            foreach (var intElement in bytes)
                Console.WriteLine(intElement);


            Krauss.Utilities.Helper.EndProgramm();

        }
    }
}
