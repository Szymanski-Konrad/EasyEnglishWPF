using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEnglishWPF.Patterns;

namespace EasyEnglishWPF.Classes
{
    public class ExtendedHint : Hint
    {
        Question question;

        public ExtendedHint(Question q)
        {
            question = q;
        }

        public override string ShowHint()
        {
            return "Nieobsługiwany rodzaj testu";
        }
    }
}
