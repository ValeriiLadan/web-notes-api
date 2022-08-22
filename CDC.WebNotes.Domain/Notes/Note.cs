using System.Collections.Generic;

namespace CDC.WebNotes.Domain.Notes
{
    public class Note
    {
        public Note()
        {
            CheckListItems = new List<NoteCheckListItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<NoteCheckListItem> CheckListItems { get; set; }

        public void AddCheckListItem(NoteCheckListItem checkListItem)
        {
            CheckListItems =
                new List<NoteCheckListItem>(CheckListItems ?? new List<NoteCheckListItem>())
                { checkListItem };
        }
    }
}
