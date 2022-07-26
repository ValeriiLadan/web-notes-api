using AutoMapper;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain.Notes;
using CDC.WebNotes.Dto.Notes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public NoteService(INoteRepository noteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }


        public async Task<object> GetAll()
        {
            return await _noteRepository.GetAllNotes();
        }

        public async Task<IReadOnlyCollection<NoteDto>> GetAllNotes()
        {
            IReadOnlyCollection<Note> notes = await _noteRepository.GetAllNotes();

            return _mapper.Map<IReadOnlyCollection<NoteDto>>(notes);
        }

        public async Task<NoteDto> GetNote(int id)
        {
            Note note = await _noteRepository.GetNote(id);

            return _mapper.Map<NoteDto>(note);
        }

        public async Task<NoteDto> CreateNote(NoteDto createNote)
        {
            Note note = _mapper.Map<Note>(createNote);

            await _noteRepository.CreateNote(note);

            return _mapper.Map<NoteDto>(note);
        }

        public async Task UpdateNote(int id, UpdateNoteDto noteDto)
        {
            Note note = await _noteRepository.GetNote(id);

            _mapper.Map(noteDto, note);

           await _noteRepository.SaveChanges();
        }

        public async Task DeleteNote(int id)
        {
            Note note = await _noteRepository.GetNote(id);
            await _noteRepository.DeleteNote(note);
        }
    }
}
