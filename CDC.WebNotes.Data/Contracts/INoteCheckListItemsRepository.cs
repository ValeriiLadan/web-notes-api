using CDC.WebNotes.Domain.Notes;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Contracts
{
    public interface INoteCheckListItemsRepository
    {
        Task<NoteCheckListItem> GetNoteCheckListItem(int id);
        Task SaveChanges();
    }
}
