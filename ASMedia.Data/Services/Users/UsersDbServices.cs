using ASMedia.Shared.Model.Users;
using ASMedia.Shared.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using ASMedia.Data.DataDbContext;

namespace ASMedia.Data.Db.Users
{
    public class UsersDbServices : IUsersRepository
    {
        private readonly AppDbContext DbContext;
        public UsersDbServices(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<string> AddUser(UserCreate Users)
        {
            try
            {
                await DbContext.Users.AddAsync(Users);
                await DbContext.SaveChangesAsync();
                return "OK";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<List<UserResponse>> GetUsers()
        {
            try
            {
                List<UserCreate> users = await DbContext.Users.ToListAsync();
                List<UserResponse> user = users.Select(User => new UserResponse
                {
                    Id = User.Id,
                    Name = User.Name,
                    LastName = User.LastName,
                    Email = User.Email,
                    UserAcount = User.UserAcount,
                    Status = User.Status,
                }).ToList();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<UserResponse> GetUserId(int Id)
        {
            try
            {
                UserCreate? users = await DbContext.Users.FirstOrDefaultAsync(x => x.Id == Id);
                if (users != null)
                {
                    UserResponse user = new UserResponse
                    {
                        Id = users.Id,
                        Name = users.Name,
                        LastName = users.LastName,
                        Email = users.Email,
                        UserAcount = users.UserAcount,
                        Status = users.Status,
                    };
                    return user;
                }
                throw new Exception("Não encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<string> UpdateUser(UserCreate users)
        {
            try
            {
                UserResponse? model = await GetUserId(users.Id);
                if (model != null)
                {
                    DbContext.Entry(users).State = EntityState.Detached;
                }
                DbContext.Users.Update(users);
                DbContext.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<string> DeleteUser(UserCreate users)
        {
            try
            {
                UserResponse model = await GetUserId(users.Id);
                if (model != null)
                {
                    DbContext.Remove(users);
                    await DbContext.SaveChangesAsync();
                }
                return "OK";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
    }
}
