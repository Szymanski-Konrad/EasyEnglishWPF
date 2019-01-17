using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

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
            var list = new List<string>();

            var command = new SQLiteCommand("select * from UserHistory where User = @user", connection);
            command.Parameters.AddWithValue("@user", user_id);

            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                list.Add((string)reader.GetValue(2));
            }

            return list;
        }
        #endregion

        #region OpenQuestions

        #endregion

        #region CloseQuestions

        #endregion
    }
}
