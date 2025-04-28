using System.Threading.Tasks;
using UserEntity = User.Domain.Models.User;

namespace User.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<Domain.Models.User?> GetByIdAsync(int id);
        Task<Domain.Models.User?> GetByEmailAsync(string email);
        Task AddAsync(Domain.Models.User user);
        Task UpdateAsync(Domain.Models.User user);
        Task SaveChangesAsync();
    }
}
