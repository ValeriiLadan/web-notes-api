using AutoMapper;
using CDC.WebNotes.Api.Models.Notes;
using CDC.WebNotes.Dto.Notes;

namespace CDC.WebNotes.Api.Mapping
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<CreateNote, NoteDto>()
                .ForMember(dto => dto.Id, expression => expression.Ignore());

            CreateMap<PatchNote, NoteDto>()
                .ForMember(dto => dto.Id, expression => expression.Ignore())
                .ReverseMap();

            CreateMap<PatchNote, UpdateNoteDto>();

            CreateMap<PutNote, UpdateNoteDto>();

            CreateMap<PutNote, NoteDto>()
                .ForMember(dto => dto.Id, expression => expression.Ignore());

            CreateMap<Note, NoteDto>()
                .ReverseMap();
        }
    }
}
