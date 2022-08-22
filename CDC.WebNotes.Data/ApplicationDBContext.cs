using CDC.WebNotes.Domain.Notes;
using Microsoft.EntityFrameworkCore;

namespace CDC.WebNotes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteCheckListItem> NoteCheckListItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
