using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class ConcreteAggregate : IAggregate
    {
        private List<Question> questions = new List<Question>();

        public void AddQuestion(Question q)
        {
            questions.Add(q);
        }

        public int Count
        {
            get { return questions.Count; }
        }

        public Question GetQuestion(int index)
        {
            return questions[index];
        }

        public IIterator CreateEdgeIterator()
        {
            throw new NotImplementedException();
        }

        public IIterator CreateRandomIterator()
        {
            throw new NotImplementedException();
        }

        public IIterator CreateStandardIterator()
        {
            return new StandardIterator(this);
        }

        
    }
}
