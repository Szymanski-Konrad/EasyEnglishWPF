using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    class WriteAnswerTest : Test
    {
        public WriteAnswerTest()
        {
            test_name = "Test własnej odpowiedzi";
        }

        public override string GetResult()
        {
            return "write";
        }
    }
}
