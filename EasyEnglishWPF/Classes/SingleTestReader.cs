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
