using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEnglishWPF.Patterns;

namespace EasyEnglishWPF.Classes
{
    public abstract class Test : IType
    {
        public ITestDBReader TestReader { get; set; }
        public List<Question> Questions { get; set; }
        public IChoose questionChooseStrategy { get; set; }
        public IAggregate aggregate { get; set; }
        public int points = 0;
        
    
        protected string testName = "test";

        public Level level { get; set; } 
        public string type { get; set; }

        public abstract void IncreasePoints();

        public abstract int GetResult();

        public override string ToString()
        {
            return testName + ": " + points + "/10  ";
        }
    }
}
