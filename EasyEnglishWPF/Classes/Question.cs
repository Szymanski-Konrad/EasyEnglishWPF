using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public abstract class Question
    {
        public Question()
        {

        }

        public Question(int id, string q, string a)
        {
            ID = id;
            question = q;
            answer = a;
        }

        public int ID { get; set; }

        public string question { get; set; }
        public string answer { get; set; }

        public bool CheckAnswer(string a)
        {
            return string.Equals(answer, a, StringComparison.OrdinalIgnoreCase);
        }

        public void ChangeSolvingWay()
        {
            string x = question;
            question = answer;
            answer = x;
        }

        public virtual string GetHint()
        {
            return "Brak podpowiedzi";
        }

        public override string ToString()
        {
            return question + " - " + answer;
        }
    }
}
