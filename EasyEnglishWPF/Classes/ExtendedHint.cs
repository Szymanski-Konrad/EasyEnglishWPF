using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEnglishWPF.Patterns;

namespace EasyEnglishWPF.Classes
{
    public class ExtendedHint : Decorator
    {
        Test test;

        public ExtendedHint(Test t)
        {
            test = t;
        }

        public override string GetResult()
        {
            return test.GetResult() + " extended";
        }

        public override string Hint()
        {
            if (test is WriteAnswerTest)
            {
                return "Rozszerzona podpowiedż dla otwartego testu";
            }
            else if (test is SingleChoiceTest)
            {
                return "Rozszerzona podpowiedź dla zamknietego testu";
            }

            return "Nieobsługiwany rodzaj testu";
        }
    }
}
