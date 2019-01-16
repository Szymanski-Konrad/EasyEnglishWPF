using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class OpenQuestion : Question
    {
        private string correct_answer;

        public OpenQuestion()
        {
            correct_answer = "";
        }

        public void SetCorrect(string correct)
        {
            correct_answer = correct;
        }

        public bool CheckAnswer(string answer)
        {
            return correct_answer.ToLower() == answer.ToLower();
        }
    }
}
