using User.Domain.Models;
using System.Threading.Tasks;

namespace User.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetByIdAsync(int id);
        Task<Role> GetByNameAsync(string name);
        Task AddAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(int roleId);
    }
}
