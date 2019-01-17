﻿using EasyEnglishWPF.Classes;
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
        public Test test;

        private bool canNext = false;
        private IIterator iterator;

        public StudyModeWindow(ref User user)
        {
            InitializeComponent();
            user.CreateTest("open", "last");
            test = user.GetTest();

            ConcreteAggregate concreteAggregate = new ConcreteAggregate();
            concreteAggregate.AddQuestions(test.questionChooseStrategy.GetQuestions());
            iterator = concreteAggregate.CreateStandardIterator();

            if (iterator.HasNext())
            {
                Question question = (Question)iterator.Next();
                questionLabel.Content = question.Polish;
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
            if (iterator.Current().English == answerBox.Text)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (canNext)
            {
                if (iterator.HasNext())
                {
                    Question question = (Question)iterator.Next();
                    questionLabel.Content = question.Polish;
                }
                else
                {
                    MessageBox.Show("This is the end of your training.");
                }
                canNext = false;
            }
            else
            {
                MessageBox.Show("You can't go further.");
            }
            checkBtn.Background = Brushes.LightGray;
        }
    }
}
