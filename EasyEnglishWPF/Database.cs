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
        public static void SaveOpenQuestion(OpenQuestion question)
        {
            connection.Open();
            var command = new SQLiteCommand("insert into OpenQuestion (Content,Answer) values (@content,@answer)", connection);
            command.Parameters.AddWithValue("@content", question.Content);
            command.Parameters.AddWithValue("@answer", question.Correct);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static OpenQuestion LoadOpenQuestion(int id)
        {
            OpenQuestion question = new OpenQuestion();
            connection.Open();
            var command = new SQLiteCommand("select * from OpenQuestion where ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                question.ID = (int)reader.GetValue(0);
                question.Content = (string)reader.GetValue(1);
                question.Correct = (string)reader.GetValue(2);
            }

            connection.Close();
            return question;
        }

        public static void EditOpenQuestion(OpenQuestion question)
        {
            connection.Open();
            var command = new SQLiteCommand("update OpenQuestion set Content = @content, Answer = @answer where ID = @id", connection);
            command.Parameters.AddWithValue("@id", question.ID);
            command.Parameters.AddWithValue("@content", question.Content);
            command.Parameters.AddWithValue("@answer", question.Correct);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static int OpenQuestionsCount()
        {
            int items = 0;
            connection.Open();
            var command = new SQLiteCommand("select count(*) from OpenQuestion", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                items = (int)reader.GetValue(0);
            }

            connection.Close();
            return items;
        }

        public static List<OpenQuestion> LoadOpenQuestions()
        {
            var list = new List<OpenQuestion>();
            connection.Open();
            var command = new SQLiteCommand("select * from OpenQuestion", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new OpenQuestion()
                {
                    ID = (int)reader.GetValue(0),
                    Content = (string)reader.GetValue(1),
                    Correct = (string)reader.GetValue(2),
                });
            }

            connection.Close();

            return list;
        }
        #endregion

        #region CloseQuestions
        public static void SaveCloseQuestion(CloseQuestion question)
        {
            connection.Open();
            var command = new SQLiteCommand("insert into CloseQuestion (Content,Answer) values (@content,@answer)", connection);
            command.Parameters.AddWithValue("@content", question.Content);
            command.Parameters.AddWithValue("@answer", question.Correct);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static CloseQuestion LoadCloseQuestion(int id)
        {
            CloseQuestion question = new CloseQuestion();
            connection.Open();
            var command = new SQLiteCommand("select * from CloseQuestion where ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                question.ID = (int)reader.GetValue(0);
                question.Content = (string)reader.GetValue(1);
                question.Correct = (string)reader.GetValue(2);
            }

            connection.Close();
            return question;
        }

        public static void EditCloseQuestion(CloseQuestion question)
        {
            connection.Open();
            var command = new SQLiteCommand("update CloseQuestion set Content = @content, Answer = @answer where ID = @id", connection);
            command.Parameters.AddWithValue("@id", question.ID);
            command.Parameters.AddWithValue("@content", question.Content);
            command.Parameters.AddWithValue("@answer", question.Correct);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static int CloseQuestionsCount()
        {
            int items = 0;
            connection.Open();
            var command = new SQLiteCommand("select count(*) from CloseQuestion", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                items = (int)reader.GetValue(0);
            }

            connection.Close();
            return items;
        }

        public static List<CloseQuestion> LoadCloseQuestions()
        {
            var list = new List<CloseQuestion>();
            connection.Open();
            var command = new SQLiteCommand("select * from CloseQuestion", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new CloseQuestion()
                {
                    ID = (int)reader.GetValue(0),
                    Content = (string)reader.GetValue(1),
                    Correct = (string)reader.GetValue(2),
                });
            }

            connection.Close();

            return list;
        }
        #endregion
    }
}
