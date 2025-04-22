using User.Application.Interfaces;
using User.Application.DTOs;
using User.Domain.Models;
using User.Infrastructure.Services;
using System.Threading.Tasks;

namespace User.Application.Services
{
    public class AuthService : IAuthService
    {
        public Task RegisterUser(RegisterDto registerDto)
        {
            // Implementation for user registration
            throw new NotImplementedException();
        }

        public Task<string> Login(LoginDto loginDto)
        {
            // Implementation for user login
            throw new NotImplementedException();
        }

        public Task RequestPasswordReset(string email)
        {
            // Implementation for password reset request
            throw new NotImplementedException();
        }
    }
}
