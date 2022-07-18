using AutoMapper;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Data.Contracts;
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
            var notes = await _noteRepository.GetAllNotes();

            return _mapper.Map<IReadOnlyCollection<NoteDto>>(notes);
        }

        public async Task<NoteDto> GetNote(int id)
        {
            var note = await _noteRepository.GetNote(id);

            return _mapper.Map<NoteDto>(note);
        }
    }
}
