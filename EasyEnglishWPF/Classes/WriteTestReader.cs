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

        public List<Question> ReadTestData(string buildTestType)
        {
            switch (buildTestType)
            {
                case "first":
                    return Database.LoadFirst();
                case "last":
                    return Database.LoadLast();
                case "random":
                    return Database.LoadRandom();
                default:
                    return null;
            }
        }
    }
}
