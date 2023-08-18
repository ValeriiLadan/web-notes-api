using System.Collections.Generic;

namespace CDC.WebNotes.Domain
{
    public class Note
    {
        public Note()
        {
            CheckListItems = new List<NoteCheckListItem>();
            Attachments = new List<Attachment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public ICollection<NoteCheckListItem> CheckListItems { get; set; }
        public ICollection<Attachment> Attachments { get; set; }

        public void AddCheckListItem(NoteCheckListItem checkListItem)
        {
            CheckListItems =
                new List<NoteCheckListItem>(CheckListItems ?? new List<NoteCheckListItem>())
                { checkListItem };
        }

        public void AddAttachment(Attachment attachment)
        {
            Attachments =
                new List<Attachment>(Attachments ?? new List<Attachment>())
                { attachment };
        }
    }
}
