using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(user => user.Username == username);
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

       public async Task SaveChanges()
       {
           await _dbContext.SaveChangesAsync();
       }
    }
}
