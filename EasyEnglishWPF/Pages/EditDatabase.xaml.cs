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
using EasyEnglishWPF.Classes;

namespace EasyEnglishWPF.Pages
{
    /// <summary>
    /// Interaction logic for EditDatabase.xaml
    /// </summary>
    public partial class EditDatabase : UserControl
    {
        private bool data_loaded = false;
        private int mode_selected = -1;

        public EditDatabase()
        {
            InitializeComponent();
            PopulateListView();
        }

        #region OptionButtons
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ActionLabel.Content = "Dodawanie";
            Add.Visibility = Visibility.Visible;
            Remove.Visibility = Visibility.Collapsed;
            Edit.Visibility = Visibility.Collapsed;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ActionLabel.Content = "Edytowanie";
            Add.Visibility = Visibility.Collapsed;
            Remove.Visibility = Visibility.Collapsed;
            Edit.Visibility = Visibility.Visible;
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            ActionLabel.Content = "Usuwanie";
            Add.Visibility = Visibility.Collapsed;
            Remove.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Collapsed;
        }
        #endregion

        private void RemoveFromDatabase_Click(object sender, RoutedEventArgs e)
        {
            if (mode_selected == 1)
                Database.RemoveCloseQuestion((Data.SelectedItem as Question).ID);
            else if (mode_selected == 0)
                Database.RemoveOpenQuestion((Data.SelectedItem as Question).ID);
            PopulateListView();
        }

        private void EditDatabase_Click(object sender, RoutedEventArgs e)
        {
            if (ContentEdit.Text == String.Empty && AnswerEdit.Text == String.Empty)
            {
                MessageBox.Show("Najpierw wypełnij pola");
                return;
            }

            if (mode_selected == 1)
            {
                Database.EditCloseQuestion(new CloseQuestion()
                {
                    ID = (Data.SelectedItem as Question).ID,
                    Content = ContentEdit.Text,
                    Correct = AnswerEdit.Text
                });
            }
            else if (mode_selected == 0)
            {
                Database.EditOpenQuestion(new OpenQuestion()
                {
                    ID = (Data.SelectedItem as Question).ID,
                    Content = ContentEdit.Text,
                    Correct = AnswerEdit.Text
                });
            }

            PopulateListView();
            ContentEdit.Text = AnswerEdit.Text = String.Empty;
        }

        private void AddToDatabase_Click(object sender, RoutedEventArgs e)
        {
            if (ContentAdd.Text == String.Empty || AnswerAdd.Text == String.Empty)
            {
                MessageBox.Show("Najpierw wypełnij pola");
                return;
            }

            if (ModeCombo.SelectedIndex == 0) //otwarte
            {
                Database.SaveOpenQuestion(
                    new OpenQuestion()
                    {
                        Content = ContentAdd.Text,
                        Correct = AnswerAdd.Text,
                    });
                ContentAdd.Text = AnswerAdd.Text = String.Empty;
            }
            else if (ModeCombo.SelectedIndex == 1) //zamkniete
            {
                Database.SaveCloseQuestion(
                   new CloseQuestion()
                   {
                       Content = ContentAdd.Text,
                       Correct = AnswerAdd.Text,
                   });
                ContentAdd.Text = AnswerAdd.Text = String.Empty;
            }

            PopulateListView();
        }

        private void PopulateListView()
        {
            if (ModeCombo.SelectedIndex == 0)
            {
                var list = Database.LoadOpenQuestions();
                Data.ItemsSource = list;

            }
            else if (ModeCombo.SelectedIndex == 1)
            {
                var list = Database.LoadCloseQuestions();
                Data.ItemsSource = list;
            }
        }

        private void ModeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (data_loaded)
                PopulateListView();
        }

        private void Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mode_selected = ModeCombo.SelectedIndex;
            Question question = (Question)Data.SelectedItem;
            if (question != null)
            {
                ContentEdit.Text = question.Content;
                AnswerEdit.Text = question.Correct;
            }
        }

        private void Data_Loaded(object sender, RoutedEventArgs e)
        {
            data_loaded = true;
        }
    }
}
