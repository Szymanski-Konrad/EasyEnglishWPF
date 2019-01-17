using EasyEnglishWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Patterns
{
    /// <summary>
    /// Most
    /// </summary>
    public interface ITestDBReader
    {
        List<Question> ReadTestData(string buildTestType);
    }
}
