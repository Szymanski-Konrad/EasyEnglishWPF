using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class TestCloseBuilder : IBuilder
    {
        private Test test = new SingleChoiceTest();
        string strategy;

        public TestCloseBuilder(AbstractFactory abstractFactory, string strategy)
        {
            test.level = abstractFactory.GetLevel();
            this.strategy = strategy;
        }

        public void SetStrategy()
        {
            switch (strategy)
            {
                case "first":
                    test.questionChooseStrategy = new FirstChoose();
                    break;
                case "last":
                    test.questionChooseStrategy = new LastChoose();
                    break;
                case "random":
                    test.questionChooseStrategy = new RandomChoose();
                    break;
                default:
                    break;
            }
        }

        public void SetType()
        {
            test.type = "close";
        }

        public Test PrintTest()
        {
            return test;
        }
    }
}
