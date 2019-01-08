using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public abstract class Test
    {
        protected string test_name = "test";

        virtual public string Hint()
        {
            return "Brak podpowiedzi";
        }

        public abstract string GetResult();
    }
}
