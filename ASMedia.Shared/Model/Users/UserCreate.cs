namespace ASMedia.Shared.Model.Users
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
        public List<Permissions>? Permissions { get; set; }
    }
    public class Permissions
    {
        public int Id { get; set; }
        public bool Movie { get; set; }
        public bool Series { get; set; }
        public bool Tv { get; set; }
        public bool Adult { get; set; }
    }
}
