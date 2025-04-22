using System.Threading.Tasks;
using User.Application.DTOs;

namespace User.Application.Interfaces
{
    public interface IUserService
    {
        Task UpdateProfileAsync(UpdateProfileDto updateDto);
        Task AssignRoleAsync(int userId, string roleName);
    }
}
