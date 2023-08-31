using CDC.WebNotes.Dto.NoteCheckListItems;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Contracts
{
    public interface INoteCheckListItemsService
    {
        Task<NoteCheckListItemDto> GetCheckListItem(int id);
        Task UpdateCheckListItem(int id, PatchNoteCheckListItemDto checkListItem);
    }
}
