using CDC.WebNotes.Domain;
using System.Threading.Tasks;

namespace CDC.WebNotes.Data.Contracts
{
    public interface IFilesRepository
    {
        Task<File> GetFile(int id);
        void CreateFile(File createFile);
        void DeleteFile(File file);
        Task SaveChanges();
    }
}
