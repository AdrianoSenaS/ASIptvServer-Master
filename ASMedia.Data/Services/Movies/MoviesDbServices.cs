
using ASMedia.Data.DataDbContext;
using ASMedia.Shared.Interfaces.Movies;
using ASMedia.Shared.Model.Movies;
using Microsoft.EntityFrameworkCore;

namespace ASMedia.Data.Services.Movies
{
    public class MoviesDbServices : IMoviesRepository
    {
        private readonly AppDbContext DbContext;
        public MoviesDbServices(AppDbContext dbContext) 
        {
            DbContext = dbContext;
        }
        public async Task<string> AddMovie(MoviesResponse movies)
        {
            try
            {
                await DbContext.Movies.AddAsync(movies);
                await DbContext.SaveChangesAsync();
                return "Ok";
            }
            catch (Exception ex) 
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<List<MoviesResponse>> GetMovies()
        {
            try
            {
                List<MoviesResponse> movies = await DbContext.Movies.ToListAsync();
                return movies;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<MoviesResponse> GetMovieId(int Id)
        {
            try
            {
                MoviesResponse? response = await DbContext.Movies.FirstOrDefaultAsync(x => x.Id == Id);
                if (response != null)
                {
                    return response;
                }
                else
                {
                    throw new Exception("Filme não encontrado");
                }
            }catch(Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<string> UpdateMovie(MoviesResponse movies)
        {
            try
            {
                MoviesResponse? response = await GetMovieId(movies.Id);
                if (response != null) 
                {
                    DbContext.Entry(movies).State = EntityState.Detached;
                    DbContext.Movies.Update(movies);
                    DbContext.SaveChanges();
                    return "Ok";
                }
                else
                {
                    throw new Exception("Filme não encotrado");
                }
               
            }catch(Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<string> DeleteMovie(int Id)
        {
            try
            {
                MoviesResponse response = await GetMovieId(Id);
                if(response != null)
                {
                    DbContext.Movies.Remove(response);
                    DbContext.SaveChanges();
                }
                return "Ok";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
    }
}
