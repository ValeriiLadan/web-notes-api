using CDC.WebNotes.Dto.Notes;
using System.Collections.Generic;

namespace CDC.WebNotes.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<NoteDto> Notes { get; set; }
    }
}
