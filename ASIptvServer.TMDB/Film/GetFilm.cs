using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIptvServer.TMDB
{
    public  class GetFilm
    {
        public static List<Film> film= new List<Film>();
        public static ApiHeaders apiHeaders = new ApiHeaders();
        public static List<Film> GetFilms()
        {
            try
            {


                return film;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
