using EasyEnglishWPF.Classes;
using EasyEnglishWPF.Patterns;
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
        private string strategy = "";
        private Test test;
        private User user;
        private IIterator iterator;

        public TestView(ref User u)
        {
            InitializeComponent();
            user = u;
        }

        private void Run_Test(object sender, RoutedEventArgs e)
        {
            OptionGrid.Visibility = Visibility.Collapsed;
            Close.Visibility = Visibility.Visible;

            if (skill == "test otwarty")
                user.CreateTest("open", strategy);
            else
                user.CreateTest("close", strategy);

            test = user.GetTest();
            ConcreteAggregate concreteAggregate = new ConcreteAggregate();
            concreteAggregate.AddQuestions(test.questionChooseStrategy.getQuestions());
            iterator = concreteAggregate.CreateStandardIterator();

            if (iterator.HasNext())
            {
                Question question = (Question)iterator.Next();
                PolishOpen.Content = question.Polish;
            }
        }

        private void Skill_Checked(object sender, RoutedEventArgs e)
        {
            skill = (sender as RadioButton).Content.ToString();
        }

        private void Way_Checked(object sender, RoutedEventArgs e)
        {
            way = (sender as RadioButton).Content.ToString();
        }

        private void Strategy_Checked(object sender, RoutedEventArgs e)
        {
            strategy = (sender as RadioButton).Tag.ToString();
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            if (iterator.HasNext())
            {

            }
        }

        private void AnswerOpen_Click(object sender, RoutedEventArgs e)
        {
            if (iterator.Current().CheckCorrect())
                test.IncreasePoints();

            if (iterator.HasNext())
            {
                Question question = (Question)iterator.Next();
                PolishOpen.Content = question.Polish;
            }
            else
            {
                MessageBox.Show(test.GetResult().ToString());
            }
        }
    }
}
