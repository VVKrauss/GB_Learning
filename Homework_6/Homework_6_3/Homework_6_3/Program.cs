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

            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BufferedStream bufferedStream = new BufferedStream(fileStream);

            byte[] bytes = new byte[bufferedStream.Length];

            bufferedStream.Read(bytes, 0, bytes.Length);
            bufferedStream.Close();
            fileStream.Close();

            return bytes; 
        }

        public static string[] StringArray(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);

            List<string> stringsCollection = new List<string>();

            while (!streamReader.EndOfStream)
            {
                stringsCollection.Add(streamReader.ReadLine());
            }

            string[] lines = new string[stringsCollection.Count];

            int i = 0;
            foreach (var line in stringsCollection)
            {
                lines[i] = line;
                i++;
            }

            streamReader.Close();
            fileStream.Close();

            return lines;
        }

        public static int[] BinaryArray(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);

            List<char> charCollection = new List<char>();

            int count = (int)fileStream.Length;

            for (int i = 0; i < count; i++)
            {
                char byteValue = binaryReader.ReadChar();
                charCollection.Add(byteValue);
            }

            binaryReader.Close();
            fileStream.Close();

            int[] result = new int[charCollection.Count];

            int counter = 0;
            foreach (char elemant in charCollection)
            {
                result[counter] = int.Parse(elemant.ToString());
                counter++;  
            }

            return result;
        }

        static void Main(string[] args)
        {

            Krauss.Utilities.Helper.TextEncoding();

            Krauss.Utilities.Helper.PrintInfo(6, 3);

            string fileName1 = "drizer.txt";
            string fileName2 = "dostoevskiy.txt";
            string fileName3 = "chisla.txt";

            byte[] bytes = BytesArray(fileName1);
            string[] strings = StringArray(fileName2);

            int[] intArray = BinaryArray(fileName3);


            Console.WriteLine($"\nВыводим содержимое файла {fileName1} \n");
            foreach (var byteElement in bytes)
                Console.Write(((char)byteElement).ToString());

            Console.WriteLine($"\nВыводим содержимое файла {fileName2} \n");
            foreach (var stringElement in strings)
                Console.WriteLine(stringElement);

            Console.WriteLine($"\nВыводим содержимое файла {fileName3} \n");
            foreach (var intElement in intArray)
                Console.Write(intElement+"\t");

            Krauss.Utilities.Helper.EndProgramm();

        }
    }
}
