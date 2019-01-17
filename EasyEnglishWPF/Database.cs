using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using EasyEnglishWPF.Classes;

namespace EasyEnglishWPF
{
    public static class Database
    {
        private static readonly SQLiteConnection connection = new SQLiteConnection("Data Source=database.s3db");

        #region UserHistory
        /// <summary>
        /// Zapisywanie historii
        /// </summary>
        /// <param name="user_id">Id użytkownika</param>
        /// <param name="test_history">Wynik testu w postaci stringa</param>
        public static void SaveHistory(string user_id, string test_history)
        {
            connection.Open();
            var command = new SQLiteCommand("insert into UserHistory (User,History) values (@user,@history)", connection);
            command.Parameters.AddWithValue("@user", user_id);
            command.Parameters.AddWithValue("@history", test_history);

            command.ExecuteNonQuery();

            connection.Close();
        }

        /// <summary>
        /// Pobieranie historii testów użytkownika
        /// </summary>
        /// <param name="user_id">ID użytkownika</param>
        /// <returns>Zwraca listę stringów, które obrazują testy</returns>
        public static List<string> LoadHistory(string user_id)
        {
            connection.Open();
            var list = new List<string>();

            var command = new SQLiteCommand("select * from UserHistory where User = @user", connection);
            command.Parameters.AddWithValue("@user", user_id);

            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                list.Add((string)reader.GetValue(2));
            }

            connection.Close();

            return list;
        }
        #endregion

        #region OpenQuestions
        public static void SaveQuestion(OpenQuestion question)
        {
            connection.Open();
            var command = new SQLiteCommand("insert into OpenQuestion (Content,Answer) values (@content,@answer)", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        //public static OpenQuestion LoadQuestion()
        //{
        //    connection.Open();
        //    var command = new SQLiteCommand("select * from OpenQuestion")
        //}

        //public static void EditQuestion(OpenQuestion question)
        //{

        //}

        //public static int QuestionsCount()
        //{

        //}
        #endregion

        #region CloseQuestions

        #endregion
    }
}
