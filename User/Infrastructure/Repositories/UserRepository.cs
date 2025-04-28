using User.Domain.Models;
using User.Application.Interfaces;
using UserEntity = User.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using User.Infrastructure.Data;

namespace User.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Profile)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Profile)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
        }

        public Task UpdateAsync(UserEntity user)
        {
            _context.Users.Update(user);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
