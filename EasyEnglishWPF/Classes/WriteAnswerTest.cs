using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class WriteAnswerTest : Test, IAbstractFactory
    {
        public WriteAnswerTest(string type, string strategy)
        {
            testName = "Test własnej odpowiedzi";
            this.type = type;
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
