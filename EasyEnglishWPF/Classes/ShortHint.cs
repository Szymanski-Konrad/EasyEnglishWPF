using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class ShortHint : Decorator
    {
        Test test;

        public ShortHint(Test t)
        {
            test = t;
        }

        public override string GetResult()
        {
            return test.GetResult() + " short";
        }

        public override string Hint()
        {
            if (test is WriteAnswerTest)
            {
                return "Krótka podpowiedż dla otwartego testu";
            }
            else if (test is SingleChoiceTest)
            {
                return "Krótka podpowiedź dla zamknietego testu";
            }

            return "Nieobsługiwany rodzaj testu";
        }
    }
}
