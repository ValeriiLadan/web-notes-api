using AutoMapper;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain;
using CDC.WebNotes.Dto.Files;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IFilesRepository _fileRepository;
        private readonly IMapper _mapper;

        public FileService(IFilesRepository fileRepository,
                                         IMapper mapper)
        {
            _mapper = mapper;
            _fileRepository = fileRepository;
        }

        public async Task<FileDto> GetFile(int id)
        {
            return _mapper.Map<FileDto>(await _fileRepository.GetFile(id));
        }

        public async Task<FileDto> CreateFile(FileDto createFile)
        {
            File file = _mapper.Map<File>(createFile);

            _fileRepository.CreateFile(file);
            await _fileRepository.SaveChanges();

            return _mapper.Map<FileDto>(file);
        }

        public async Task DeleteFile(int id)
        {
            File file = await _fileRepository.GetFile(id);
            _fileRepository.DeleteFile(file);
            await _fileRepository.SaveChanges();
        }

        public async Task UpdateFile(int id, UpdateFileDto fileDto)
        {
            File file = await _fileRepository.GetFile(id);

            _mapper.Map(fileDto, file);

            await _fileRepository.SaveChanges();
        }
    }
}
