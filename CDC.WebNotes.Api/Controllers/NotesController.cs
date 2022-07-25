using AutoMapper;
using CDC.WebNotes.Api.Models.Notes;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Dto.Notes;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;

        public NotesController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IReadOnlyCollection<NoteDto> notes = await _noteService.GetAllNotes();

            return Ok(_mapper.Map<IReadOnlyCollection<NoteDto>, IReadOnlyCollection<Note>>(notes));
        }

        [HttpGet("{id}")]
        public async Task<Note> Get([FromRoute] int id)
        {
            NoteDto note = await _noteService.GetNote(id);

            return _mapper.Map<NoteDto, Note>(note);
        }

        [HttpPost]
        public async Task<IActionResult> PostNote([FromBody] CreateNote createNote)
        {
            NoteDto createNoteDto = _mapper.Map<NoteDto>(createNote);

            NoteDto createdNote = await _noteService.CreateNote(createNoteDto);

            return CreatedAtAction(
                nameof(NotesController.Get),
                "Notes",
                new { id = createdNote.Id });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchNote([FromRoute] int id,
                                                   [FromBody] JsonPatchDocument<PatchNote> patchDocument)
        {
            NoteDto note = await _noteService.GetNote(id);

            PatchNote patchNote = _mapper.Map<PatchNote>(note);

            patchDocument.ApplyTo(patchNote);

            await _noteService.UpdateNote( id, _mapper.Map<UpdateNoteDto>(patchNote));

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote([FromRoute] int id, 
                                                 [FromBody] PutNote putNote)
        {
            UpdateNoteDto noteDto = _mapper.Map<UpdateNoteDto>(putNote);

            await _noteService.UpdateNote(id, noteDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote([FromRoute] int id)
        {
            await _noteService.DeleteNote(id);

            return NoContent();
        }
    }
}
