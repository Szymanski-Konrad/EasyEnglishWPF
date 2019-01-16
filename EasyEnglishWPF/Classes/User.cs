using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    class User
    {
        private string id;
        
        public User(string id)
        {
            this.id = id;
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
