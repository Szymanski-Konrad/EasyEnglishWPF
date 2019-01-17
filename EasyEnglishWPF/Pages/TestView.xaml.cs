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
        private string skill = "";
        private string way = "";

        public TestView()
        {
            InitializeComponent();
        }

        private void Run_Test(object sender, RoutedEventArgs e)
        {
            OptionGrid.Visibility = Visibility.Collapsed;
            Test.Visibility = Visibility.Visible;
        }

        private void Skill_Checked(object sender, RoutedEventArgs e)
        {
            skill = (sender as RadioButton).Content.ToString();
            MessageBox.Show(skill);
        }

        private void Way_Checked(object sender, RoutedEventArgs e)
        {
            way = (sender as RadioButton).Content.ToString();
            MessageBox.Show(way);
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
