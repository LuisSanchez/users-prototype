using User.Domain.Models;
using User.Application.Interfaces;
using UserEntity = User.Domain.Models.User;
using System.Threading.Tasks;

namespace User.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<UserEntity> GetByIdAsync(int id)
        {
            // Implementation for getting user by ID
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetByEmailAsync(string email)
        {
            // Implementation for getting user by email
            throw new NotImplementedException();
        }

        public Task AddAsync(UserEntity user)
        {
            // Implementation for adding new user
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserEntity user)
        {
            // Implementation for updating user
            throw new NotImplementedException();
        }
    }
}
