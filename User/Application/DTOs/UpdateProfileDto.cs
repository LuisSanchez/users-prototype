namespace User.Application.DTOs
{
    public class UpdateProfileDto
    {
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    }
}
