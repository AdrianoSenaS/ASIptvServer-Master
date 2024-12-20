using System.Data.SQLite;
using System.Security.Policy;
using ASIptvServer.Api.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASIptvServer.Data.Database
{
    public class DbData: IDatabase
    {
        private readonly IDbPath _dbPath;
        public DbData(IDbPath dbPath)
        {
            _dbPath = dbPath;
        }
        public void CreateDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
            {
                connection.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS MOVIES(ID INTEGER PRIMARY KEY, IDMOVIE, IDTMB, TITLE, LOGO, CATEGORIES, OVERVIEW, URL, DATE);
                CREATE TABLE IF NOT EXISTS TV(ID INTEGER PRIMARY KEY, TITLE, LOGO, CATEGORIES, URL);
                CREATE TABLE IF NOT EXISTS CATEGORIES(ID INTEGER PRIMARY KEY, CATEGORY, SUBCATEGORY);
                CREATE TABLE IF NOT EXISTS SERIES(ID INTEGER PRIMARY KEY, IDMOVIE, IDTMB, TITLE, LOGO, CATEGORIES, OVERVIEW);
                CREATE TABLE IF NOT EXISTS SEASON(ID INTEGER PRIMARY KEY, TITLE, SEASON);
                CREATE TABLE IF NOT EXISTS EPSODIES(ID INTEGER PRIMARY KEY, TITLE, LOGO, CATEGORIES, OVERVIEW, SEASON, EPISODE, URL); ";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
    }
}
