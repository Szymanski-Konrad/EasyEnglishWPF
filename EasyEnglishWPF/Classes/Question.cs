﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class Question
    {
        public string Content { get; set; }
        public string Hit { get; set; }
    
        virtual public string ShowHint()
        {
            return "Brak podpowiedzi";
        }
    }
}
