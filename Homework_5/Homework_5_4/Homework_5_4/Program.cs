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
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            Student[] students = CreateStudentsArray(countOfStudents);

            Array.Sort(students);

            BadStudents(students);

            Krauss.Utilities.Helper.EndProgramm();
        }

        private static void BadStudents(Student[] students)
        {

            decimal temp = 0;
            Console.WriteLine($"\nХудшие ученики:");

            for (int i = 0; i < students.Length; i++) {

                if (i < 3)
                {
                    Console.WriteLine($"{students[i].ToString()}");
                    temp = students[i].Average;
                }
                else {
                    if (students[i].Average == temp) {
                        Console.WriteLine($"{students[i].ToString()}");
                    }
                }
             }

        }

        private static Student[] CreateStudentsArray(int countOfStudents)
        {
            Student[] sArray = new Student[countOfStudents];    

            for (int i = 0; i < countOfStudents; i++) {

                Console.Write($"Ученик {i+1}:");
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

        public decimal Average {
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


        public Student(string f, string n, int g1, int g2, int g3 )
        { 
            this.name = n;  
            this.surname = f;
            this.g1 = g1;
            this.g2 = g2;
            this.g3 = g3;
            this.average = Math.Round((((decimal)g1 + (decimal)g2 + (decimal)g3) / 3),2);
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

*/