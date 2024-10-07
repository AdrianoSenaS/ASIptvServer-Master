using System.Data;
using System.Data.SQLite;

namespace ASIptvServer.Data.Data
{
    public  class DbMovies
    {

        public static List<MovieModel> GetMovies()
        {
            List<MovieModel> movies = new List<MovieModel>();
            
            using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
            {
                connection.Open();
                string sql = "SELECT * FROM MOVIES";
                using (SQLiteCommand command= new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            movies.Add(new MovieModel(Convert.ToInt32(reader["ID"]), reader["TITLE"].ToString(), reader["LOGO"].ToString(), reader["CATEGORIES"].ToString(), reader["OVERVIEW"].ToString(), reader["url"].ToString()));
                        }
                    }
                }
            }
            return movies;
        }
        public static List<MovieModel> GetMoviesId(int id)
        {
            List<MovieModel> movies = new List<MovieModel>();

            using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
            {
                connection.Open();
                string sql = "SELECT * FROM MOVIES WHRE ID="+id;
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movies.Add(new MovieModel(Convert.ToInt32(reader["ID"]), reader["TITLE"].ToString(), reader["LOGO"].ToString(), reader["CATEGORIES"].ToString(), reader["OVERVIEW"].ToString(), reader["url"].ToString()));
                        }
                    }
                }
            }
            return movies;
        }
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
