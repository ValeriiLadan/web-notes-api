using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Notes;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Contracts
{
    public interface INotesService
    {
        Task<NotesPageDto> GetAllNotes(PagingDto pagingDto, SortingDto<NotesSortingFieldsDto> sortingDto);
        Task<NoteDto> GetNote(int id);
        Task<NoteDto> CreateNote(NoteDto createNote);
        Task UpdateNote(int id, UpdateNoteDto note);
        Task DeleteNote(int id);
        Task AddNoteCheckListItem(int noteId, CreateNoteCheckListItemDto checkListItemDto);
    }
}
