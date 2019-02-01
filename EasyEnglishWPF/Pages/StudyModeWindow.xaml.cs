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
    /// Interaction logic for OpeenTestWindow.xaml
    /// </summary>
    public partial class StudyModeWindow : UserControl, ISwitchable
    {
        private Random random = new Random();
        private string way = "pol->ang";
        public Test test;

        private bool canNext = false;
        private IIterator iterator;

        public StudyModeWindow(ref User user)
        {
            InitializeComponent();
            var tmp = random.Next(1, 4);
            IBuilder builder = new TestOpenBuilder(
                    tmp == 1 ? new FactoryVeryEasy() :
                    tmp == 2 ? new FactoryEasy() :
                    tmp == 3 ? new FactoryNormal() : new FactoryHard() as AbstractFactory,
                    "random");
            user.MakeNewTest(builder);
            test = builder.PrintTest();
            LvlLabel.Content = test.level.ToString();

            ConcreteAggregate concreteAggregate = new ConcreteAggregate();
            concreteAggregate.AddQuestions(test.questionChooseStrategy.GetQuestions("write", test.level.Nubmer));
            iterator = concreteAggregate.CreateIterator(3);

            if (iterator.HasNext())
            {
                Question question = (Question)iterator.Next();
                if (way == "pol->ang")
                {
                    questionLabel.Content = question.question;
                    question = new HintPolish(question, Database.GetPolishHint(question.ID));
                }
                else
                {
                    questionLabel.Content = question.answer;
                    question = new HintEnglish(question, Database.GetEnglishHint(question.ID));
                }
                questionLabel.ToolTip = (question as HintPolish).GetHint();
            }
        }
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Pages.MainMenu());
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (iterator.Current().answer == answerBox.Text)
            {
                checkBtn.Background = Brushes.Green;
                canNext = true;
            }
            else
            {
                checkBtn.Background = Brushes.Red;
                canNext = false;
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (canNext)
            {
                answerBox.Text = String.Empty;
                if (iterator.HasNext())
                {
                    Question question = (Question)iterator.Next();
                    if (way == "pol->ang")
                    {
                        questionLabel.Content = question.question;
                        question = new HintPolish(question, Database.GetPolishHint(question.ID));
                    }
                    else
                    {
                        questionLabel.Content = question.answer;
                        question = new HintEnglish(question, Database.GetEnglishHint(question.ID));
                    }
                    questionLabel.ToolTip = (question as HintPolish).GetHint();
                }
                else
                {
                    ConcreteAggregate concreteAggregate = new ConcreteAggregate();
                    concreteAggregate.AddQuestions(test.questionChooseStrategy.GetQuestions("write", test.level.Nubmer));
                    iterator = concreteAggregate.CreateIterator(3);
                }
                canNext = false;
            }
            else
            {
                MessageBox.Show("You can't go further.");
            }
            checkBtn.Background = Brushes.LightGray;
        }

        private void Way_Checked(object sender, RoutedEventArgs e)
        {
            way = (sender as RadioButton).Content.ToString();
            if (iterator != null)
            {
                Question question = (Question)iterator.Current();
                question.ChangeSolvingWay();

                if (way == "pol->ang")
                {
                    question = new HintPolish(question, Database.GetPolishHint(question.ID));
                    questionLabel.ToolTip = (question as HintPolish).GetHint();

                }

                questionLabel.Content = question.question;
                if (iterator.Current().answer == answerBox.Text)
                {
                    checkBtn.Background = Brushes.Green;
                    canNext = true;
                }
                else
                {
                    checkBtn.Background = Brushes.Red;
                    canNext = false;
                }
            }
        }
    }
}
