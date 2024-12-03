using System.Data.SQLite;

namespace ASIptvServer.Data
{
    public class DbData
    {
        public static void CreateDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
            {
                connection.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS MOVIES (ID INTEGER PRIMARY KEY, TITLE, LOGO, CATEGORIES, OVERVIEW, URL, DATE);
                                    CREATE TABLE IF NOT EXISTS TV (ID INTEGER PRIMARY KEY, TITLE, LOGO, CATEGORIES, URL);
                                    CREATE TABLE IF NOT EXISTS CATEGORIES (ID INTEGER PRIMARY KEY, CATEGORY, SUBCATEGORY);
                                    CREATE TABLE IF NOT EXISTS SERIES (ID INTEGER PRIMARY KEY, TITLE, LOGO, CATEGORIES, OVERVIEW, URL);
                                    CREATE TABLE IF NOT EXISTS EPISODESERIE (ID INTEGER PRIMARY KEY, SERIENAME, TITLE, LOGO, CATEGORIES, OVERVIEW, URL, DATE);";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
    }
}
