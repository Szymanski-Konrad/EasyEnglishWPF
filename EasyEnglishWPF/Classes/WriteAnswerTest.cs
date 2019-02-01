using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class WriteAnswerTest : Test
    {
        public WriteAnswerTest()
        {
            testName = "Test własnej odpowiedzi";
        }

        public void LoadQuestions()
        {
            Questions = questionChooseStrategy.GetQuestions("write", level.Nubmer);
        }

        public override void IncreasePoints()
        {
            points++;
        }

        public override int GetResult()
        {
            return points;
        }
    }
}
