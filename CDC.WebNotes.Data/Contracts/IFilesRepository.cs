using CDC.WebNotes.Domain;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Contracts
{
    public interface IFilesRepository
    {
        Task<File> GetFile(int id);
        Task CreateFile(File createFile);
        Task DeleteFile(File file);
        Task SaveChanges();
    }
}
