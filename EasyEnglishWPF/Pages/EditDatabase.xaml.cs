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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Pages.MainMenu());
        }
        #endregion

        private void RemoveFromDatabase_Click(object sender, RoutedEventArgs e)
        {
            Database.RemoveQuestion((Data.SelectedItem as Question).ID);
            PopulateListView();
        }

        private void EditDatabase_Click(object sender, RoutedEventArgs e)
        {
            if (PolishEdit.Text == String.Empty && EnglishEdit.Text == String.Empty)
            {
                MessageBox.Show("Najpierw wypełnij pola");
                return;
            }

            //Database.EditQuestion(new Question()
            //{
            //    ID = (Data.SelectedItem as Question).ID,
            //    Polish = PolishEdit.Text,
            //    English = EnglishEdit.Text
            //});

            PopulateListView();
            PolishAdd.Text = EnglishAdd.Text = SimpleHintAdd.Text = BetterHintAdd.Text = String.Empty;
        }

        private void AddToDatabase_Click(object sender, RoutedEventArgs e)
        {
            if (PolishAdd.Text == String.Empty || EnglishAdd.Text == String.Empty)
            {
                MessageBox.Show("Najpierw wypełnij pola");
                return;
            }

            //Database.SaveQuestion(
            //   new Question()
            //   {
            //       Polish = PolishAdd.Text,
            //       English = EnglishAdd.Text,
            //   });

            //int id = Database.GetLastID();
            //Database.SaveSimpleHint(id, SimpleHintAdd.Text);
            //Database.SaveBetterHint(id, BetterHintAdd.Text);
            //PolishAdd.Text = EnglishAdd.Text = SimpleHintAdd.Text = BetterHintAdd.Text = String.Empty;

            PopulateListView();
        }

        private void PopulateListView()
        {
            //var list = Database.LoadQuestions();
            //Data.ItemsSource = list;
        }

        private void ModeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (data_loaded)
                PopulateListView();
        }

        private void Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Question question = (Question)Data.SelectedItem;
            //if (question != null)
            //{
            //    PolishEdit.Text = question.Polish;
            //    EnglishEdit.Text = question.English;
            //    SimpleHintEdit.Text = Database.GetSimpleHint(question.ID);
            //    BetterHintEdit.Text = Database.GetBetterHint(question.ID);
            //}
        }

        private void Data_Loaded(object sender, RoutedEventArgs e)
        {
            data_loaded = true;
        }
    }
}
