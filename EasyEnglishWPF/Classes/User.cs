using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    public class User
    {
        private string id;
        private Builder builder;

        public User(string id)
        {
            this.id = id;
        }

        public void SetBuilder(Builder builder)
        {
            this.builder = builder;
        }

        public Test GetTest()
        {
            return builder.GetTest();
        }

        public void CreateTest(string type, string strategy)
        {
            builder.CreateNewTest(type, strategy);
        }

        public void StartLearning()
        {
            Debug.Print($"User {id} starts learning.");
        }

        public void StopLearning()
        {
            Debug.Print($"User {id} stops learning.");
        }

        public void StartTest()
        {
            Debug.Print($"User {id} starts the test.");
        }

        public void StopTest()
        {
            Debug.Print($"User {id} stops the test.");
        }
    }
}
