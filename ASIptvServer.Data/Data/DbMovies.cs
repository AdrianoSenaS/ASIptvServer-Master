using System.Data.SQLite;

namespace ASIptvServer.Data.Data
{
    public  class DbMovies
    {
        public static void SetMovies(string Title, string Logo, string Categories, string Overview, string url)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
            {
                connection.Open();
                string sql = "INSERT INTO MOVIES (TITLE, LOGO, CATEGORIES, OVERVIEW, URL)VALUES(@TITLE, @LOGO, @CATEGORIES, @OVERVIEW, @URL)";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TITLE", Title);
                    command.Parameters.AddWithValue("@LOGO", Logo);
                    command.Parameters.AddWithValue("@CATEGORIES", Categories);
                    command.Parameters.AddWithValue("OVERVIEW",Overview);
                    command.Parameters.AddWithValue("url", url);  
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
