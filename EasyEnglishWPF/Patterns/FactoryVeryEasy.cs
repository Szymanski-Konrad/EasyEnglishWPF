using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Patterns
{
    public class FactoryVeryEasy : AbstractFactory
    {
        public override Level GetLevel()
        {
            var level = new LevelVeryEasy();
            level.Nubmer = 1;
            return level;
        }
    }
}
