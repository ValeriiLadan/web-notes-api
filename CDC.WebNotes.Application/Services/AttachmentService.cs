using AutoMapper;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain;
using CDC.WebNotes.Dto.Files;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentsRepository _attachmentRepository;
        private readonly IMapper _mapper;

        public AttachmentService(IAttachmentsRepository attachmentRepository,
                                         IMapper mapper)
        {
            _mapper = mapper;
            _attachmentRepository = attachmentRepository;
        }

        public async Task<AttachmentDto> GetAttachment(int id)
        {
            return _mapper.Map<AttachmentDto>(await _attachmentRepository.GetAttachment(id));
        }

        public async Task<AttachmentDto> CreateAttachment(AttachmentDto createAttachment)
        {
            Attachment attachment = _mapper.Map<Attachment>(createAttachment);

            _attachmentRepository.CreateAttachment(attachment);
            await _attachmentRepository.SaveChanges();

            return _mapper.Map<AttachmentDto>(attachment);
        }

        public async Task DeleteAttachment(int id)
        {
            Attachment attachment = await _attachmentRepository.GetAttachment(id);
            _attachmentRepository.DeleteAttachment(attachment);
            await _attachmentRepository.SaveChanges();
        }
    }
}
