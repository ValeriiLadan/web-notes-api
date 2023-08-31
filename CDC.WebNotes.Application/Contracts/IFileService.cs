using CDC.WebNotes.Dto.Files;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Contracts
{
    public interface IFileService
    {
        Task<FileDto> GetFile(int id);
        Task<FileDto> CreateFile(FileDto createFile);
        Task UpdateFile(int id, UpdateFileDto file);
        Task DeleteFile(int id);
    }
}
