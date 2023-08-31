using CDC.WebNotes.Dto;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Contracts
{
    public interface IAuthService
    {
        Task<UserDto> GetUserByUsernameAsync(string username);
        Task<UserDto> RegisterUserAsync(string username, string password);
        bool VerifyPasswordHash(string password, string passwordHash);
        Task<ClaimsIdentity> Login(string password, string passwordHash, string authScheme);
    }
}
