using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Data.Extensions;
using CDC.WebNotes.Domain;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Notes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CDC.WebNotes.Data.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NotesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<Note>> GetAllNotes(int UserId, PagingDto pagingDto, SortingDto<NotesSortingFieldsDto> sortingDto, FilterNoteDto filterDto)
        {
            return await _dbContext.Notes
                .Where(note => note.UserId == UserId)
                .FilterNotes(filterDto)
                .Include(note => note.CheckListItems)
                .Include(note => note.Attachments)
                .Sort(sortingDto)
                .Page(pagingDto)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Note> GetNote(int id)
        {
            return await _dbContext.Notes
                .Include(note => note.CheckListItems)
                .Include(note => note.Attachments)
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

        public async Task<int> CountNotes(int userId)
        {
           return await _dbContext.Notes
                .Where(note => note.UserId == userId)
                .CountAsync();
        }
    }

    public static class NoteExtentions {

        public static IQueryable<Note> FilterNotes(this IQueryable<Note> notes, FilterNoteDto filterDto)
        {

            if (filterDto.Name != null)
            {
                notes = notes.Where(note => note.Name.Contains(filterDto.Name));
            }

            if (filterDto.Description != null)
            {
                notes = notes.Where(note => note.Description.Contains(filterDto.Description));
            }

            if (filterDto.isComplited != null)
            {
                notes = notes
                 .Where(note => note.CheckListItems
                                    .Where(checkListItem => checkListItem.IsComplited != filterDto.isComplited)
                                    .Any());
            }
            
            return notes;
        }
    }
}
