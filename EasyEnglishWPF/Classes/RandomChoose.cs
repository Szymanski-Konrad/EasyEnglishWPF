using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class RandomChoose : IChoose
    {
        public List<Question> GetQuestions()
        {
            int x = 0;
            Random random = new Random();
            var get_list = Database.LoadQuestions();
            List<Question> list = new List<Question>();

            if (Database.QuestionsCount() > 10)
            {
                x = 10;
            }
            else x = Database.QuestionsCount();

            for (int i = 0; i < x; i++)
            {
                int y = random.Next(get_list.Count);
                list.Add(get_list[y]);
                get_list.RemoveAt(y);
            }

            return list;
        }
    }
}
