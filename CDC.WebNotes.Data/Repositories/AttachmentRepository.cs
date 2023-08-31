using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Repositories
{
    public class AttachmentsRepository : IAttachmentsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AttachmentsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<Attachment>> GetAllAttachments()
        {
            return await _dbContext.Attachments
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Attachment> GetAttachment(int id)
        {
           
            return await _dbContext.Attachments
                .FirstOrDefaultAsync(attachment => attachment.Id == id)
                ?? throw new KeyNotFoundException($"Attachment Id {id} was not found");
        }

        public void CreateAttachment(Attachment createAttachment)
        {
            _dbContext.Attachments.Add(createAttachment);
        }

        public void DeleteAttachment(Attachment attachment)
        {
            _dbContext.Attachments.Remove(attachment);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
