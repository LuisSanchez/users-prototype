using User.Application.Interfaces;
using User.Application.DTOs;
using User.Domain.Models;
using User.Infrastructure.Services;
using User.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace User.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly JwtConfig _jwtConfig;

        public AuthService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IOptions<JwtConfig> jwtConfig)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtConfig = jwtConfig.Value;
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

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            if (!_passwordHasher.VerifyPassword(user.PasswordHash, loginDto.Password))
            {
                throw new Exception("Invalid credentials");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtConfig.ExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task RequestPasswordReset(string email)
        {
            // Implementation for password reset request
            throw new NotImplementedException();
        }
    }
}
