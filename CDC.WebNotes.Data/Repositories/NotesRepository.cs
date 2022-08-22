using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Data.Extensions;
using CDC.WebNotes.Domain.Notes;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Notes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NotesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<Note>> GetAllNotes(PagingDto pagingDto, SortingDto<NotesSortingFieldsDto> sortingDto)
        {
            return await _dbContext.Notes
                .Include(note => note.CheckListItems)
                .Sort(sortingDto)
                .Page(pagingDto)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Note> GetNote(int id)
        {
            return await _dbContext.Notes
                .Include(note => note.CheckListItems)
                .FirstOrDefaultAsync(note => note.Id == id)
                ?? throw new KeyNotFoundException($"Note Id {id} was not found");
        }


        public async Task CreateNote(Note createNote)
        {
            _dbContext.Notes.Add(createNote);

            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNote(Note note)
        {
            _dbContext.Notes.Remove(note);

            await _dbContext.SaveChangesAsync();
        }

        public Task<Note> ReplaceNote(int id, Note note)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> CountNotes()
        {
           return await _dbContext.Notes.CountAsync();
        }
    }
}
