using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEnglishWPF.Classes;

namespace EasyEnglishWPF.Patterns
{
    /// <summary>
    /// Test Builder.
    /// </summary>
    public abstract class Builder
    {
        //UPGRADE: moze cos z nullem zrobic

        protected Test test;

        /// <summary>
        /// Creates the new <see cref="Test"/>.
        /// </summary>
        /// <param name="type">The type of the <see cref="Test"/>. Can take "open" or "close".</param>
        public void CreateNewTest(string type, string strategy)
        {
            if (test == null)
            {
                if (type == "open")
                {
                    test = new WriteAnswerTest();
                }
                if (type == "close")
                {
                    if (strategy == "first"
                        || strategy == "last"
                        || strategy == "random")
                    {
                        test = new SingleChoiceTest(strategy);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the <see cref="Test"/>.
        /// </summary>
        /// <returns><see cref="Test"/></returns>
        public Test GetTest()
        {
            return test;
        }
    }
}
