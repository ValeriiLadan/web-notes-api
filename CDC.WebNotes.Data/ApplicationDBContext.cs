using CDC.WebNotes.Domain;
using Microsoft.EntityFrameworkCore;

namespace CDC.WebNotes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteCheckListItem> NoteCheckListItems { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<User> Users { get; set; } 
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
