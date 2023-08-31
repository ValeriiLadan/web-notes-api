using CDC.WebNotes.Domain;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Files;
using CDC.WebNotes.Dto.NoteCheckListItems;
using CDC.WebNotes.Dto.Notes;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Contracts
{
    public interface INotesService
    {
        Task<NotesPageDto> GetAllNotes(int userId, PagingDto pagingDto, SortingDto<NotesSortingFieldsDto> sortingDto, FilterNoteDto filterDto);
        Task<NoteDto> GetNote(int id);
        Task<NoteDto> CreateNote(NoteDto createNote);
        Task UpdateNote(int id, UpdateNoteDto note);
        Task DeleteNote(int id);
        Task AddNoteCheckListItem(int noteId, CreateNoteCheckListItemDto checkListItemDto);
        Task<Attachment> AddAttachment(int noteId, AttachmentDto attachmentDto);
    }
}
