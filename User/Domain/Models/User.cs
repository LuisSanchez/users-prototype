namespace User.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public int RoleId { get; set; }
    public required Role Role { get; set; }
    public required Profile Profile { get; set; }
    }
}
