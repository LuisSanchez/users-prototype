namespace User.Infrastructure.Configurations
{
    public class JwtConfig
    {
    public required string Secret { get; set; }
    public int ExpiryMinutes { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    }
}
