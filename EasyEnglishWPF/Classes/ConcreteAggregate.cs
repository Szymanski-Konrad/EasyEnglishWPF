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

        public void AddQuestions(List<Question> list)
        {
            foreach (Question question in list)
            {
                questions.Add(question);
            }
        }

        public int Count
        {
            get { return questions.Count; }
        }

        public Question GetQuestion(int index)
        {
            return questions[index];
        }

        public List<Question> GetQuestions()
        {
            return questions;
        }

        public IIterator CreateEdgeIterator()
        {
            return new EdgeIterator(this);
        }

        public IIterator CreateRandomIterator()
        {
            return new RandomIterator(this);
        }

        public IIterator CreateStandardIterator()
        {
            return new StandardIterator(this);
        }

        
    }
}
