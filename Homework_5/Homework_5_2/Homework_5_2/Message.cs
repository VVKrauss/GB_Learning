/*
 2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него
передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из
слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.
 
Краусс 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_5_2
{
    public static class Message
    {
        private static string[] separators = { " ", ",", ".", "!", ":", "?", "-" };

        public static string[] Separators
        {
            get { return separators; }
        }

        // а) Вывести только те слова сообщения, которые содержат не более n букв.
        public static void PrintNletters(string str, int n)
        {

            string[] strArray = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Length < (n + 1))
                {

                    Console.WriteLine(strArray[i]);
                }
            }

        }


        // б) Удалить из сообщения все слова, которые заканчиваются на заданный символ
        public static string RemoveWordsWithEndSymbol(string str, char c)
        {
            string[] strArray = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < strArray.Length; i++)
            {
                if ((char)strArray[i][strArray[i].Length - 1] != c)
                {
                    stringBuilder.Append(strArray[i] + "\n");
                }
            }

            return stringBuilder.ToString();
        }

        // в) Найти самое длинное слово сообщения.
        public static string LongestWord(string str)
        {
            string[] strArray = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int wordLength = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Length > wordLength)
                {
                    sb.Clear();
                    sb.Append(strArray[i]);
                    wordLength = strArray[i].Length;
                }
            }

            return sb.ToString();
        }



        // так как о количестве самых длинных слов ничего не указано, выведем все слова, что длиннее средней длинны слов в строке
        public static StringBuilder StringWithLongestWords(string str)
        {
            string[] strArray = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            int wordMaxLength = 0;
            int wordMinLength = int.MaxValue;

            // ищем длинну самого длинного слова и самого короткого
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Length > wordMaxLength)
                {
                    wordMaxLength = strArray[i].Length;
                }

                if (strArray[i].Length < wordMinLength)
                {
                    wordMinLength = strArray[i].Length;
                }
            }

            // сораняем в sb только те, что длинее среднего арифметического длинн всех слов
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Length > ((wordMaxLength + wordMinLength) / 2))
                {
                    sb.Append(strArray[i] + " ");
                }
            }

            return sb;
        }

        public static void Analys(string[] words, string str)
        {
            string[] strArray = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // ключ - слово, значение - число повторений слова в строке
            var dictionary = new Dictionary<string, int>();

            // заполняем словарь значениями из массива слов
            foreach (var line in words)
                dictionary.Add(line, 0);


            // проверяем есть слова из словоря в строке
            for (int i = 0; i < strArray.Length; i++)
            {
                if (!dictionary.ContainsKey(strArray[i]))
                {

                    // если слов нет, то ничего не делаем или говорим, что слово не найдено
                    Console.WriteLine($"Слово {strArray[i]} в словаре отсутствует"); ;
                }
                else
                {
                    // если слово есть, то добавляем единиу в значение пары словваря
                    dictionary[strArray[i]]++;
                    // Console.WriteLine($"Слово {strArray[i]} есть в словаре");
                }
            }

            // выводим результаты
            foreach (var v in dictionary)
                Console.WriteLine($"Слово \"{v.Key}\" встречается в тексте {v.Value} раз");

        }


    }
}
