using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    class FirstChoose : IChoose
    {
        public List<Question> GetQuestions()
        {
            return Database.LoadFirst();
        }
    }
}
