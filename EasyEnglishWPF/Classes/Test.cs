using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEnglishWPF.Patterns;

namespace EasyEnglishWPF.Classes
{
    public abstract class Test : ILevel, IType
    {

        protected string test_name = "test";

        public int level { get; set; }
        public string type { get; set; }

        virtual public string Hint()
        {
            return "Brak podpowiedzi";
        }

        public abstract string GetResult();
    }
}
