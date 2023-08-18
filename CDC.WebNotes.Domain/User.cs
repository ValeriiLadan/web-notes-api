using System.Collections.Generic;

namespace CDC.WebNotes.Domain
{
    public class User
    {
        public User()
        {
            Notes = new List<Note>();
        }

        public User(string username, string passwordHadsh)
        {
            Username = username;
            PasswordHash = passwordHadsh;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Note> Notes { get; set; }

        public void AddNote(Note note)
        {
            Notes = new List<Note>(Notes ?? new List<Note>())
               { note };
        }
    }
}
