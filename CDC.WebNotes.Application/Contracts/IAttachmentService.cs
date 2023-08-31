using CDC.WebNotes.Dto.Files;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Contracts
{
    public interface IAttachmentService
    {
        Task<AttachmentDto> GetAttachment(int id);
        Task<AttachmentDto> CreateAttachment(AttachmentDto createAttachment);
        Task DeleteAttachment(int id);
    }
}
