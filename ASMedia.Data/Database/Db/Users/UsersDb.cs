using ASMedia.Data.Database.DataDbContext;
using ASMedia.Data.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace ASMedia.Data.Database.Db.Users
{
    public class UsersDb
    {
        public async Task<string> AddUser(AppDbContext DbContext, UsersModel Users)
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
        public async Task<List<UsersModel>> GetUsers(AppDbContext DbContext)
        {
            try
            {
                List<UsersModel> users = await DbContext.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<UsersModel> GetUserId(AppDbContext DbContext, int Id)
        {
            try
            {
                UsersModel? users = await DbContext.Users.FirstOrDefaultAsync(x => x.Id == Id);
                if (users != null)
                {
                    return users;
                }
                throw new Exception("Não encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<string> UpdateUser(AppDbContext DbContext, UsersModel users)
        {
            try
            {
                UsersModel model = await GetUserId(DbContext, users.Id);
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
        public async Task<string> DeleteUser(AppDbContext DbContext, UsersModel users)
        {
            try
            {
                UsersModel model = await GetUserId(DbContext, users.Id);
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
