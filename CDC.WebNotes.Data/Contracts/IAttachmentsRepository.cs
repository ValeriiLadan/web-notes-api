using CDC.WebNotes.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Contracts
{
    public interface IAttachmentsRepository
    {
        Task<IReadOnlyCollection<Attachment>> GetAllAttachments();
        Task<Attachment> GetAttachment(int id);
        Task CreateAttachment(Attachment createAttachment);
        Task DeleteAttachment(Attachment attachment);
        Task SaveChanges();
    }
}
