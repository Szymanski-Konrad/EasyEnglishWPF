using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class WriteTestReader : ITestDBReader
    {
        public WriteTestReader()
        {

        }

        public List<Question> ReadTestData(string buildTestType, int lvl)
        {
            return Database.LoadTenQuestions(buildTestType, "open", lvl);
        }
    }
}
