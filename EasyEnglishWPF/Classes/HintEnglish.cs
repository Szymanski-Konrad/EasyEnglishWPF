using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class HintEnglish : Hint
    {
        private string hint;

        public HintEnglish(Question q, string h) : base(q)
        {
            hint = h;
        }

        public override string GetHint()
        {
            return hint;
        }

    }
}
