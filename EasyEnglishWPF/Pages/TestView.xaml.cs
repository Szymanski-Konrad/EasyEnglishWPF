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
        private string skill = "2 odpowiedzi";
        private string way = "pol->ang";
        private string strategy = "";

        private string selected_closed = "";

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

            if (skill == "test otwarty")
            {
                user.CreateTest("open", strategy);
                Open.Visibility = Visibility.Visible;
                test = user.GetTest();
                ConcreteAggregate concreteAggregate = new ConcreteAggregate();
                concreteAggregate.AddQuestions(test.questionChooseStrategy.GetQuestions());
                iterator = concreteAggregate.CreateStandardIterator();

                if (iterator.HasNext())
                {
                    Question question = iterator.Next();
                    if (way == "pol->ang") PolishOpen.Content = question.Polish;
                    else PolishOpen.Content = question.English;
                }
            }
            else
            {
                user.CreateTest("close", strategy);
                Test.Visibility = Visibility.Visible;
                test = user.GetTest();
                ConcreteAggregate concreteAggregate = new ConcreteAggregate();
                concreteAggregate.AddQuestions(test.questionChooseStrategy.GetQuestions());
                iterator = concreteAggregate.CreateStandardIterator();

                if (iterator.HasNext())
                {
                    Question question = iterator.Next();
                    if (way == "pol->ang") Polish.Content = question.Polish;
                    else Polish.Content = question.English;
                }

                PopulateClosedAnswers();
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

        private void PopulateClosedAnswers()
        {
            List<string> list = new List<string>();
            if (way == "pol->ang")
            {
                switch (skill)
                {
                    case "5 odpowiedzi":
                        list = Database.LoadFakeAnswersENG(iterator.Current().ID, 4);
                        break;
                    case "4 odpowiedzi":
                        list = Database.LoadFakeAnswersENG(iterator.Current().ID, 3);
                        break;
                    case "3 odpowiedzi":
                        list = Database.LoadFakeAnswersENG(iterator.Current().ID, 2);
                        break;
                    case "2 odpowiedzi":
                        list = Database.LoadFakeAnswersENG(iterator.Current().ID, 1);
                        break;
                    default:
                        break;
                }
                list.Add(iterator.Current().English);
            }
            else
            {
                switch (skill)
                {
                    case "5 odpowiedzi":
                        list = Database.LoadFakeAnswersPL(iterator.Current().ID, 4);
                        break;
                    case "4 odpowiedzi":
                        list = Database.LoadFakeAnswersPL(iterator.Current().ID, 3);
                        break;
                    case "3 odpowiedzi":
                        list = Database.LoadFakeAnswersPL(iterator.Current().ID, 2);
                        break;
                    case "2 odpowiedzi":
                        list = Database.LoadFakeAnswersPL(iterator.Current().ID, 1);
                        break;
                    default:
                        break;
                }
                list.Add(iterator.Current().Polish);
            }

            Options.Children.Clear();
            foreach (string item in list)
            {
                RadioButton radioButton = new RadioButton()
                {
                    Content = item,
                    GroupName = "test"
                };
                radioButton.Checked += RadioButton_Checked;
                Options.Children.Add(radioButton);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            selected_closed = (sender as RadioButton).Content.ToString();
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            switch (way)
            {
                case "pol->ang":
                    if (iterator.Current().CheckAnswer(selected_closed))
                        test.IncreasePoints();

                    if (iterator.HasNext())
                    {
                        Question question = iterator.Next();
                        Polish.Content = question.Polish;
                        PopulateClosedAnswers();
                    }
                    else
                    {
                        MessageBox.Show(test.GetResult().ToString());
                    }
                    break;
                case "ang->pol":
                    if (iterator.Current().CheckRevertAnswer(selected_closed))
                        test.IncreasePoints();

                    if (iterator.HasNext())
                    {
                        Question question = iterator.Next();
                        Polish.Content = question.English;
                        PopulateClosedAnswers();
                    }
                    else
                    {
                        MessageBox.Show(test.GetResult().ToString());
                    }
                    break;
            }
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Pages.MainMenu());
        }

        private void AnswerOpen_Click(object sender, RoutedEventArgs e)
        {
            switch (way)
            {
                case "pol->ang":
                    if (iterator.Current().CheckAnswer(Answer_Eng.Text))
                        test.IncreasePoints();

                    if (iterator.HasNext())
                    {
                        Question question = iterator.Next();
                        PolishOpen.Content = question.Polish;
                    }
                    else
                    {
                        MessageBox.Show(test.GetResult().ToString());
                    }
                    break;
                case "ang->pol":
                    if (iterator.Current().CheckRevertAnswer(Answer_Eng.Text))
                        test.IncreasePoints();

                    if (iterator.HasNext())
                    {
                        Question question = iterator.Next();
                        PolishOpen.Content = question.English;
                    }
                    else
                    {
                        MessageBox.Show(test.GetResult().ToString());
                    }
                    break;
            }
            
        }
    }
}
