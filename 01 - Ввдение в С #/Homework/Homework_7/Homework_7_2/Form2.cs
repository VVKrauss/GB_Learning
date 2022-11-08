using System;
using System.Windows.Forms;

namespace Homework_7_2
{
    public partial class Form2 : Form
    {
        public int _usersNumber;

        public string LabelText
        {
            get
            {
                return textBoxUsersNumber.ToString();
            }
        }

        public Form2()
        {
            InitializeComponent();
        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            ConfirmNumber();
        }

        private void ConfirmNumber()
        {
            int.TryParse(this.textBoxUsersNumber.Text, out _usersNumber);
            Update();
            Close();
        }


    }
}
