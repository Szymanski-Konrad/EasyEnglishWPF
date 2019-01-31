using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEnglishWPF.Patterns;

namespace EasyEnglishWPF.Classes
{
    class SingleTestReader : ITestDBReader
    {
        public SingleTestReader()
        {

        }

        public List<Question> ReadTestData(string buildTestType, int lvl)
        {
            return Database.LoadTenQuestions(buildTestType, "close", lvl);
        }
    }
}
