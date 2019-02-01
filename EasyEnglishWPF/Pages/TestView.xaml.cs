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
        private Patterns.ICommand command;
        private string skill = "2 odpowiedzi";
        private string way = "pol->ang";
        private string strategy = "first";
        private string type = "Otwarty";

        private string selected_closed = "";

        private Test test;
        private User user;
        private IIterator iterator;
        private Random random;

        public TestView(ref User user)
        {
            InitializeComponent();
            this.user = user;
            command = new TestMode(user);
            random = new Random();
        }

        private void Run_Test(object sender, RoutedEventArgs e)
        {
            command.Execute();
            OptionGrid.Visibility = Visibility.Collapsed;

            if (type == "Otwarty")
            {
                IBuilder builder = new TestOpenBuilder(
                    skill == "Bardzo łatwy" ? new FactoryVeryEasy() :
                    skill == "Łatwy" ? new FactoryEasy() :
                    skill == "Średni" ? new FactoryNormal() : new FactoryHard() as AbstractFactory,
                    strategy);
                user.MakeNewTest(builder);
                this.test = builder.PrintTest();
                Open.Visibility = Visibility.Visible;
                ConcreteAggregate concreteAggregate = new ConcreteAggregate();
                concreteAggregate.AddQuestions(test.questionChooseStrategy.GetQuestions("write", test.level.Nubmer));
                iterator = concreteAggregate.CreateIterator(random.Next(3));

                if (iterator.HasNext())
                {
                    Question question = iterator.Next();
                    if (way == "pol->ang")
                    {
                        question = new HintPolish(question, Database.GetPolishHint(question.ID));
                        PolishOpen.ToolTip = (question as HintPolish).GetHint();
                    }
                    else
                    {
                        question.ChangeSolvingWay();
                        question = new HintEnglish(question, Database.GetEnglishHint(question.ID));
                        PolishOpen.ToolTip = (question as HintEnglish).GetHint();
                    }
                    PolishOpen.Content = question.question;
                }
            }
            else if(type == "Zamkniety")
            {
                IBuilder builder = new TestCloseBuilder(
                    skill == "Bardzo łatwy" ? new FactoryVeryEasy() :
                    skill == "Łatwy" ? new FactoryEasy() :
                    skill == "Średni" ? new FactoryNormal() : new FactoryHard() as AbstractFactory, 
                    strategy);
                user.MakeNewTest(builder);
                this.test = builder.PrintTest();
                Test.Visibility = Visibility.Visible;
                ConcreteAggregate concreteAggregate = new ConcreteAggregate();
                concreteAggregate.AddQuestions(test.questionChooseStrategy.GetQuestions("single", test.level.Nubmer));
                iterator = concreteAggregate.CreateIterator(random.Next(3));

                if (iterator.HasNext())
                {
                    Question question = iterator.Next();

                    if (way == "pol->ang")
                    {
                        question = new HintPolish(question, Database.GetPolishHint(question.ID));
                        Polish.ToolTip = (question as HintPolish).GetHint();
                    }
                    else
                    {
                        question.ChangeSolvingWay();
                        question = new HintEnglish(question, Database.GetEnglishHint(question.ID));
                        Polish.ToolTip = (question as HintEnglish).GetHint();
                    }

                    if (way == "pol->ang")
                        (iterator.Current() as CloseQuestion).GetWrongAnswers(false, test.level.Nubmer + 1, test.level.Nubmer);
                    else
                        (iterator.Current() as CloseQuestion).GetWrongAnswers(true, test.level.Nubmer + 1, test.level.Nubmer);
                    PopulateClosedAnswers((iterator.Current() as CloseQuestion).wrongAnswers);
                    Polish.Content = question.question;
                }
            }
        }

        private void Skill_Checked(object sender, RoutedEventArgs e)
        {
            skill = (sender as RadioButton).Content.ToString();
        }

        private void Type_Checked(object sender, RoutedEventArgs e)
        {
            type = (sender as RadioButton).Content.ToString();
        }

        private void Way_Checked(object sender, RoutedEventArgs e)
        {
            way = (sender as RadioButton).Content.ToString();
        }

        private void Strategy_Checked(object sender, RoutedEventArgs e)
        {
            strategy = (sender as RadioButton).Tag.ToString();
        }

        private void PopulateClosedAnswers(List<string> list)
        {
            Options.Children.Clear();
            Random random = new Random();
            list.Insert(random.Next(0, list.Count), iterator.Current().answer);
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
            if (iterator.Current().CheckAnswer(selected_closed))
                test.IncreasePoints();

            if (iterator.HasNext())
            {
                Question question = iterator.Next();
                if (way == "pol->ang")
                    question = new HintPolish(question, Database.GetPolishHint(question.ID));
                else
                {
                    question.ChangeSolvingWay();
                    question = new HintEnglish(question, Database.GetEnglishHint(question.ID));
                }
                //sprawdzić czy działa
                Polish.ToolTip = (question as Hint).GetHint();
                Polish.Content = question.question;
                if (way == "pol->ang")
                    (iterator.Current() as CloseQuestion).GetWrongAnswers(false, test.level.Nubmer + 1, test.level.Nubmer);
                else
                    (iterator.Current() as CloseQuestion).GetWrongAnswers(true, test.level.Nubmer + 1, test.level.Nubmer); PopulateClosedAnswers((iterator.Current() as CloseQuestion).wrongAnswers);
                Polish.Content = question.question;
            }
            else
            {
                MessageBox.Show(test.GetResult().ToString() + " / 10", "Wynik testu");
                Database.SaveHistory(user.GetID(), test.ToString());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Pages.MainMenu());
        }

        private void AnswerOpen_Click(object sender, RoutedEventArgs e)
        {
            if (iterator.Current().CheckAnswer(Answer_Eng.Text))
                test.IncreasePoints();

            if (iterator.HasNext())
            {

                Question question = iterator.Next();
                if (way == "pol->ang")
                    question = new HintPolish(question, Database.GetPolishHint(question.ID));
                else
                {
                    question = new HintEnglish(question, Database.GetEnglishHint(question.ID));
                    question.ChangeSolvingWay();
                }
                //sprawdzić czy działa
                Polish.ToolTip = (question as Hint).GetHint();
                Polish.Content = question.question;
                PolishOpen.Content = question.question;
                Answer_Eng.Text = String.Empty;
            }
            else
            {
                MessageBox.Show(test.GetResult().ToString() + " / 10", "Wynik testu");
                Database.SaveHistory(user.GetID(), test.ToString());
            }
        }
    }
}
