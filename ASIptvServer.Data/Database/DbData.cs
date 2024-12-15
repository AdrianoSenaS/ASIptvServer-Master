using System.Data.SQLite;
using ASIptvServer.Api.Interfaces;

namespace ASIptvServer.Data.Database
{
    public class DbData: IDatabase
    {
        public void CreateDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
            {
                connection.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS MOVIES (ID INTEGER PRIMARY KEY, TITLE, LOGO, CATEGORIES, OVERVIEW, URL, DATE);
                                    CREATE TABLE IF NOT EXISTS TV (ID INTEGER PRIMARY KEY, TITLE, LOGO, CATEGORIES, URL);
                                    CREATE TABLE IF NOT EXISTS CATEGORIES (ID INTEGER PRIMARY KEY, CATEGORY, SUBCATEGORY);
                                    CREATE TABLE IF NOT EXISTS SERIES (ID INTEGER PRIMARY KEY, TITLE, LOGO, CATEGORIES, OVERVIEW);
                                    CREATE TABLE IF NOT EXISTS SEASON (ID INTEGER PRIMARY KEY, TITLE, SEASON);
                                    CREATE TABLE IF NOT EXISTS EPSODIES (ID INTEGER PRIMARY KEY, TITLE, LOGO, CATEGORIES, OVERVIEW, SEASON, EPISODE, URL);";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
    }
}
