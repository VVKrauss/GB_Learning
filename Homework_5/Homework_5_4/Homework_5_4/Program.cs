/*
 4. *Задача ЕГЭ.
На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100,
каждая из следующих N строк имеет следующий формат:
<Фамилия> <Имя> <оценки>,
где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
Пример входной строки:
Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии
и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот
же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.

 Краусс
 
 */

using System;

namespace Homework_5_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировки
            Krauss.Utilities.Helper.TextEncoding();

            Krauss.Utilities.Helper.PrintInfo(5, 4);

            Console.Write("Введите количество учеников: ");
            int countOfStudents;
            int.TryParse(Console.ReadLine(), out countOfStudents);




            // решение 1
            Console.Write("========= Решение 1 =========\n\n");
            string[] s = studentsStringArray(countOfStudents);

            DateTime dtPractice1 = new DateTime();
            dtPractice1 = DateTime.Now;

            BadStudents1(s);

            Console.WriteLine($"Время выполнения задачи решением 1: [{DateTime.Now - dtPractice1}]");



            // решение 2
            // при помощи структуры
            Console.Write("========= Решение 2 =========\n\n");
            Student[] students = CreateStudentsArray(countOfStudents);

            DateTime dtPractice2 = new DateTime();
            dtPractice2 = DateTime.Now;

            Array.Sort(students);
            BadStudents2(students);

            Console.WriteLine($"Время выполнения задачи решением 2: [{DateTime.Now - dtPractice2}]");


            Krauss.Utilities.Helper.EndProgramm();
        }

        private static void BadStudents1(string[] strings)
        {
            bool sorted = false;


            while (!sorted)
            {   sorted = true;
                for (int i = 0; i < strings.Length - 1; i++)
                {
                    
                    if (GetAverage(strings[i]) > GetAverage(strings[i + 1]))
                    {
                        (strings[i], strings[i + 1]) = (strings[i + 1], strings[i]);
                        sorted = false;

                    };

                }
            }


            bool done = false;
            int i1 = 0;

            Console.WriteLine($"\nХудшие ученики:");
            while (!done)
            {

                if (i1 < 3)
                {

                    Console.WriteLine(Fio(strings[i1]));
                    i1++;
                }
                else
                {

                    if (GetAverage(strings[i1]) == GetAverage(strings[i1 - 1]))
                    {
                        Console.WriteLine(Fio(strings[i1]));
                        i1++;
                    }
                    else
                        done = true;
                }

            }



        }

        private static string Fio(string v)
        {
            string[] lines = v.Split(' ');

            return lines[0] +" "+ lines[1];
        }

        private static decimal GetAverage(string stdentIncome)
        {
            string[] strings = stdentIncome.Split(' ');

            return Math.Round(((decimal.Parse(strings[2]) + decimal.Parse(strings[3]) + decimal.Parse(strings[4])) / 3), 2);
        }


        //=================================================================
        private static string[] studentsStringArray(int countOfStudents)
        {
            string[] line = new string[countOfStudents];
            for (int i = 0; i < countOfStudents; i++)
            {

                Console.Write($"Ученик {i + 1}:");
                line[i] = Console.ReadLine();
            }

            return line;

        }

        private static void BadStudents2(Student[] students)
        {

            decimal temp = 0;
            Console.WriteLine($"\nХудшие ученики:");

            for (int i = 0; i < students.Length; i++)
            {

                if (i < 3)
                {
                    Console.WriteLine($"{students[i].ToString()}");
                    temp = students[i].Average;
                }
                else
                {
                    if (students[i].Average == temp)
                    {
                        Console.WriteLine($"{students[i].ToString()}");
                    }
                }
            }

        }

        private static Student[] CreateStudentsArray(int countOfStudents)
        {
            Student[] sArray = new Student[countOfStudents];

            for (int i = 0; i < countOfStudents; i++)
            {

                Console.Write($"Ученик {i + 1}:");
                string[] line = Console.ReadLine().Split(' ');

                Student student = new Student(line[0], line[1], int.Parse(line[2]), int.Parse(line[3]), int.Parse(line[4]));

                sArray[i] = student;

            }

            return sArray;

        }
    }

    struct Student : IComparable
    {

        private string name;
        private string surname;
        private int g1;
        private int g2;
        private int g3;
        private decimal average;

        public int CompareTo(object? o)
        {
            if (o is Student student) return average.CompareTo(student.average);
            else throw new ArgumentException("Некорректное значение параметра");
        }

        public decimal Average
        {
            get { return average; }

        }

        public string Name
        {
            get { return name; }
        }
        public string Surname
        {
            get { return surname; }
        }


        public Student(string f, string n, int g1, int g2, int g3)
        {
            this.name = n;
            this.surname = f;
            this.g1 = g1;
            this.g2 = g2;
            this.g3 = g3;
            this.average = Math.Round((((decimal)g1 + (decimal)g2 + (decimal)g3) / 3), 2);
            // Console.WriteLine(average.ToString());
        }

        public override string ToString()
        {
            return $"{surname} {name}";
        }
    }
}

/*

Ivan Petya 4 5 5
Fedor Vanya 5 5 4
Senya Zhenya 5 5 5
Nik Pock 2 1 1
Werk Kerk 2 2 1
Ivanius Petyas 2 5 5
Fedorius Vanya 1 3 2
Senyakus Zhenyaus 5 3 5
Nikropilis Pockusik 2 4 1
Werkomeb Kerkops 2 2 2

*/