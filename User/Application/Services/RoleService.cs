using User.Application.Interfaces;
using System.Threading.Tasks;

namespace User.Application.Services
{
    public class RoleService : IRoleService
    {
        public Task CreateRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoleAsync(int roleId, string newName)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoleAsync(int roleId)
        {
            throw new NotImplementedException();
        }
    }
}
