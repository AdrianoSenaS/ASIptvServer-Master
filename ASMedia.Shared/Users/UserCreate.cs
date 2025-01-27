

namespace ASMedia.Shared.Users
{
    public class UserCreate
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Status { get; set; }
        public string? UserAcount { get; set; }
    }
}
