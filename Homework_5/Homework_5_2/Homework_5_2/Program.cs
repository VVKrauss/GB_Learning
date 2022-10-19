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

namespace Homework_5_2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            // ДЗ 4, задача 1
            Krauss.Utilities.Helper.PrintInfo(5, 2);

            // Основное тело программы


            string st = "А что подумал по этому поводу Кролик," +
                " никто так и не узнал, потому что Кролик был очень воспитанный.";
            int numOfSymbols = 5;

            Message.PrintNletters(st, numOfSymbols);
            Console.WriteLine(Message.RemoveWordsWithEndSymbol(st, 'й'));
            Console.WriteLine($"Самое длинное слово: {Message.LongestWord(st)}");
            Console.WriteLine(Message.StringWithLongestWords(st));


            string[] strA = ("привет пока звонка чмаке").Split(Message.Separators, StringSplitOptions.RemoveEmptyEntries);

            Message.Analys(strA, "привет привет, пока пока. Я очень буду ждать звонка звонка, звонка звонка");

            Krauss.Utilities.Helper.EndProgramm();
        }
    }
}
