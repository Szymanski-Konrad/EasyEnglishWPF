using System;
using System.Windows;
using System.Windows.Controls;

namespace EasyEnglishWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Database.SaveHistory("user", "nowy test");
            //Database.SaveHistory("user", "nowy test");
            //Database.SaveHistory("user", "nowy test");
            //Database.SaveHistory("user", "nowy test");
            //Database.SaveHistory("user", "nowy test");

            //var list = Database.LoadHistory("user");

            //foreach (var item in list)
            //    MessageBox.Show(item);

            Switcher.pageSwitcher = this;
            Switcher.Switch(new Pages.MainMenu());
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! " + nextPage.Name.ToString());
        }
    }
}
