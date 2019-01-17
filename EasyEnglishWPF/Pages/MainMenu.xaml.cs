using EasyEnglishWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyEnglishWPF.Pages
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl, ISwitchable
    {
        public User user;
        public MainMenu()
        {
            InitializeComponent();
            user = new User("user");
            user.SetBuilder(new TestBuilder());            
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            Switcher.Switch(new Pages.HistoryWindow());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Pages.OpeenTestWindow(ref user));
        }

        private void EditDatabase_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Pages.EditDatabase());
        }
    }
}
