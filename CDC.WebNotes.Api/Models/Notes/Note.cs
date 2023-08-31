﻿using CDC.WebNotes.Api.Models.Files;
using CDC.WebNotes.Api.Models.Notes.NoteCheckListItems;
using System.Collections.Generic;

namespace CDC.WebNotes.Api.Models.Notes
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<NoteCheckListItem> CheckListItems { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
}
