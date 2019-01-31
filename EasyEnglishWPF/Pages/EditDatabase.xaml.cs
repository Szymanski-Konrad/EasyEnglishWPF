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
    // <summary>
    // Interaction logic for EditDatabase.xaml
    // </summary>
    public partial class EditDatabase : UserControl
    {
        private bool data_loaded = false;
        private int selected_lvl = 1;
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

            Database.EditQuestion(new OpenQuestion()
            {
                ID = (Data.SelectedItem as OpenQuestion).ID,
                question = PolishEdit.Text,
                answer = EnglishEdit.Text
            });

            int id = (Data.SelectedItem as OpenQuestion).ID;
            Database.SavePolishHint(id, PolishHintEdit.Text);
            Database.SaveEnglishHint(id, EnglishHintEdit.Text);

            PopulateListView();
        }

        private void AddToDatabase_Click(object sender, RoutedEventArgs e)
        {
            if (PolishAdd.Text == String.Empty || EnglishAdd.Text == String.Empty)
            {
                MessageBox.Show("Najpierw wypełnij pola");
                return;
            }

            Database.SaveQuestion(
               new OpenQuestion()
               {
                   question = PolishAdd.Text,
                   answer = EnglishAdd.Text,
               }, selected_lvl);

            int id = Database.GetLastID();
            Database.SavePolishHint(id, PolishHintAdd.Text);
            Database.SaveEnglishHint(id, EnglishHintAdd.Text);
            PolishAdd.Text = EnglishAdd.Text = PolishHintAdd.Text = EnglishHintAdd.Text = String.Empty;

            PopulateListView();
        }

        private void PopulateListView()
        {
            if (data_loaded)
            {
                var list = Database.LoadQuestions(selected_lvl);
                Data.ItemsSource = null;
                if (list.Count > 0)
                    Data.ItemsSource = list;
            }
        }

        private void Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Question question = (Question)Data.SelectedItem;
            if (question != null)
            {
                PolishEdit.Text = question.question;
                EnglishEdit.Text = question.answer;
                PolishHintEdit.Text = Database.GetPolishHint(question.ID);
                EnglishHintEdit.Text = Database.GetEnglishHint(question.ID);
            }
        }

        private void Data_Loaded(object sender, RoutedEventArgs e)
        {
            data_loaded = true;
            LvlCombo.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected_lvl = (sender as ComboBox).SelectedIndex + 1;
            PopulateListView();
        }
    }
}
