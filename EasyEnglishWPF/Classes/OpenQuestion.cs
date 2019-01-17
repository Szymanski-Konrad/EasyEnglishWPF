using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class OpenQuestion : Question
    {
        public bool CheckAnswer(string answer)
        {
            return string.Equals(Correct, answer, StringComparison.OrdinalIgnoreCase);
        }
    }
}
