using AutoMapper;
using CDC.WebNotes.Domain.Notes;
using CDC.WebNotes.Dto.Notes;

namespace CDC.WebNotes.Application.Mapping
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Note, NoteDto>().ReverseMap();
        }
    }
}
