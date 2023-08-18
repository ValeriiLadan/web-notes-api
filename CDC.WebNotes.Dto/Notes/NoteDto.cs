using CDC.WebNotes.Dto.Files;
using CDC.WebNotes.Dto.NoteCheckListItems;
using System.Collections.Generic;

namespace CDC.WebNotes.Dto.Notes
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public ICollection<NoteCheckListItemDto> CheckListItems { get; set; }
        public ICollection<AttachmentDto> Attachments { get; set; }
    }
}
