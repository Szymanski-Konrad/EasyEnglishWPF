﻿using EasyEnglishWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Patterns
{
    public interface IIterator
    {
        bool HasNext();
        Question Next();
        Question Current();
    }
}
