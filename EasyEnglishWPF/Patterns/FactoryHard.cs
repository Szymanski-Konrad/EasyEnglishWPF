using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Patterns
{
    public class FactoryHard : AbstractFactory
    {
        public override Level GetLevel()
        {
            var level = new LevelHard();
            level.Nubmer = 4;
            return level;
        }
    }
}
