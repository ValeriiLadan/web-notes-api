using AutoMapper;
using CDC.WebNotes.Domain.Notes;
using CDC.WebNotes.Dto.Notes;

namespace CDC.WebNotes.Application.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Note, NoteDto>()
                .ReverseMap();

            CreateMap<UpdateNoteDto, Note>();
        }
    }
}
