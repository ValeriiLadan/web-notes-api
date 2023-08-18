using System.Collections.Generic;
using System.Linq;

namespace CDC.WebNotes.Dto.Files
{
    public class FilesResponseDto
    {
        public FileDto[] Files { get; }
        public int TotalCount { get; }

        public FilesResponseDto(IEnumerable<FileDto> files, int totalCount)
        {
            Files = files.ToArray();
            TotalCount = totalCount;
        }
    }
}
