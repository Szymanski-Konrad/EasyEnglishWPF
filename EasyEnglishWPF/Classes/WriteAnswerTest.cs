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
        public WriteAnswerTest()
        {
            testName = "Test własnej odpowiedzi";
        }

        public override int GetResult()
        {
            return points;
        }

        public override void IncreasePoints()
        {
            points++;
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }
    }
}
