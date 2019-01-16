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
    public abstract class Hint : Question
    {
        public abstract override string ShowHint();
    }
}
