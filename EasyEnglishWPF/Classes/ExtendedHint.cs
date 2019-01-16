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
        private string hint;

        public ExtendedHint(Question q, string h)
        {
            question = q;
            hint = h;
        }

        public override string ShowHint()
        {
            return question.ShowHint() + ", " + hint;
        }
    }
}
