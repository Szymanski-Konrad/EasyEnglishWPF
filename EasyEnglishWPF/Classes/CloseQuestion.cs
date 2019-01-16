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
        private int correct_index;


        public CloseQuestion()
        {
            answers = new List<string>();
        }

        public void PopulateAnswers(List<string> list)
        {
            foreach (string item in list)
            {
                answers.Add(item);
            }
        }

        public void SetCorrect(int index)
        {
            correct_index = index;
        }

        public bool CheckAnswer(int index)
        {
            return index == correct_index;
        }

    }
}
