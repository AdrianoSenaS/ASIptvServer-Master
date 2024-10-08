using System.Data.SQLite;

namespace ASIptvServer.Data.Data
{
    public class DbMovies
    {

        public static List<MovieModel> GetMovies()
        {
            List<MovieModel> movies = new List<MovieModel>();

            using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
            {
                connection.Open();
                string sql = "SELECT * FROM MOVIES";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movies.Add(new MovieModel(Convert.ToInt32(reader["ID"]), reader["TITLE"].ToString(), reader["LOGO"].ToString(), reader["CATEGORIES"].ToString(), reader["OVERVIEW"].ToString(), reader["URL"].ToString(), reader["DATE"].ToString()));
                        }
                    }
                }
                connection.Close();
            }
            return movies;
        }
        public static List<MovieModel> GetMoviesId(int id)
        {
            List<MovieModel> movies = new List<MovieModel>();

            using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
            {
                connection.Open();
                string sql = "SELECT * FROM MOVIES WHERE ID=" + id;
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movies.Add(new MovieModel(Convert.ToInt32(reader["ID"]), reader["TITLE"].ToString(), reader["LOGO"].ToString(), reader["CATEGORIES"].ToString(), reader["OVERVIEW"].ToString(), reader["URL"].ToString(), reader["DATE"].ToString()));
                        }
                    }
                }
                connection.Close();
            }
            return movies;
        }
        public static void SetMovies(string Title, string Logo, string Categories, string Overview, string url, string date)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
            {
                connection.Open();
                string sql = "SELECT * FROM MOVIES WHERE URL='"+url+"'";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            if (url != reader["URL"].ToString() || reader["URL"].ToString() == null)
                            {
                               var sql1 = "INSERT INTO MOVIES (TITLE, LOGO, CATEGORIES, OVERVIEW, URL, DATE)VALUES(@TITLE, @LOGO, @CATEGORIES, @OVERVIEW, @URL, @DATE)";
                                SQLiteCommand command1 = new SQLiteCommand(sql1, connection);
                                command1.Parameters.AddWithValue("@TITLE", Title);
                                command1.Parameters.AddWithValue("@LOGO", Logo);
                                command1.Parameters.AddWithValue("@CATEGORIES", Categories);
                                command1.Parameters.AddWithValue("OVERVIEW", Overview);
                                command1.Parameters.AddWithValue("@URL", url);
                                command1.Parameters.AddWithValue("@DATE", date);
                                command1.ExecuteNonQuery();
                            }
                            else
                            {
                                Console.WriteLine("Já adicionado");
                            }
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
