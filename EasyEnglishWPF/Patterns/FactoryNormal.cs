using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Patterns
{
    public class FactoryNormal : AbstractFactory
    {
        public override Level GetLevel()
        {
            var level = new LevelNormal();
            level.Nubmer = 3;
            return level;
        }
    }
}
