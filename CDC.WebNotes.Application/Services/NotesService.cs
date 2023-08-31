using AutoMapper;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Files;
using CDC.WebNotes.Dto.NoteCheckListItems;
using CDC.WebNotes.Dto.Notes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository _notesRepository;
        private readonly IFilesRepository _filesRepository;
        private readonly IMapper _mapper;

        public NotesService(INotesRepository notesRepository, IFilesRepository filesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _notesRepository = notesRepository;
            _filesRepository = filesRepository;
        }

        public async Task<NotesPageDto> GetAllNotes(int userId, PagingDto pagingDto, SortingDto<NotesSortingFieldsDto> sortingDto, FilterNoteDto filterDto)
        {
            IReadOnlyCollection<Note> notes = await _notesRepository.GetAllNotes(userId, pagingDto, sortingDto, filterDto);

            int count = await _notesRepository.CountNotes(userId);

            return new NotesPageDto(_mapper.Map<IReadOnlyCollection<NoteDto>>(notes), count); 
        }

        public async Task<NoteDto> GetNote(int id)
        {
            Note note = await _notesRepository.GetNote(id);

            return _mapper.Map<NoteDto>(note);
        }

        public async Task<NoteDto> CreateNote(NoteDto createNote)
        {
            Note note = _mapper.Map<Note>(createNote);

            _notesRepository.CreateNote(note);
            await _notesRepository.SaveChanges();

            return _mapper.Map<NoteDto>(note);
        }

        public async Task UpdateNote(int id, UpdateNoteDto noteDto)
        {
            Note note = await _notesRepository.GetNote(id);

            _mapper.Map(noteDto, note);

           await _notesRepository.SaveChanges();
        }

        public async Task DeleteNote(int id)
        {
            Note note = await _notesRepository.GetNote(id);

            _notesRepository.DeleteNote(note);

            await _notesRepository.SaveChanges();
        }

        public async Task AddNoteCheckListItem(int noteId, CreateNoteCheckListItemDto checkListItemDto)
        {
            Note note = await _notesRepository.GetNote(noteId);

            note.AddCheckListItem(_mapper.Map<NoteCheckListItem>(checkListItemDto));

            await _notesRepository.SaveChanges();
        }

        public async Task<Attachment> AddAttachment(int noteId, AttachmentDto attachmentDto)
        {
            Note note = await _notesRepository.GetNote(noteId);
            File file = await _filesRepository.GetFile(attachmentDto.FileId);

            Attachment attachment = _mapper.Map<Attachment>(attachmentDto);
            note.Attachments.Add(attachment);
            
            await _notesRepository.SaveChanges();

            return attachment;
        }
    }
}
