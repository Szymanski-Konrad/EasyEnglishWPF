using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class CloseQuestion : Question
    {
        private List<string> answers;
        private int index;

        public CloseQuestion()
        {
            answers = new List<string>();
        }

        public void SetIndex(int number)
        {
            index = number;
        }

        public void PopulateAnswers(List<string> list)
        {
            foreach (string item in list)
            {
                answers.Add(item);
            }
        }

        public bool CheckAnswer(string answer)
        {
            return index == answers.IndexOf(answer);
        }

    }
}
