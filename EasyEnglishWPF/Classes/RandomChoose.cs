﻿using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class RandomChoose : IChoose
    {
        public List<Question> GetQuestions()
        {
            return new SingleTestReader().ReadTestData("random");
        }
    }
}
