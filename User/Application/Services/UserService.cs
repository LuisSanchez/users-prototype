using User.Application.Interfaces;
using User.Application.DTOs;
using User.Domain.Models;
using User.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace User.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.Profile?.FirstName ?? string.Empty,
                LastName = user.Profile?.LastName ?? string.Empty,
                Role = user.Role?.Name ?? "User"
            };
        }

        public Task UpdateProfileAsync(UpdateProfileDto updateDto)
        {
            // Existing implementation
            throw new NotImplementedException();
        }

        public Task AssignRoleAsync(int userId, string roleName)
        {
            // Existing implementation
            throw new NotImplementedException();
        }
    }
}
