﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEnglishWPF.Patterns;

namespace EasyEnglishWPF.Classes
{
    public class AnswerTestReader : ITestDBReader
    {
        public List<Question> ReadTestData(string buildTestType)
        {
            switch (buildTestType)
            {
                case "first":
                    return Database.LoadFirst();
                case "last":
                    return Database.LoadLast();
                case "random":
                    return Database.LoadQuestions();
                default:
                    return null;
            }
        }
    }
}
