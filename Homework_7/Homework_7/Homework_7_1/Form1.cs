using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Homework_7_1
{
    public partial class Form1 : Form
    {

        Random random = new Random();
        private int computersRandom;
        private int usersNum;
        private int stepsCounter;
        private string gameName = "Турбоудвоитель";
        private bool gameStarted = false;
        private Stack<int> steps;
        private bool firstGame = true;

        public Form1()
        {
            InitializeComponent();
            steps = new Stack<int>();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            NewGame();
        }

        private void buttonMultiplay_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                steps.Push(usersNum);
                usersNum *= 2;
                stepsCounter++;

                UpdateInterface();
                CheckWin();
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                steps.Push(usersNum);
                usersNum++;
                stepsCounter++;

                UpdateInterface();
                CheckWin();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            BackStep();

        }

        private void NewGame()
        {
            computersRandom = random.Next(1, 50);
            string firstGameText = $"Привет!\n Тебе нужно за наименьшее количество попыток добраться до числа {computersRandom}";
            string newGameText = $"За наименьшее количество попыток доберись до числа {computersRandom}";

            string startGameText = firstGame ? firstGameText : newGameText;


            MessageBox.Show(startGameText, gameName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            firstGame = false;

            buttonBack.Visible = false;
            gameStarted = true;
            labelComputer.Text = computersRandom.ToString();
            usersNum = 0;
            labelResults.Text = usersNum.ToString();
            stepsCounter = 0;
            labelCounter.Text = "Сделано ходов: " + stepsCounter.ToString();
            labelCounter.Visible = true;
        }

        private void UpdateInterface()
        {

            labelResults.Text = usersNum.ToString();

            labelCounter.Text = "Сделано ходов: " + stepsCounter.ToString();
            if (steps.Count < 1)
                buttonBack.Visible = false;
            else
                buttonBack.Visible = true;

        }
        private void CheckWin()
        {

            if (usersNum == computersRandom)
            {
                // победил
                if (MessageBox.Show("Вы выиграли!\nСыграем ещё?", gameName, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    NewGame();
                }
                else
                {
                    Close();
                }
            }
            else if (usersNum > computersRandom)
            {
                // проиграл
                if (MessageBox.Show("Вы проиграли!\nСыграем ещё?", gameName, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    NewGame();
                }
                else
                {
                    Close();
                }
            }

        }


        private void BackStep()
        {
            usersNum = steps.Pop();
            stepsCounter--;
            UpdateInterface();
        }

        private void labelInfo_Click(object sender, EventArgs e)
        {
            string info = @"Задание 7.1. Студент: Краусс.

а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. Игрок должен получить это число за минимальное количество ходов.
в) *Добавить кнопку «Отменить», которая отменяет последние ходы.Используйте библиотечный обобщенный класс System.Collections.Generic.Stack<int>Stack.

Вся логика игры должна быть реализована в классе с удвоителем.
";

            MessageBox.Show(info, gameName, MessageBoxButtons.OK);
        }
    }
}
