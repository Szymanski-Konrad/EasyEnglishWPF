using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class StandardIterator : IIterator
    {
        private ConcreteAggregate aggregate;
        int index;

        public StandardIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
            index = -1;
        }

        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public object Next()
        {
            index++;
            return aggregate.GetQuestion(index);
        }
    }
}
