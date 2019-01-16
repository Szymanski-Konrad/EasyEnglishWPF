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
        private string hint;

        public ShortHint(Question q, string h)
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
