using EasyEnglishWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Patterns
{
    /// <summary>
    /// Dekorator
    /// </summary>
    public class Hint : Question
    {
        protected new Question quest;

        public Hint(Question q) : base(q.ID, q.question, q.answer)
        {
            quest = q;    
        }

        public override string GetHint()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
