using System.Threading.Tasks;
using User.Application.DTOs;

namespace User.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetByEmailAsync(string email);
        Task UpdateProfileAsync(UpdateProfileDto updateDto);
        Task AssignRoleAsync(int userId, string roleName);
    }
}
