using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Repositories
{
    public class NoteCheckListItemsRepository : INoteCheckListItemsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NoteCheckListItemsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<NoteCheckListItem> GetNoteCheckListItem(int id)
        {
            return await _dbContext.NoteCheckListItems
                .FirstOrDefaultAsync(checkListItem => checkListItem.Id == id) 
                ?? throw new KeyNotFoundException($"CheckListItem Id {id} was not found");
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
