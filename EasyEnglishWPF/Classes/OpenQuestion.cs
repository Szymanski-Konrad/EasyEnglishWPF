using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class OpenQuestion : Question
    {
        /// <summary>
        /// Sprawdzanie pol -> ang
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public bool CheckAnswer(string answer)
        {
            return string.Equals(English, answer, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Sprawdzanie ang -> pol
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public bool CheckReverseAnswer(string answer)
        {
            return string.Equals(Polish, answer, StringComparison.OrdinalIgnoreCase);
        }
    }
}
