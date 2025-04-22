using System.Threading.Tasks;
using UserEntity = User.Domain.Models.User;

namespace User.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByIdAsync(int id);
        Task<UserEntity> GetByEmailAsync(string email);
        Task AddAsync(UserEntity user);
        Task UpdateAsync(UserEntity user);
    }
}
