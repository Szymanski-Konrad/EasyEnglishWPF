using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class ShortHint : Hint
    {
        Question question;

        public ShortHint(Question q)
        {
            question = q;
        }

        public override string ShowHint()
        {
            return "Nieobsługiwany rodzaj testu";
        }
    }
}
