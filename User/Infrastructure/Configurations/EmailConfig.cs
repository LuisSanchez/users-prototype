namespace User.Infrastructure.Configurations
{
    public class EmailConfig
    {
    public required string SmtpServer { get; set; }
    public int Port { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public bool UseSSL { get; set; }
    }
}
