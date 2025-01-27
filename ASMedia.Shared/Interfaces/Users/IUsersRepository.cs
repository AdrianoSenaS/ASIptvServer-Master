using ASMedia.Shared.Model.Users;

namespace ASMedia.Shared.Interfaces.Users
{
    public interface IUsersRepository
    {
        public Task<string> AddUser(UserCreate Users);
        public Task<List<UserResponse>> GetUsers();
        public Task<UserResponse> GetUserId(int Id);
        public Task<string> UpdateUser(UserCreate users);
        public Task<string> DeleteUser(UserCreate users);
    }
}
