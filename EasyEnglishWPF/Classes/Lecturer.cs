using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    /// <summary>
    /// Invokes commands for <see cref="User"/>.
    /// </summary>
    /// <seealso cref="EasyEnglishWPF.Patterns.ICommand" />
    class Lecturer
    {
        private ICommand mode;

        public void SetCommand(ICommand command)
        {
            mode = command;
        }

        public void Execute()
        {
            mode.Execute();
        }
    }
}
