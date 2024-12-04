using System;
using System.Data.SQLite;

namespace ASIptvServer.Data.Data
{
    public class DbMovies
    {
        public static List<MovieModel> GetMovies()
        {
            try
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
                                movies.Add(new MovieModel()
                                {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Logo = reader.GetString(2),
                                    Categories = reader.GetString(3),
                                    Overview = reader.GetString(4),
                                    Url = reader.GetString(5),
                                    Date = reader.GetString(6)
                                });
                            }
                        }
                    }
                    connection.Close();
                }
                return movies;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<MovieModel> GetMoviesId(int id)
        {
            try
            {
                List<MovieModel> movies = new List<MovieModel>();
                using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
                {
                    connection.Open();
                    string sql = "SELECT * FROM MOVIES WHERE ID=@ID";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                movies.Add(new MovieModel()
                                {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Logo = reader.GetString(2),
                                    Categories = reader.GetString(3),
                                    Overview = reader.GetString(4),
                                    Url = reader.GetString(5),
                                    Date = reader.GetString(6)
                                });
                            }
                        }
                    }
                    connection.Close();
                }
                return movies;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SetMovies(MovieModel movie)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
                {
                    connection.Open();
                    string sql = "SELECT COUNT(1) FROM MOVIES WHERE TITLE = @TITLE";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@TITLE", movie.Title);
                        var count = Convert.ToInt32(command.ExecuteScalar());
                        if (count == 0)
                        {
                            var sql1 = "INSERT INTO MOVIES (TITLE, LOGO, CATEGORIES, OVERVIEW, URL, DATE)VALUES(@TITLE, @LOGO, @CATEGORIES, @OVERVIEW, @URL, @DATE)";
                            using (SQLiteCommand command1 = new SQLiteCommand(sql1, connection))
                            {
                                command1.Parameters.AddWithValue("@TITLE", movie.Title);
                                command1.Parameters.AddWithValue("@LOGO", movie.Logo);
                                command1.Parameters.AddWithValue("@CATEGORIES", movie.Categories);
                                command1.Parameters.AddWithValue("OVERVIEW", movie.Overview);
                                command1.Parameters.AddWithValue("@URL", movie.Url);
                                command1.Parameters.AddWithValue("@DATE", movie.Date);
                                command1.ExecuteNonQuery();
                            }
                        }
                    }
                    connection.Close();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Categories> GetCategoryMovies()
        {
            try
            {
                List<Categories> categories = new List<Categories>();
                using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
                {
                    connection.Open();
                    string sql = "SELECT * FROM CATEGORIES WHERE SUBCATEGORY = 'Movies'";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new Categories()
                                {
                                    Id = reader.GetInt32(0),
                                    Category = reader.GetString(1),
                                    SubCatagory = reader.GetString(2),
                                });
                            }
                        }
                    }
                    connection.Close();
                }
                return categories;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<MovieModel> GetCategoryMoviesId(string category)
        {
            try
            {
                List<MovieModel> movies = new List<MovieModel>();
                using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
                {
                    connection.Open();
                    string sql = "SELECT * FROM MOVIES WHERE CATEGORIES = @CATEGORIES ";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CATEGORIES", category);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                movies.Add(new MovieModel()
                                {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Logo = reader.GetString(2),
                                    Categories = reader.GetString(3),
                                    Overview = reader.GetString(4),
                                    Url = reader.GetString(5),
                                    Date = reader.GetString(6)
                                });
                            }
                        }
                    }
                    connection.Close();
                }
                return movies;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SetCategoryMovies(Categories category)
        {
            try
            {
                string sqls = "SELECT COUNT(1) FROM CATEGORIES WHERE CATEGORY = @CATEGORY";
                using (SQLiteConnection connections = new SQLiteConnection(DbPath.Local))
                {
                    connections.Open();
                    using (SQLiteCommand commands = new SQLiteCommand(sqls, connections))
                    {
                        commands.Parameters.AddWithValue("@CATEGORY", category.Category);
                        var count = Convert.ToInt32(commands.ExecuteScalar());
                        if (count == 0)
                        {
                            string sql = "INSERT INTO CATEGORIES (CATEGORY, SUBCATEGORY) VALUES(@CATEGORY, @SUBCATEGORY)";
                            using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
                            {
                                connection.Open();
                                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                                {
                                    command.Parameters.AddWithValue("@CATEGORY", category.Category);
                                    command.Parameters.AddWithValue("@SUBCATEGORY", "Movies");
                                    command.ExecuteNonQuery();
                                }
                                connection.Close();
                            }
                        }
                    }
                    connections.Close();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
