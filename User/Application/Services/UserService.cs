using User.Application.Interfaces;
using User.Application.DTOs;
using System.Threading.Tasks;

namespace User.Application.Services
{
    public class UserService : IUserService
    {
        public Task UpdateProfileAsync(UpdateProfileDto updateDto)
        {
            // Implementation
            throw new NotImplementedException();
        }

        public Task AssignRoleAsync(int userId, string roleName)
        {
            // Implementation
            throw new NotImplementedException();
        }
    }
}
