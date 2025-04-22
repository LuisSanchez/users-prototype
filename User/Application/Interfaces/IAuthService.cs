using System.Threading.Tasks;
using User.Application.DTOs;

namespace User.Application.Interfaces
{
    public interface IAuthService
    {
        Task RegisterUser(RegisterDto registerDto);
        Task<string> Login(LoginDto loginDto);
        Task RequestPasswordReset(string email);
    }
}
