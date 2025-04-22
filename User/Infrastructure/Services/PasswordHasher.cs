using User.Application.Interfaces;

namespace User.Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            // Implementation using BCrypt or similar
            throw new NotImplementedException();
        }

        public bool VerifyPassword(string hash, string password)
        {
            // Implementation for password verification
            throw new NotImplementedException();
        }
    }
}
