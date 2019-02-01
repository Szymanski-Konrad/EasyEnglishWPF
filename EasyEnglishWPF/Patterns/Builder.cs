using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEnglishWPF.Classes;

namespace EasyEnglishWPF.Patterns
{
    public abstract class Builder
    {
        //UPGRADE: moze cos z nullem zrobic

        protected Test test;
        
        public abstract void CreateNewTest();
            //if (test == null)
            //{
            //    if (type == "open")
            //    {
            //        if (strategy == "first"
            //            || strategy == "last"
            //            || strategy == "random")
            //        {
            //            test.type = type;
            //        }
            //    }
            //    if (type == "close")
            //    {
            //        if (strategy == "first"
            //            || strategy == "last"
            //            || strategy == "random")
            //        {
            //            test = new SingleChoiceTest(type, strategy);
            //        }
            //    }
            //}
        
        public Test GetTest()
        {
            return test;
        }
    }
}
