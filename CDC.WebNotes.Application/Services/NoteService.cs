using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository) {
            _noteRepository = noteRepository;
        }
        public async Task<object> GetAll() {
           return await _noteRepository.GetAllNotes();
        }
    }
}
