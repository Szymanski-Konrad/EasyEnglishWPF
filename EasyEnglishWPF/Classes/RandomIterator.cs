using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class RandomIterator : IIterator
    {
        private ConcreteAggregate aggregate;
        private Random random;
        private List<Question> questions;
        private Question current;

        public RandomIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
            questions = aggregate.GetQuestions();
            random = new Random();
        }

        public Question Current()
        {
            return current;
        }

        public bool HasNext()
        {
            return questions.Count > 0;
        }

        public Question Next()
        {
            int x = random.Next(questions.Count);
            Question question = questions[x];
            current = question;
            questions.RemoveAt(x);
            return question;
        }
    }
}
