using CDC.WebNotes.Domain;
using CDC.WebNotes.Domain.Notes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Repositories
{
    public interface INoteRepository
    {
        Task<IReadOnlyCollection<Note>> GetAllNotes();

    }
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NoteRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<Note>> GetAllNotes() 
        {
            return await _dbContext.Notes.ToListAsync();
        }
    }
}
