using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    class EdgeIterator : IIterator 
    {
        private ConcreteAggregate aggregate;
        int left_index;
        int right_index;
        int center;
        bool left_side;

        public EdgeIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
            left_index = -1;
            right_index = aggregate.Count - 1;
            center = right_index / 2;
            left_side = true;
        }

        public Question Current()
        {
            if (left_side)
                return aggregate.GetQuestion(left_index);
            else
                return aggregate.GetQuestion(right_index);
        }

        public bool HasNext()
        {
            return left_index < center && right_index >= center ? true : false;
        }

        public Question Next()
        {
            if (left_side)
            {
                left_index++;
                left_side = false;
                return aggregate.GetQuestion(left_index);
            }
            else
            {
                right_index--;
                left_side = true;
                return aggregate.GetQuestion(right_index);
            }
        }
    }
}
