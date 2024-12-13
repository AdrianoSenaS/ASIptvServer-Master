namespace ASIptvServer.Data.Database
{
    public class Sql
    {
        //variaveis sql de filmes
        public static string SelectMovies = "SELECT * FROM MOVIES";
        public static string SelectMoviesId = "SELECT * FROM MOVIES WHERE ID=@ID";
        public static string SelectMoviesCount = "SELECT COUNT(1) FROM MOVIES WHERE TITLE = @TITLE";
        public static string InsertMovies = "INSERT INTO MOVIES (TITLE, LOGO, CATEGORIES, OVERVIEW, URL, DATE)VALUES(@TITLE, @LOGO, @CATEGORIES, @OVERVIEW, @URL, @DATE)";
        public static string SelectSubCategoriesMovies = "SELECT * FROM CATEGORIES WHERE SUBCATEGORY = 'Movies'";
        public static string SelectCategoriesMovies = "SELECT * FROM MOVIES WHERE CATEGORIES = @CATEGORIES ";
        public static string SelectCategoriesCount = "SELECT COUNT(1) FROM CATEGORIES WHERE CATEGORY = @CATEGORY";
        public static string InsertMoviesCategories = "INSERT INTO CATEGORIES (CATEGORY, SUBCATEGORY) VALUES(@CATEGORY, @SUBCATEGORY)";
        
        //Variaveis Sql para Tv
        public static string SelectTV = "SELECT * FROM TV";
        public static string SelectTVid = "SELECT * FROM TV WHERE ID=@ID";
        public static string SelectTVCount = "SELECT COUNT(1) FROM TV WHERE TITLE = @TITLE";
        public static string InsertTV = "INSERT INTO TV (TITLE, LOGO, CATEGORIES, URL) VALUES (@TITLE, @LOGO, @CATEGORIES, @URL)";
        public static string SelectSubCategoriesTV = "SELECT * FROM CATEGORIES WHERE SUBCATEGORY = 'Tv'";
        public static string SelectCategoriesTV = "SELECT * FROM TV WHERE CATEGORIES=@CATEGORIES";
        public static string SelectCategoriesTVCount = "SELECT COUNT(1) FROM CATEGORIES WHERE CATEGORY = @CATEGORY ";
        public static string InsertCategoriesTV = "INSERT INTO CATEGORIES (CATEGORY, SUBCATEGORY) VALUES (@CATEGORY, @SUBCATEGORY)";
    }
}
