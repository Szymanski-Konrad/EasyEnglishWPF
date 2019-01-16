using EasyEnglishWPF.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEnglishWPF.Classes
{
    class LearnMode : ICommand
    {
        private User user;  //executing obj

        public LearnMode(User user)
        {
            this.user = user;
        }

        public void Execute()
        {
            user.StartLearning();
        }

        public void Stop()
        {
            user.StopLearning();
        }
    }
}
