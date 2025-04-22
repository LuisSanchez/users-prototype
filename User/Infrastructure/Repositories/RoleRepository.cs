using User.Domain.Models;
using User.Application.Interfaces;
using System.Threading.Tasks;

namespace User.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public Task<Role> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int roleId)
        {
            throw new NotImplementedException();
        }
    }
}
