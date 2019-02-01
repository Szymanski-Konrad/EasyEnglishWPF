using EasyEnglishWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EasyEnglishWPF.Patterns
{
    /// <summary>
    /// Wzorzec strategia
    /// </summary>

    public interface IChoose
    {
    
        List<Question> GetQuestions(string reader_type, int lvl);
    }
}
