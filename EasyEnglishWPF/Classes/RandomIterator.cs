using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class RandomIterator
    {
        private ConcreteAggregate aggregate;
        private Random random;

        public RandomIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
            random = new Random();
        }

        public bool HasNext()
        {
            return true;
        }

        public object Next()
        {
            return aggregate.GetQuestion(random.Next(aggregate.Count - 1));
        }
    }
}
