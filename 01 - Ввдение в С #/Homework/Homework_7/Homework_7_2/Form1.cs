using System;
using System.Windows.Forms;

namespace Homework_7_2
{
    public partial class Form1 : Form
    {
        private string gameName = "Угадай число";
        private int computerNumber;
        Random random = new Random();


        public Form1()
        {
            InitializeComponent();


        }

        private void labelInfo_Click(object sender, EventArgs e)
        {
            string info = @"Задание 7.2. Студент: Краусс.

Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток. Компьютер говорит, больше или меньше загаданное число введенного.
a) Для ввода данных от человека используется элемент TextBox;
б) **Реализовать отдельную форму c TextBox для ввода числа.";

            MessageBox.Show(info, gameName, MessageBoxButtons.OK);
        }

        private void buttonEnterNumber_Click(object sender, EventArgs e)
        {
            buttonEnterNumber.Visible = true;
            Form2 inputDialog = new Form2();


            //ShowDialog(inputDialog);
            inputDialog.ShowDialog();

            int usersGuess = inputDialog._usersNumber;

            Update(usersGuess);

            //   this.labelMainText.Text = .ToString();


        }
        public void Update(int usersGuess)
        {

            if (usersGuess == computerNumber)
            {
                labelMainText.Text = "Вы угадали! Хотите загадаю число ещё раз?";
                buttonEnterNumber.Visible = false;
                buttonGenerateNumber.Visible = true;
            }
            else if (usersGuess > computerNumber)
            {
                labelMainText.Text = $"Число {usersGuess} больше загаданного";
            }
            else
            {
                labelMainText.Text = $"Число {usersGuess} меньше загаданного";
            }
        }

        private void buttonGenerateNumber_Click(object sender, EventArgs e)
        {
            computerNumber = random.Next(1, 101);
            buttonGenerateNumber.Visible = false;
            buttonEnterNumber.Visible = true;
            labelMainText.Text = "Число от 1 до 100 загадано. Попробуйте угадать";
            labelMainText.Visible = true;
        }
    }
}
