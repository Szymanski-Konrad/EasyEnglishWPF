using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using EasyEnglishWPF.Classes;
using System.Windows;

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

        #region Questions
        public static void SaveQuestion(Question question)
        {
            connection.Open();
            var command = new SQLiteCommand("insert into Question (Polish,English) values (@pol,@eng)", connection);
            command.Parameters.AddWithValue("@pol", question.Polish);
            command.Parameters.AddWithValue("@eng", question.English);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static Question LoadQuestion(int id)
        {
            Question question = new Question();
            connection.Open();
            var command = new SQLiteCommand("select * from Question where ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                question.ID = reader.GetInt32(0);
                question.Polish = (string)reader.GetValue(1);
                question.English = (string)reader.GetValue(2);
            }

            connection.Close();
            return question;
        }

        public static void EditQuestion(Question question)
        {
            connection.Open();
            var command = new SQLiteCommand("update Question set Polish = @pol, English = @eng where ID = @id", connection);
            command.Parameters.AddWithValue("@id", question.ID);
            command.Parameters.AddWithValue("@pol", question.Polish);
            command.Parameters.AddWithValue("@eng", question.English);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static int QuestionsCount()
        {
            int items = 0;
            connection.Open();
            var command = new SQLiteCommand("select count(*) from Question", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                items = reader.GetInt32(0);
            }

            connection.Close();
            return items;
        }

        public static List<Question> LoadQuestions()
        {
            var list = new List<Question>();
            connection.Open();
            var command = new SQLiteCommand("select * from Question", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Question()
                {
                    ID = reader.GetInt32(0),
                    Polish = (string)reader.GetValue(1),
                    English = (string)reader.GetValue(2),
                });
            }

            connection.Close();

            return list;
        }

        public static void RemoveQuestion(int id)
        {
            connection.Open();
            var command = new SQLiteCommand("delete from Question where ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void SaveSimpleHint(int id, string hint)
        {
            connection.Open();
            var command = new SQLiteCommand("update Question set SimpleHint = @hint where ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@hint", hint);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void SaveBetterHint(int id, string hint)
        {
            connection.Open();
            var command = new SQLiteCommand("update Question set BetterHint = @hint where ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@hint", hint);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static string GetSimpleHint(int id)
        {
            string hint = "";
            connection.Open();
            var command = new SQLiteCommand("select SimpleHint from Question where ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                hint = reader.GetString(0);
            }

            connection.Close();

            return hint;
        }

        public static string GetBetterHint(int id)
        {
            string hint = "";
            connection.Open();
            var command = new SQLiteCommand("select BetterHint from Question where ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                hint = reader.GetString(0);
            }

            connection.Close();

            return hint;
        }

        public static int GetLastID()
        {
            int id = -1;
            connection.Open();
            var command = new SQLiteCommand("select ID from Question order by ID DESC LIMIT 1", connection);
            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                id = reader.GetInt32(0);
            }

            connection.Close();

            return id;
        }
        #endregion

        #region GetDifferent Variants of Questions from database
        public static List<Question> LoadLast()
        {
            var list = new List<Question>();
            connection.Open();
            var command = new SQLiteCommand("select * from Question order by ID DESC LIMIT 10", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Question()
                {
                    ID = reader.GetInt32(0),
                    Polish = (string)reader.GetValue(1),
                    English = (string)reader.GetValue(2),
                });
            }

            connection.Close();

            return list;
        }

        public static List<Question> LoadFirst()
        {
            var list = new List<Question>();
            connection.Open();
            var command = new SQLiteCommand("select * from Question order by ID ASC LIMIT 10", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Question()
                {
                    ID = reader.GetInt32(0),
                    Polish = (string)reader.GetValue(1),
                    English = (string)reader.GetValue(2),
                });
            }

            connection.Close();

            return list;
        }

        public static List<string> LoadFakeAnswersENG(int question_id, int number)
        {
            var list = new List<string>();
            connection.Open();
            var command = new SQLiteCommand("select English from Question where ID != @id order by random() limit @limit", connection);
            command.Parameters.AddWithValue("@id", question_id);
            command.Parameters.AddWithValue("@limit", number);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            connection.Close();

            return list;
        }

        public static List<string> LoadFakeAnswersPL(int question_id, int number)
        {
            var list = new List<string>();
            connection.Open();
            var command = new SQLiteCommand("select Polish from Question where ID != @id order by random() limit @limit", connection);
            command.Parameters.AddWithValue("@id", question_id);
            command.Parameters.AddWithValue("@limit", number);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            connection.Close();

            return list;
        }
        #endregion
    }
}
