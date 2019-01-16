using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEnglishWPF.Patterns;

namespace EasyEnglishWPF.Classes
{
    public abstract class Test : ILevel, IType
    {
        public ITestDBReader TestReader { get; set; }
        public List<Question> Questions { get; set; }
        public IChoose questionChooseStrategy { get; set; }
        public IAggregate aggregate { get; set; }
        
        protected string test_name = "test";

        public int level { get; set; } 
        public string type { get; set; }


        public abstract string GetResult();
    }
}
