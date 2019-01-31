using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class RandomChoose : IChoose
    {
        public List<Question> GetQuestions(string reader_type)
        {
            if (reader_type == "single")
                return new SingleTestReader().ReadTestData("random");
            else
                return new WriteTestReader().ReadTestData("random");
        }
    }
}
