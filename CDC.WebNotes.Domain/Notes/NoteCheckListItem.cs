namespace CDC.WebNotes.Domain.Notes
{
    public class NoteCheckListItem
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsComplited { get; set; }
        public Note Note { get; set; }
    }
}
