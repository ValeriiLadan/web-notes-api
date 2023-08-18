using System.Collections.Generic;
using System.Linq;

namespace CDC.WebNotes.Dto.Files
{
    public class AttachmentsResponseDto
    {
        public AttachmentDto[] Attachments { get; }

        public AttachmentsResponseDto(IEnumerable<AttachmentDto> attachments)
        {
            Attachments = attachments.ToArray();
        }
    }
}
