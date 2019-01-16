using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEnglishWPF.Patterns;

namespace EasyEnglishWPF.Classes
{
    public class AnswerTestReader : ITestDBReader
    {
        public AnswerTestReader()
        {

        }

        public string ReadTestData(string testType, string testLvl)
        {
            return testType + " : " + testLvl;
        }
    }
}
