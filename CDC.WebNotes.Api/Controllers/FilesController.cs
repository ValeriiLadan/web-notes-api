using AutoMapper;
using CDC.WebNotes.Api.Models.Files;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Dto.Files;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public FilesController(IFileService fileService,
                                            IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<File> Get([FromRoute] int id)
        {
            FileDto file = await _fileService.GetFile(id);

            return _mapper.Map<FileDto, File>(file);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchFile([FromRoute] int id,
                                                           [FromBody] JsonPatchDocument<PatchFile> patchDocument)
        {
            FileDto file = await _fileService.GetFile(id);

            PatchFile patchFile = _mapper.Map<PatchFile>(file);
            patchDocument.ApplyTo(patchFile);

            await _fileService.UpdateFile(id, _mapper.Map<UpdateFileDto>(patchFile));

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostFile([FromBody] CreateFile createFile)
        {
            FileDto createFileDto = _mapper.Map<FileDto>(createFile);

            FileDto createdFile = await _fileService.CreateFile(createFileDto);

            return CreatedAtAction(nameof(FilesController.Get),
                                    new { id = createdFile.Id }, createdFile);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile([FromRoute] int id)
        {
            await _fileService.DeleteFile(id);

            return NoContent();
        }
    }
}
