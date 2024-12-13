using System.Data.SQLite;
using ASIptvServer.Data.Database;

namespace ASIptvServer.Data.Data
{
    public class DbSeries
    {
        public static List<SeriesModel> GetSeries()
        {
            List<SeriesModel> seriesModels = new List<SeriesModel>();
            using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
            {
                connection.Open();
                string sql = "SELECT * FROM SERIES";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
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
        public static List<SeriesModel> GetDbSeriesId(int id)
        {
            List<SeriesModel> seriesModels = new List<SeriesModel>();
            using (SQLiteConnection connection = new SQLiteConnection(DbPath.Local))
            {
                connection.Open();
                string sql = "SELECT * FROM SERIES WHERE ID=@ID";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("ID", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            seriesModels.Add(new SeriesModel 
                            {
                                Id= reader.GetInt32(0),
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
    }
}
