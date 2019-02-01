using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class SingleChoiceTest : Test
    {
        public SingleChoiceTest()
        {
            testName = "Test jednokrotnego wyboru";
        }

        public void LoadQuestions()
        {
            Questions = questionChooseStrategy.GetQuestions("single");
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
