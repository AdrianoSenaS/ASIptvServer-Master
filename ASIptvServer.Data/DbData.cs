using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIptvServer.Data
{
    public class DbData
    {
        public static void CreateDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
            {
                connection.Open();
                    string sql = @"CREATE TABLE IF NOT EXISTS MOVIES (ID INTEGER PRIMARY KEY, TITLE, LOGO, CATEGORIES, OVERVIEW, URL);
                                    CREATE TABLE IF NOT EXISTS TV (ID INTEGER PRIMARY KEY, TITLE, LOGO, CATEGORIES, OVERVIEW, URL);
                                    CREATE TABLE IF NOT EXISTS EPISODETV (ID INTEGER PRIMARY KEY, TVNAME, TITLE, LOGO, CATEGORIES, OVERVIEW, URL);
                                    CREATE TABLE IF NOT EXISTS SERIES (ID INTEGER PRIMARY KEY, TITLE, LOGO, CATEGORIES, OVERVIEW, URL);
                                    CREATE TABLE IF NOT EXISTS EPISODESERIE (ID INTEGER PRIMARY KEY, SERIENAME, TITLE, LOGO, CATEGORIES, OVERVIEW, URL);";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Tabela criada com sucesso!");
                }
                connection.Close();
            }

        }
    }
}
