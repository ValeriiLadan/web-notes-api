namespace CDC.WebNotes.Api.Models.Notes
{
    public class NotesSortingRequest : SortingRequest<NotesSortingFields> { }

    public enum NotesSortingFields
    {
        Id,
        Name
    }
}
