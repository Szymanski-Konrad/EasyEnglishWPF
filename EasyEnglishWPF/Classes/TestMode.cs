using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    class TestMode : ICommand
    {
        private User user;  //executing obj

        public TestMode(User user)
        {
            this.user = user;
        }

        public void Execute()
        {
            user.StartTest();
        }

        public void Stop()
        {
            user.StopTest();
        }
    }
}
