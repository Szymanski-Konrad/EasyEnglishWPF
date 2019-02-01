using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class CloseQuestion : Question
    {
        public List<string> wrongAnswers;

        public CloseQuestion()
        {
            wrongAnswers = new List<string>();
        }

        public CloseQuestion(int id, string q, string a) : base(id, q, a)
        {
            wrongAnswers = new List<string>();
        }

        public void GetWrongAnswers(bool polish, int number_of_answers, int lvl)
        {
            if (polish)
                wrongAnswers = Database.LoadFakeAnswersPL(ID, number_of_answers, lvl);
            else
                wrongAnswers = Database.LoadFakeAnswersENG(ID, number_of_answers, lvl);
        }
    }
}
