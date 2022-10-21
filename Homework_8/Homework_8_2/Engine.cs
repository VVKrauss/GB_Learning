using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Homework_8_2
{
    internal class Engine
    {
        #region Private Fields

        private readonly string _fileName;
        private List<QuestionElement> _allQuestions;

        #endregion

        #region Constructors

        public Engine(string fileName)
        {
            this._fileName = fileName;
            this._allQuestions = new List<QuestionElement>();
        }

        #endregion

        #region Public Properties

        public string FileName { get { return _fileName; } }

        public int Count { get { return _allQuestions.Count; } }

        public QuestionElement this[int index]
        {
            get { return _allQuestions[index]; }
        }

        #endregion

        #region Public Methods

        public void Add(string question, bool yesNo)
        {

            _allQuestions.Add(new QuestionElement(question, yesNo));

        }

        public void Edit(string question, bool yesNo, int index)
        {

            _allQuestions[index - 1] = (new QuestionElement(question, yesNo));

        }

        public void Remove(int index)
        {

            if (index >= 0 && index < _allQuestions.Count)
            {
                _allQuestions.RemoveAt(index);
            }

        }
        #endregion

        public void LoadQuestions()
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<QuestionElement>));
            FileStream fileStream = new FileStream(this._fileName, FileMode.Open, FileAccess.Read);
            _allQuestions = (List<QuestionElement>)xmlSerializer.Deserialize(fileStream);
            fileStream.Close();

        }

        public void SaveQuestions()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<QuestionElement>));
            FileStream fileStream = new FileStream(this._fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, _allQuestions);
            fileStream.Close();

        }

        public void SaveQuestions(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<QuestionElement>));
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, _allQuestions);
            fileStream.Close();

        }

    }
}
