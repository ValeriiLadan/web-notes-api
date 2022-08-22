using System.Collections.Generic;

namespace CDC.WebNotes.Dto.Notes
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<NoteCheckListItemDto> CheckListItems { get; set; }
    }
}
