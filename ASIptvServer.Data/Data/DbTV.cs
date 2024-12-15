using System.Data.SQLite;
using ASIptvServer.Data.Database;
using ASIptvServer.Api.Interfaces;
using ASIptvServer.Models;

namespace ASIptvServer.Data.Data
{
    public class DbTV : ITvService
    {
        private readonly IDbPath _dbPath;
        public DbTV(IDbPath dbPath)
        {
            _dbPath = dbPath;
        }
        public List<TvModel> GetTv()
        {
            try
            {
                var tv = new List<TvModel>();
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(Sql.SelectTV, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tv.Add(new TvModel
                                {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Logo = reader.GetString(2),
                                    Categories = reader.GetString(3),
                                    Url = reader.GetString(4)
                                });
                            }
                        }
                    }
                    connection.Close();
                }
                    return tv;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<TvModel> GetTvId(int id) 
        {
            try
            {
                var tv = new List<TvModel>();
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(Sql.SelectTVid, connection))
                    {
                        command.Parameters.AddWithValue("ID", id);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tv.Add(new TvModel
                                {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Logo = reader.GetString(2),
                                    Categories = reader.GetString(3),
                                    Url = reader.GetString(4)
                                });
                            }
                        }
                    }
                    connection.Close();
                }
                return tv;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SetTv(TvModel tvModel)
        {
            try
            {
                using(SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand commandSearch = new SQLiteCommand(Sql.SelectTVCount, connection))
                    {
                        commandSearch.Parameters.AddWithValue("TITLE", tvModel.Title);
                        var count = Convert.ToInt32(commandSearch.ExecuteScalar());
                        if (count == 0)
                        {
                            using (SQLiteCommand command = new SQLiteCommand(Sql.InsertTV, connection))
                            {
                                command.Parameters.AddWithValue("TITLE", tvModel.Title);
                                command.Parameters.AddWithValue("LOGO", tvModel.Logo);
                                command.Parameters.AddWithValue("CATEGORIES", tvModel.Categories);
                                command.Parameters.AddWithValue("URL", tvModel.Url);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<CategoriesModel> GetCategoryTv()
        {
            try
            {
                List<CategoriesModel> categories = new List<CategoriesModel>();
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local())) 
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(Sql.SelectSubCategoriesTV, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new CategoriesModel
                                {
                                    Id = reader.GetInt32(0),
                                    Category  = reader.GetString(1),
                                    SubCatagory = reader.GetString(2)

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
        public List<TvModel> GetCategoryTvId(string category)
        {
            try
            {
                var categories = new List<TvModel>();
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(Sql.SelectCategoriesTV, connection))
                    {
                        command.Parameters.AddWithValue("CATEGORIES", category);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new TvModel
                                {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Logo = reader.GetString(2),
                                    Categories = reader.GetString(3),
                                    Url = reader.GetString(4)
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
        public void SetCategoryTv(CategoriesModel categories)
        {
            try
            {
                using (SQLiteConnection connection =new SQLiteConnection(_dbPath.Local()))
                {
                    connection.Open();
                    using (SQLiteCommand commandSearch = new SQLiteCommand(Sql.SelectCategoriesTVCount, connection))
                    {
                        commandSearch.Parameters.AddWithValue("CATEGORY", categories.Category);
                        var count = Convert.ToInt32(commandSearch.ExecuteScalar());
                        if (count == 0)
                        {
                            using (SQLiteCommand command = new SQLiteCommand(Sql.InsertCategoriesTV, connection))
                            {
                                command.Parameters.AddWithValue("CATEGORY", categories.Category);
                                command.Parameters.AddWithValue("SUBCATEGORY", "Tv");
                                command.ExecuteNonQuery();
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
    }
}
