using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using User.Domain.Models;
using UserEntity = User.Domain.Models.User;

namespace User.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);
        }
    }
}
