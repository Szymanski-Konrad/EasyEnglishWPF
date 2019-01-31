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
        private string way = "pol->ang";
        public Test test;

        private bool canNext = false;
        private IIterator iterator;

        public StudyModeWindow(ref User user)
        {
            InitializeComponent();
            user.CreateTest("open", "random");
            test = user.GetTest();

            ConcreteAggregate concreteAggregate = new ConcreteAggregate();
            concreteAggregate.AddQuestions(test.questionChooseStrategy.GetQuestions("write"));
            iterator = concreteAggregate.CreateIterator(3);

            if (iterator.HasNext())
            {
                Question question = (Question)iterator.Next();
                question = new ShortHint(question, Database.GetSimpleHint(question.ID));
                questionLabel.ToolTip = (question as ShortHint).GetHint();
                if (way == "pol->ang")
                {
                    questionLabel.Content = question.question;
                }
                else
                {
                    questionLabel.Content = question.answer;
                }
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
            if (way == "pol->ang")
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
            else if (way == "ang->pol")
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
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (canNext)
            {
                answerBox.Text = String.Empty;
                if (iterator.HasNext())
                {
                    Question question = (Question)iterator.Next();
                    question = new ShortHint(question, Database.GetSimpleHint(question.ID));
                    questionLabel.ToolTip = (question as ShortHint).GetHint();
                    if (way == "pol->ang")
                    {
                        questionLabel.Content = question.question;
                    }
                    else
                    {
                        questionLabel.Content = question.answer;
                    }
                }
                else
                {
                    ConcreteAggregate concreteAggregate = new ConcreteAggregate();
                    concreteAggregate.AddQuestions(test.questionChooseStrategy.GetQuestions("write"));
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
                question = new ShortHint(question, Database.GetSimpleHint(question.ID));
                questionLabel.ToolTip = question.GetHint();

                if (way == "pol->ang")
                {
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
                else
                {
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
}
