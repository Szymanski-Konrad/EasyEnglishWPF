using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEnglishWPF.Classes;

namespace EasyEnglishWPF.Patterns
{
    interface IBuilder
    {
        Test Test { get; }

        void NewTest();
        void SetDifficulty();
        void SetType();
    }
}
