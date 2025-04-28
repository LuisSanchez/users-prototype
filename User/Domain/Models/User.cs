namespace User.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int RoleId { get; set; }
        public required Role Role { get; set; }
        public Profile Profile { get; set; } = new Profile 
        { 
            FirstName = string.Empty,
            LastName = string.Empty,
            User = null! // Will be set when saving
        };
    }
}
