using CDC.WebNotes.Domain;
using CDC.WebNotes.Domain.Notes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace CDC.WebNotes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        }
    }
}
