using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class SingleChoiceTest : Test, IAbstractFactory
    {
        public SingleChoiceTest(string strategy)
        {
            testName = "Test jednokrotnego wyboru";

            switch (strategy)
            {
                case "first":
                    questionChooseStrategy = new FirstChoose();
                    break;
                case "last":
                    questionChooseStrategy = new LastChoose();
                    break;
                case "random":
                    questionChooseStrategy = new RandomChoose();
                    break;
                default:
                    break;
            }
        }

        public void LoadQuestions()
        {
            Questions = questionChooseStrategy.GetQuestions();
        }

        public override void IncreasePoints()
        {
            points++;
        }

        public override int GetResult()
        {
            return points;
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }
    }
}
