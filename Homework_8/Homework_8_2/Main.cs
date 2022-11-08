using System.IO;
using System.Windows.Forms;

namespace Homework_8_2
{
    public partial class Main : Form
    {
        Engine engine;
        bool fileOpend = false;

        private string about = @"2.
а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок (не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» улучшения на свое усмотрение.
в) Добавить в приложение меню «О программе» с информацией о программе (автор, версия, авторские права и др.).
г)*Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных (элемент SaveFileDialog).

Студент: Краусс";

        private string copyright = @"О программе.
Автор: Виталий Краусс
Версия программы: 1.01
copyright @ никому нельзя ничего копировать! ;(";

        public Main()
        {
            InitializeComponent();
            groupBoxQuestion.Visible = false;
            labelLoadFile.Visible = true;

        }

        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void labelInfo_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(about, "О задании... ", MessageBoxButtons.OK);
        }



        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(copyright, "О задании... ", MessageBoxButtons.OK);
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            if (fileOpend)
            {
                string question = textBoxMain.Text;
                bool value = radioButtonTrue.Checked;

                engine.Add(question, value);

                engine.SaveQuestions();
                numericUpDown.Maximum++;
                numericUpDown.Minimum = 1;
                numericUpDown.Value++;
                groupBoxQuestion.Visible = true;

            }
            else
            {
                ShowDialogOpenFilePlease();
            }

        }

        private void ShowDialogOpenFilePlease()
        {
            MessageBox.Show("Сначала откройте файл с данными", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonChange_Click(object sender, System.EventArgs e)
        {
            if (fileOpend)
            {
                //Изменить текущий вопрос
                string question = textBoxMain.Text;
                bool value = radioButtonTrue.Checked;
                int num = (int)numericUpDown.Value;

                engine.Edit(question, value, num);
                engine.SaveQuestions();
            }
            else
            {
                ShowDialogOpenFilePlease();
            }

        }

        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            //удалиь вопрос
            if (fileOpend)
            {

                if (numericUpDown.Maximum == 1)
                {

                    if (DialogResult.OK == MessageBox.Show("остался всего один вопрос. Удаляя его Вы удалите файл...\nПродолжить?",
                                                            "Удаление файла",
                                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {

                        File.Delete(engine.FileName);
                        textBoxMain.Text = "";
                        labelLoadFile.Visible = true;
                        fileOpend = false;
                        groupBoxQuestion.Visible = false;

                    }
                    else
                    {
                        return;
                    }

                }
                else

                if (DialogResult.Yes == MessageBox.Show("Вы уверены, что хотите удалить вопрос?",
                                                        "Удалить вопрос?",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question))
                {

                    int num = (int)numericUpDown.Value;
                    engine.Remove(num - 1);
                    engine.SaveQuestions();
                    numericUpDown.Value = 1;
                    numericUpDown.Maximum--;

                    if (numericUpDown.Value == 1)
                    {

                        textBoxMain.Text = engine[0].Question;
                        radioButtonTrue.Checked = engine[0].Yesno;
                    }

                    MessageBox.Show("Вопрос удалён", "ok", MessageBoxButtons.OK);
                }
                else
                    return;
            }
            else
            {
                ShowDialogOpenFilePlease();
            }
        }

        private void numericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            if (engine != null)
            {
                textBoxMain.Text = engine[(int)numericUpDown.Value - 1].Question;
                radioButtonTrue.Checked = engine[(int)numericUpDown.Value - 1].Yesno;
            }
        }

        private void menuItemNew_Click(object sender, System.EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                engine = new Engine(saveFileDialog.FileName);
                engine.Add("Гомеопатия работает?", false);
                engine.SaveQuestions();
                numericUpDown.Maximum = 1;
                numericUpDown.Minimum = 1;
                numericUpDown.Value = 1;

                labelLoadFile.Visible = false;

                fileOpend = true;
                textBoxMain.Text = engine[0].Question;
                radioButtonTrue.Checked = engine[0].Yesno;
                radioButtonFalse.Checked = !engine[0].Yesno;
                groupBoxQuestion.Visible = true;
            }

        }

        private void menuItemOpen_Click(object sender, System.EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                engine = new Engine(ofd.FileName);
                engine.LoadQuestions();
                numericUpDown.Maximum = engine.Count;
                numericUpDown.Minimum = 1;
                numericUpDown.Value = engine.Count;

                labelLoadFile.Visible = false;
                fileOpend = true;
                groupBoxQuestion.Visible = true;
            }
        }

        private void menuItemSave_Click(object sender, System.EventArgs e)
        {
            if (engine != null)
            {
                engine.SaveQuestions();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (engine != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    engine.SaveQuestions(saveFileDialog.FileName);
                }
            }
        }
    }
}
