using CDC.WebNotes.Domain.Notes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Contracts
{
    public interface INoteRepository
    {
        Task<IReadOnlyCollection<Note>> GetAllNotes();
        Task<Note> GetNote(int id);
    }
}
