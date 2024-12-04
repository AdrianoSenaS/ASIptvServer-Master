using System.Data.SQLite;

namespace ASIptvServer.Data.Data
{
    public class DbTV
    {
        public static List<TvModel> GetTv()
        {
            try
            {
                var tv = new List<TvModel>();
                using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
                {
                    connection.Open();
                    string sql = "SELECT * FROM TV";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
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
        public static List<TvModel> GetTvId(int id) 

        {
            try
            {
                var tv = new List<TvModel>();
                using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
                {
                    connection.Open();
                    string sql = "SELECT * FROM TV WHERE ID=@ID";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
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
        public static void SetTv(TvModel tvModel)
        {
            try
            {
                using(SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
                {
                    connection.Open();
                    string sqlSearch = "SELECT COUNT(1) FROM TV WHERE TITLE = @TITLE";
                    using (SQLiteCommand commandSearch = new SQLiteCommand(sqlSearch, connection))
                    {
                        commandSearch.Parameters.AddWithValue("TITLE", tvModel.Title);
                        var count = Convert.ToInt32(commandSearch.ExecuteScalar());
                        if (count == 0)
                        {
                            var sql = "INSERT INTO TV (TITLE, LOGO, CATEGORIES, URL) VALUES (@TITLE, @LOGO, @CATEGORIES, @URL)";
                            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
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
        public static List<Categories> GetCategoryTv()
        {
            try
            {
                List<Categories> categories = new List<Categories>();
                using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local)) 
                {
                    connection.Open();
                    string sql = "SELECT * FROM CATEGORIES WHERE SUBCATEGORY = 'Tv'";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new Categories
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
        public static List<TvModel> GetCategoryTvId(string category)
        {
            try
            {
                var categories = new List<TvModel>();
                using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
                {
                    connection.Open();
                    string sql = "SELECT * FROM TV WHERE CATEGORIES=@CATEGORIES";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
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
        public static void SetCategoryTv(Categories categories)
        {
            try
            {
                string sqlSearch = "SELECT COUNT(1) FROM CATEGORIES WHERE CATEGORY = @CATEGORY ";
                using (SQLiteConnection connection =new SQLiteConnection(DbPath.Local))
                {
                    connection.Open();
                    using (SQLiteCommand commandSearch = new SQLiteCommand(sqlSearch, connection))
                    {
                        commandSearch.Parameters.AddWithValue("CATEGORY", categories.Category);
                        var count = Convert.ToInt32(commandSearch.ExecuteScalar());
                        if (count == 0)
                        {
                            string sql = "INSERT INTO CATEGORIES (CATEGORY, SUBCATEGORY) VALUES (@CATEGORY, @SUBCATEGORY)";
                            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
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
