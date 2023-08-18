using CDC.WebNotes.Dto.Files;
using CDC.WebNotes.Dto.NoteCheckListItems;
using System.Collections.Generic;

namespace CDC.WebNotes.Dto.Notes
{
   public class FilterNoteDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? isComplited { get; set; }
    }
}
