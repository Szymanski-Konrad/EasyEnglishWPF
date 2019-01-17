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
    /// Interaction logic for TestView.xaml
    /// </summary>
    public partial class TestView : UserControl
    {
        public TestView(string mode)
        {
            InitializeComponent();

            if (mode == "open")
                Open.Visibility = Visibility.Visible;
            else
                Close.Visibility = Visibility.Visible;
        }

        private void OpenAnswer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseAnswer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
