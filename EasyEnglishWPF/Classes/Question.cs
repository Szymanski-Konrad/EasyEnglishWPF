using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class Question
    {
        public int ID { get; set; }
        public string Polish { get; set; }
        public string English { get; set; }
    
        virtual public string ShowHint()
        {
            return "Podpowiedź: ";
        }

        public bool CheckAnswer(string answer)
        {
            return string.Equals(English, answer, StringComparison.OrdinalIgnoreCase);
        }

        public bool CheckRevertAnswer(string answer)
        {
            return string.Equals(Polish, answer, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return Polish + " - " + English;
        }
    }
}
