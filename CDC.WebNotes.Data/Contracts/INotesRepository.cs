using CDC.WebNotes.Domain.Notes;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Notes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Contracts
{
    public interface INotesRepository
    {
        Task<IReadOnlyCollection<Note>> GetAllNotes(PagingDto pagingDto, SortingDto<NotesSortingFieldsDto> sortingDto);
        Task<int> CountNotes();
        Task<Note> GetNote(int id);
        Task CreateNote(Note createNote);
        Task SaveChanges();
        Task<Note> ReplaceNote(int id,Note note);
        Task DeleteNote(Note note);
    }
}
