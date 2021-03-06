﻿using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    class FirstChoose : IChoose
    {
        public List<Question> GetQuestions(string reader_type, int lvl)
        {
            if (reader_type == "single")
            {
                return new SingleTestReader().ReadTestData("first", lvl);
            }
            else
                return new WriteTestReader().ReadTestData("first", lvl);
        }
    }
}
