using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FilesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<File> GetFile(int id)
        {
            return await _dbContext.Files
                .FirstOrDefaultAsync(file => file.Id == id)
                ?? throw new KeyNotFoundException($"File Id {id} was not found");
        }

        public async Task CreateFile(File createFile)
        {
            _dbContext.Files.Add(createFile);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFile(File file)
        {
            _dbContext.Files.Remove(file);

            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
