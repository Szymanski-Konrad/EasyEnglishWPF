using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    class LastChoose : IChoose
    {
        public List<Question> GetQuestions(string reader_type, int lvl)
        {
            if (reader_type == "single")
                return new SingleTestReader().ReadTestData("last", lvl);
            else
                return new WriteTestReader().ReadTestData("last", lvl);
        }
    }
}
