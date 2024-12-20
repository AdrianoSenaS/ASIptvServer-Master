using System.Data.SQLite;
using ASIptvServer.Data.Database;
using ASIptvServer.Api.Interfaces;
using ASIptvServer.Api.Models;

namespace ASIptvServer.Data.Data
{
    public class DbSeries : ISeriesService
    {
        private readonly IDbPath _dbPath;
        public DbSeries(IDbPath dbPath)
        {
            _dbPath = dbPath;
        }
        public List<SeriesModel> GetSeries()
        {
            List<SeriesModel> seriesModels = new List<SeriesModel>();
            using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(Sql.SelectSeries, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            seriesModels.Add(new SeriesModel() 
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Logo = reader.GetString(2),
                                Categories = reader.GetString(3),
                                Overview = reader.GetString(4),
                            });
                        }
                    }
                }
                connection.Close();
            }
            return seriesModels;
        }
        public SeriesModel GetDbSeriesId(int id)
        {
            SeriesModel seriesModels = new SeriesModel();
            using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(Sql.SelectSeriesID, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            seriesModels.Id = reader.GetInt32(0);
                            seriesModels.Title = reader.GetString(1);
                            seriesModels.Logo = reader.GetString(2);
                            seriesModels.Categories = reader.GetString(3);
                            seriesModels.Overview = reader.GetString(4);
                        }
                    }
                }
                connection.Close();
            }
            return seriesModels;
        }
        public void SetSeries(SeriesModel series)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(Sql.SelectSeriesCount, connection))
                    {
                        command.Parameters.AddWithValue("@TITLE", series.Title);
                        var count = Convert.ToInt32(command.ExecuteScalar());
                        if (count == 0)
                        {
                            using (SQLiteCommand command1 = new SQLiteCommand(Sql.InsertSeries, connection))
                            {
                                command1.Parameters.AddWithValue("@TITLE", series.Title);
                                command1.Parameters.AddWithValue("@LOGO", series.Logo);
                                command1.Parameters.AddWithValue("@CATEGORIES", series.Categories);
                                command1.Parameters.AddWithValue("@OVERVIEW", series.Overview);
                                command1.ExecuteNonQuery();
                            }
                        }
                    }
                    connection.Close();
                };
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<CategoriesModel> GetCateoriesSeries()
        {
            try
            {
                List<CategoriesModel> categories = new List<CategoriesModel>();
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(Sql.SelectSubcategoriesSeries, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new CategoriesModel
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<SeriesModel> GetCategoriesSeriesId(string category)
        {
            try
            {
                List<SeriesModel> series = new List<SeriesModel>();
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(Sql.SelectCategoriesSeries, connection))
                    {
                        command.Parameters.AddWithValue("@CATEGORIES", category);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                series.Add(new SeriesModel
                                {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Logo = reader.GetString(2),
                                    Categories = reader.GetString(3),
                                    Overview = reader.GetString(4),
                                });
                            }
                        }
                    }
                    connection.Close();
                }
                return series;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SetCategorySeries(CategoriesModel category)
        {
            try
            {
                using (SQLiteConnection connections = new SQLiteConnection(_dbPath.Local()))
                {
                    connections.Open();
                    using (SQLiteCommand commands = new SQLiteCommand(Sql.SelectCategoriesCountSeries, connections))
                    {
                        commands.Parameters.AddWithValue("@CATEGORY", category.Category);
                        var count = Convert.ToInt32(commands.ExecuteScalar());
                        if (count == 0)
                        {
                            using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                            {
                                connection.Open();
                                using (SQLiteCommand command = new SQLiteCommand(Sql.InsertCategoriesSeries, connection))
                                {
                                    command.Parameters.AddWithValue("@CATEGORY", category.Category);
                                    command.Parameters.AddWithValue("@SUBCATEGORY", "Series");
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    connections.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
