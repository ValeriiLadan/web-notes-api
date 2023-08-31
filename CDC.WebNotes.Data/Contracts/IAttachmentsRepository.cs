using CDC.WebNotes.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Contracts
{
    public interface IAttachmentsRepository
    {
        Task<IReadOnlyCollection<Attachment>> GetAllAttachments();
        Task<Attachment> GetAttachment(int id);
        void CreateAttachment(Attachment createAttachment);
        void DeleteAttachment(Attachment attachment);
        Task SaveChanges();
    }
}
