using EasyEnglishWPF.Classes;
using EasyEnglishWPF.Patterns;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EasyEnglishWPF
{
    //TODO: Zmiana języka w trybie testu
    //TODO: Zmiana języka w trybie nauki
    //TODO: Podpowiedzi w obu trybach
    //TODO: Poprawić historie testów
    //TODO: Zrobić dokumentacje



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
