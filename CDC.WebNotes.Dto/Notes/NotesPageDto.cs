using System.Collections.Generic;
using System.Linq;

namespace CDC.WebNotes.Dto.Notes
{
    public class NotesPageDto
    {
        public NoteDto[] Notes { get; }
        public int TotalCount { get; }
        public NotesPageDto(IEnumerable<NoteDto> notes, int totalCount)
        {
            Notes = notes.ToArray();
            TotalCount = totalCount;
        }
    }
}
