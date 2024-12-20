using System.Data.Entity.ModelConfiguration.Configuration;

namespace ASIptvServer.Data.Database
{
    public class Sql
    {
        //variaveis sql de filmes
        public static string SelectMovies = "SELECT * FROM MOVIES";
        public static string SelectMoviesId = "SELECT * FROM MOVIES WHERE ID=@ID";
        public static string InsertMovies = "INSERT INTO MOVIES (IDMOVIE, IDTMB, TITLE, LOGO, CATEGORIES, OVERVIEW, URL, DATE)VALUES(@IDMOVIE, @IDTMB, @TITLE, @LOGO, @CATEGORIES, @OVERVIEW, @URL, @DATE)";
        public static string SelectSubCategoriesMovies = "SELECT * FROM CATEGORIES WHERE SUBCATEGORY = 'Movies'";
        public static string SelectCategoriesMovies = "SELECT * FROM MOVIES WHERE CATEGORIES = @CATEGORIES";
        public static string SelectCategoriesCount = "SELECT COUNT(1) FROM CATEGORIES WHERE CATEGORY = @CATEGORY";
        public static string InsertMoviesCategories = "INSERT INTO CATEGORIES (CATEGORY, SUBCATEGORY) VALUES(@CATEGORY, @SUBCATEGORY)";
        
        //Variaveis Sql para Tv
        public static string SelectTV = "SELECT * FROM TV";
        public static string SelectTVid = "SELECT * FROM TV WHERE ID=@ID";
        public static string InsertTV = "INSERT INTO TV (TITLE, LOGO, CATEGORIES, URL) VALUES (@TITLE, @LOGO, @CATEGORIES, @URL)";
        public static string SelectSubCategoriesTV = "SELECT * FROM CATEGORIES WHERE SUBCATEGORY = 'Tv'";
        public static string SelectCategoriesTV = "SELECT * FROM TV WHERE CATEGORIES=@CATEGORIES";
        public static string SelectCategoriesTVCount = "SELECT COUNT(1) FROM CATEGORIES WHERE CATEGORY = @CATEGORY ";
        public static string InsertCategoriesTV = "INSERT INTO CATEGORIES (CATEGORY, SUBCATEGORY) VALUES (@CATEGORY, @SUBCATEGORY)";

        //Variravies Sql para Series
        public static string SelectSeries = "SELECT * FROM SERIES";
        public static string SelectSeriesID = "SELECT * FROM SERIES WHERE ID=@ID";
        public static string SelectSeriesCount = "SELECT COUNT(1) FROM SERIES WHERE TITLE = @TITLE";
        public static string InsertSeries = "INSERT INTO SERIES (TITLE, LOGO, CATEGORIES, OVERVIEW) VALUES(@TITLE, @LOGO, @CATEGORIES, @OVERVIEW);";
        public static string SelectSubcategoriesSeries = "SELECT * FROM CATEGORIES WHERE SUBCATEGORY = 'Series'";
        public static string SelectCategoriesSeries = "SELECT * FROM SERIES WHERE CATEGORIES = @CATEGORIES ";
        public static string SelectCategoriesCountSeries = "SELECT COUNT(1) FROM CATEGORIES WHERE CATEGORY = @CATEGORY ";
        public static string InsertCategoriesSeries = "INSERT INTO CATEGORIES (CATEGORY, SUBCATEGORY) VALUES (@CATEGORY, @SUBCATEGORY)";
    }
}
