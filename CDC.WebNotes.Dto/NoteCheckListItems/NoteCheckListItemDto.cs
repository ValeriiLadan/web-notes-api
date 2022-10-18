namespace CDC.WebNotes.Dto.Notes
{
    public class NoteCheckListItemDto
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsComplited { get; set; }
    }

    public class CreateNoteCheckListItemDto
    {
        public string Value { get; set; }
    }

    public class PatchNoteCheckListItemDto
    {
        public string Value { get; set; }
        public bool IsComplited { get; set; }
    }
}
