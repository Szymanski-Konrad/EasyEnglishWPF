using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Patterns
{
    public interface IAggregate
    {
        IIterator CreateStandardIterator();

        IIterator CreateRandomIterator();

        IIterator CreateEdgeIterator();
    }
}
