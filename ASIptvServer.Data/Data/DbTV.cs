using System.Data.SQLite;

namespace ASIptvServer.Data.Data
{
    public class DbTV
    {
        public static List<TvModel> GetTvs()
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
    }
}
