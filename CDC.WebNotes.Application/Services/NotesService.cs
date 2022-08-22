using AutoMapper;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain.Notes;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Notes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository _notesRepository;
        private readonly IMapper _mapper;

        public NotesService(INotesRepository notesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _notesRepository = notesRepository;
        }

        public async Task<NotesPageDto> GetAllNotes(PagingDto pagingDto, SortingDto<NotesSortingFieldsDto> sortingDto)
        {
            IReadOnlyCollection<Note> notes = await _notesRepository.GetAllNotes(pagingDto, sortingDto);

            int count = await _notesRepository.CountNotes();

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

            await _notesRepository.CreateNote(note);

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
            await _notesRepository.DeleteNote(note);
        }

        public async Task AddNoteCheckListItem(int noteId, CreateNoteCheckListItemDto checkListItemDto)
        {
            Note note = await _notesRepository.GetNote(noteId);

            note.AddCheckListItem(_mapper.Map<NoteCheckListItem>(checkListItemDto));

            await _notesRepository.SaveChanges();
        }
    }
}
