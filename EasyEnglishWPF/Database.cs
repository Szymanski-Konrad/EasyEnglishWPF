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
        public static void SaveQuestion(Question question, int lvl)
        {
            connection.Open();
            var command = new SQLiteCommand("insert into Question (question,answer, level) values (@pol,@eng,@lvl)", connection);
            command.Parameters.AddWithValue("@pol", question.question);
            command.Parameters.AddWithValue("@eng", question.answer);
            command.Parameters.AddWithValue("@lvl", lvl);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static Question LoadQuestion(int id, string question_type)
        {
            Question question;
            if (question_type == "open")
                question = new OpenQuestion();
            else
                question = new CloseQuestion();

            connection.Open();
            var command = new SQLiteCommand("select * from Question where ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                question.ID = reader.GetInt32(0);
                question.question = (string)reader.GetValue(1);
                question.answer = (string)reader.GetValue(2);
            }

            connection.Close();
            return question;
        }

        public static void EditQuestion(Question question)
        {
            connection.Open();
            var command = new SQLiteCommand("update Question set question = @pol, answer = @eng where ID = @id", connection);
            command.Parameters.AddWithValue("@id", question.ID);
            command.Parameters.AddWithValue("@pol", question.question);
            command.Parameters.AddWithValue("@eng", question.answer);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static List<Question> LoadQuestions(int lvl)
        {
            var list = new List<Question>();
            connection.Open();
            var command = new SQLiteCommand("select * from Question where level = @lvl", connection);
            command.Parameters.AddWithValue("@lvl", lvl);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new OpenQuestion()
                {
                    ID = reader.GetInt32(0),
                    question = (string)reader.GetValue(1),
                    answer = (string)reader.GetValue(2),
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

        public static void SavePolishHint(int id, string hint)
        {
            connection.Open();
            var command = new SQLiteCommand("update Question set polishhint = @hint where ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@hint", hint);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void SaveEnglishHint(int id, string hint)
        {
            connection.Open();
            var command = new SQLiteCommand("update Question set englishhint = @hint where ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@hint", hint);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static string GetPolishHint(int id)
        {
            string hint = "";
            connection.Open();
            var command = new SQLiteCommand("select polishhint from Question where ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                hint = reader.GetString(0);
            }

            connection.Close();

            return hint;
        }

        public static string GetEnglishHint(int id)
        {
            string hint = "";
            connection.Open();
            var command = new SQLiteCommand("select englishhint from Question where ID = @id", connection);
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
        public static List<Question> LoadTenQuestions(string variant, string question_type, int lvl)
        {
            var list = new List<Question>();
            connection.Open();
            SQLiteCommand command;
            switch (variant)
            {
                case "first": command = new SQLiteCommand("select * from Question where level = @lvl order by ID DESC LIMIT 10", connection); break;
                case "last": command = new SQLiteCommand("select * from Question where level = @lvl order by ID DESC LIMIT 10", connection); break;
                case "random": command = new SQLiteCommand("select * from Question where level = @lvl order by random() limit 10", connection); break;
                default: command = new SQLiteCommand("select * from Question where level = @lvl order by random() limit 10", connection); break;
            }
            command.Parameters.AddWithValue("@lvl", lvl);
            var reader = command.ExecuteReader();
            if (question_type == "open")
            {
                while (reader.Read())
                {
                    list.Add(new OpenQuestion()
                    {
                        ID = reader.GetInt32(0),
                        question = (string)reader.GetValue(1),
                        answer = (string)reader.GetValue(2),
                    });
                }
            }
            else
            {
                while (reader.Read())
                {
                    list.Add(new CloseQuestion()
                    {
                        ID = reader.GetInt32(0),
                        question = (string)reader.GetValue(1),
                        answer = (string)reader.GetValue(2),
                    });
                }
            }

            connection.Close();

            return list;

        }

        public static List<string> LoadFakeAnswersENG(int question_id, int number, int lvl)
        {
            var list = new List<string>();
            connection.Open();
            var command = new SQLiteCommand("select answer from Question where ID != @id and level = @lvl order by random() limit @limit", connection);
            command.Parameters.AddWithValue("@id", question_id);
            command.Parameters.AddWithValue("@limit", number);
            command.Parameters.AddWithValue("@lvl", lvl);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            connection.Close();

            return list;
        }

        public static List<string> LoadFakeAnswersPL(int question_id, int number, int lvl)
        {
            var list = new List<string>();
            connection.Open();
            var command = new SQLiteCommand("select question from Question where ID != @id and level = @lvl order by random() limit @limit", connection);
            command.Parameters.AddWithValue("@id", question_id);
            command.Parameters.AddWithValue("@limit", number);
            command.Parameters.AddWithValue("@lvl", lvl);
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
