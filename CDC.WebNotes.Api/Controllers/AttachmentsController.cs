using AutoMapper;
using CDC.WebNotes.Api.Models.Files;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Dto.Files;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;
        private readonly IMapper _mapper;

        public AttachmentsController(IAttachmentService attachmentService,
                                            IMapper mapper)
        {
            _attachmentService = attachmentService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<Attachment> Get([FromRoute] int id)
        {
            AttachmentDto attachment = await _attachmentService.GetAttachment(id);

            return _mapper.Map<AttachmentDto, Attachment>(attachment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttachment([FromRoute] int id)
        {
            await _attachmentService.DeleteAttachment(id);

            return NoContent();
        }
    }
}
