using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class SingleChoiceTest : Test, IAbstractFactory
    {
        public SingleChoiceTest()
        {
            test_name = "Test jednokrotnego wyboru";
        }

        public override string GetResult()
        {
            return "choose";
        }

        public void SetLevel()
        {

        }

        public void SetType()
        {

        }
    }
}
