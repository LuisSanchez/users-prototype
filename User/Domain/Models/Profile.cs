namespace User.Domain.Models
{
    public class Profile
    {
        public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public int UserId { get; set; }
    public required User User { get; set; }
    }
}
