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
        List<string> wrongAnswers;

        public CloseQuestion()
        {
            wrongAnswers = new List<string>();
        }

        public CloseQuestion(int id, string q, string a) : base(id, q, a)
        {
            wrongAnswers = new List<string>();
        }

        public void GetWrongAnswers(bool polish, int number_of_answers)
        {
            if (polish)
                wrongAnswers = Database.LoadFakeAnswersPL(ID, number_of_answers);
            else
                wrongAnswers = Database.LoadFakeAnswersENG(ID, number_of_answers);
        }
    }
}
