using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Patterns
{
    /// <summary>
    /// Abstract Factory interface.
    /// </summary>
    interface IAbstractFactory
    {
        /// <summary>
        /// Sets the difficulty level.
        /// </summary>
        /// <param name="level">The difficulty level.</param>
        void SetLevel(int level);
    }
}
