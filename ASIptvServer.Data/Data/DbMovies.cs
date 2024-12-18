using System.Data.SQLite;
using ASIptvServer.Data.Database;
using ASIptvServer.Api.Models;
using ASIptvServer.Api.Interfaces;

namespace ASIptvServer.Data.Data
{
    public class DbMovies : IMovieService
    {
        private readonly IDbPath _dbPath;
        public DbMovies(IDbPath dbPath)
        {
            _dbPath = dbPath;
        }
        public List<MovieModel> GetMovies()
        {
            try
            {
                List<MovieModel> movies = new List<MovieModel>();
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(Sql.SelectMovies, connection))
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
        public List<MovieModel> GetMoviesId(int id)
        {
            try
            {
                List<MovieModel> movies = new List<MovieModel>();
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(Sql.SelectMoviesId, connection))
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
        public void SetMovies(MovieModel movie)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(Sql.InsertMovies, connection))
                    {
                        command.Parameters.AddWithValue("@ID", movie.Id);
                        command.Parameters.AddWithValue("@TITLE", movie.Title);
                        command.Parameters.AddWithValue("@LOGO", movie.Logo);
                        command.Parameters.AddWithValue("@CATEGORIES", movie.Categories);
                        command.Parameters.AddWithValue("OVERVIEW", movie.Overview);
                        command.Parameters.AddWithValue("@URL", movie.Url);
                        command.Parameters.AddWithValue("@DATE", movie.Date);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<CategoriesModel> GetCategoryMovies()
        {
            try
            {
                List<CategoriesModel> categories = new List<CategoriesModel>();
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(Sql.SelectSubCategoriesMovies, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new CategoriesModel()
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
        public  List<MovieModel> GetCategoryMoviesId(string category)
        {
            try
            {
                List<MovieModel> movies = new List<MovieModel>();
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(Sql.SelectCategoriesMovies, connection))
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
        public void SetCategoryMovies(CategoriesModel category)
        {
            try
            {
                using (SQLiteConnection connections = new SQLiteConnection(_dbPath.Local()))
                {
                    connections.Open();
                    using (SQLiteCommand commands = new SQLiteCommand(Sql.SelectCategoriesCount, connections))
                    {
                        commands.Parameters.AddWithValue("@CATEGORY", category.Category);
                        var count = Convert.ToInt32(commands.ExecuteScalar());
                        if (count == 0)
                        {
                            using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                            {
                                connection.Open();
                                using (SQLiteCommand command = new SQLiteCommand(Sql.InsertMoviesCategories, connection))
                                {
                                    command.Parameters.AddWithValue("@CATEGORY", category.Category);
                                    command.Parameters.AddWithValue("@SUBCATEGORY", "Movies");
                                    command.ExecuteNonQuery();
                                }
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
