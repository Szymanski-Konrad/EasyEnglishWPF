using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    class WriteAnswerTest : Test, IAbstractFactory
    {
        public WriteAnswerTest()
        {
            testName = "Test własnej odpowiedzi";
        }

        public override string GetResult()
        {
            return "write";
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }
    }
}
