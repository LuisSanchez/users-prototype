using User.Application.Interfaces;
using User.Application.DTOs;
using User.Domain.Models;
using User.Infrastructure.Services;
using System.Threading.Tasks;

namespace User.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task RegisterUser(RegisterDto registerDto)
        {
            // Check if user already exists
            var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with this email already exists");
            }

            // Hash password
            var passwordHash = _passwordHasher.HashPassword(registerDto.Password);

            // Create new user
            // Create user with basic info
            var newUser = new Domain.Models.User
            {
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow,
                Role = new Domain.Models.Role { Name = "User" }
            };

            // Create profile with required relationships
            var profile = new Domain.Models.Profile
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                User = newUser
            };

            // Set bidirectional relationship
            newUser.Profile = profile;

            // Save to database
            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();
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
