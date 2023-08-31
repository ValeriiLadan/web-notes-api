﻿using AutoMapper;
using CDC.WebNotes.Api.Models;
using CDC.WebNotes.Api.Models.Files;
using CDC.WebNotes.Api.Models.Notes;
using CDC.WebNotes.Api.Models.Notes.NoteCheckListItems;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Files;
using CDC.WebNotes.Dto.NoteCheckListItems;
using CDC.WebNotes.Dto.Notes;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;
        private readonly IMapper _mapper;

        public NotesController(INotesService notesService, IMapper mapper)
        {
            _notesService = notesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int userId,
                                             [FromQuery] PagingRequest pagingRequest,
                                             [FromQuery] NotesSortingRequest sortingRequest,
                                             [FromQuery] FilterNote filter)
        {
            PagingDto pagingDto = _mapper.Map<PagingDto>(pagingRequest);
            FilterNoteDto filterDto = _mapper.Map<FilterNoteDto>(filter);

            SortingDto<NotesSortingFieldsDto> sortingDto = _mapper.Map<SortingDto<NotesSortingFieldsDto>>(sortingRequest);

            NotesPageDto notes = await _notesService.GetAllNotes(userId, pagingDto, sortingDto, filterDto);

            return Ok(_mapper.Map<NotesPageResponce>(notes));
        }

        [HttpGet("{id}")]
        public async Task<Note> Get([FromRoute] int id)
        {
            NoteDto note = await _notesService.GetNote(id);

            return _mapper.Map<NoteDto, Note>(note);
        }

        [HttpPost]
        public async Task<IActionResult> PostNote([FromBody] CreateNote createNote)
        {
            NoteDto createNoteDto = _mapper.Map<NoteDto>(createNote);

            NoteDto createdNote = await _notesService.CreateNote(createNoteDto);

            return CreatedAtAction(nameof(NotesController.Get),
                                   "Notes",
                                   new { id = createdNote.Id });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchNote([FromRoute] int id,
                                                   [FromBody] JsonPatchDocument<PatchNote> patchDocument)
        {
            NoteDto note = await _notesService.GetNote(id);

            PatchNote patchNote = _mapper.Map<PatchNote>(note);

            patchDocument.ApplyTo(patchNote);

            await _notesService.UpdateNote(id, _mapper.Map<UpdateNoteDto>(patchNote));

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote([FromRoute] int id,
                                                 [FromBody] PutNote putNote)
        {
            UpdateNoteDto noteDto = _mapper.Map<UpdateNoteDto>(putNote);

            await _notesService.UpdateNote(id, noteDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote([FromRoute] int id)
        {
            await _notesService.DeleteNote(id);

            return NoContent();
        }

        [HttpPost("{id}/checkListItems")]
        public async Task<IActionResult> PostCheckListItem([FromRoute] int id, 
                                                           [FromBody] CreateNoteCheckListItem createCheckListItem)
        {
            CreateNoteCheckListItemDto createDto = _mapper.Map<CreateNoteCheckListItemDto>(createCheckListItem);

            await _notesService.AddNoteCheckListItem(id, createDto);

            return CreatedAtAction(nameof(NotesController.Get),
                                   "Notes",
                                   new { noteId = id });
        }

        [HttpPost("{id}/attachments")]
        public async Task<IActionResult> PostAttachment([FromRoute] int id,
                                                           [FromBody] CreateAttachment createAttachment)
        {

            AttachmentDto createAttachmentDto = _mapper.Map<AttachmentDto>(createAttachment);

            var attachment = await _notesService.AddAttachment(id, createAttachmentDto);

            return CreatedAtAction(nameof(AttachmentsController.Get),
                                   "Attachments",
                                   new { attachmentId = attachment.Id });
        }
    }
}
