namespace CDC.WebNotes.Api.Models.Files
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoteId { get; set; }
        public int FileId { get; set; }
    }
}
