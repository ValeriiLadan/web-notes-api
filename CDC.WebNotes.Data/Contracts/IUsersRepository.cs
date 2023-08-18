using CDC.WebNotes.Domain;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Contracts
{
    public interface IUsersRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> AddUserAsync(User user);
        Task SaveChanges();
    }
}
