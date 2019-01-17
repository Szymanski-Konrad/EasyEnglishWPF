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
        public string Content { get; set; }
        public string Correct { get; set; }
    
        virtual public string ShowHint()
        {
            return "Podpowiedź: ";
        }

        virtual public bool CheckCorrect()
        {
            return false;
        }
    }
}
