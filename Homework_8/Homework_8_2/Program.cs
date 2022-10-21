/*
2.
а) Создать приложение, показанное на уроке, добавив в него защиту от возможных
ошибок (не создана база данных, обращение к несуществующему вопросу, открытие
слишком большого файла и т.д.).
б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и
добавив другие «косметические» улучшения на свое усмотрение.
в) Добавить в приложение меню «О программе» с информацией о программе (автор,
версия, авторские права и др.).
г)*Добавить пункт меню Save As, в котором можно выбрать имя для сохранения
базы данных (элемент SaveFileDialog).

Разделяйте логику между классами. В свойствах проектах в качестве
запускаемого проекта укажите “Текущий выбор”

Krauss    
*/
using System;
using System.Windows.Forms;

namespace Homework_8_2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
