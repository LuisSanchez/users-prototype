using System.Threading.Tasks;

namespace User.Application.Interfaces
{
    public interface IRoleService
    {
        Task CreateRoleAsync(string roleName);
        Task UpdateRoleAsync(int roleId, string newName);
        Task DeleteRoleAsync(int roleId);
    }
}
