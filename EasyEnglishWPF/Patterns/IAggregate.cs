using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Patterns
{
    /// <summary>
    /// Iterator
    /// </summary>
    public interface IAggregate
    {
        IIterator CreateStandardIterator();

        IIterator CreateRandomIterator();

        IIterator CreateEdgeIterator();
    }
}
