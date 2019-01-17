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

        virtual public bool CheckCorrect()
        {
            return false;
        }

        public override string ToString()
        {
            return ID + " - " + Polish + " - " + English;
        }
    }
}
