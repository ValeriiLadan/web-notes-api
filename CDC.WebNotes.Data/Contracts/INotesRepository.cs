using CDC.WebNotes.Domain;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Notes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Contracts
{
    public interface INotesRepository
    {
        Task<IReadOnlyCollection<Note>> GetAllNotes(int userId, PagingDto pagingDto, SortingDto<NotesSortingFieldsDto> sortingDto, FilterNoteDto filterNoteDto);
        Task<int> CountNotes(int userId);
        Task<Note> GetNote(int id);
        Task CreateNote(Note createNote);
        Task DeleteNote(Note note);
        Task SaveChanges();
    }
}
