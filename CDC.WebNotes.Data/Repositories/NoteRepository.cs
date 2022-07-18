using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain.Notes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NoteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<Note>> GetAllNotes()
        {
            return await _dbContext.Notes.ToListAsync();
        }

        public async Task<Note> GetNote(int id)
        {
            return await _dbContext.Notes
                .FirstOrDefaultAsync(note => note.Id == id);
        }
    }
}
