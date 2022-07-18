using CDC.WebNotes.Dto.Notes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Contracts
{
    public interface INoteService
    {
        Task<IReadOnlyCollection<NoteDto>> GetAllNotes();
        Task<NoteDto> GetNote(int id);
    }
}
