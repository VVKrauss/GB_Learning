namespace Homework_8_2
{
    public class QuestionElement
    {

        public bool Yesno { get; set; }
        public string Question { get; set; }


        public QuestionElement(string question, bool yesno)
        {
            Yesno = yesno;
            Question = question;
        }

        public QuestionElement() { }
    }
}