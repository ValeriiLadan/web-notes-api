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

            CreateMap<NoteCheckListItem, NoteCheckListItemDto>()
                .ReverseMap();

            CreateMap<CreateNoteCheckListItemDto, NoteCheckListItem>()
                .ForMember(domain => domain.Id, exp => exp.Ignore())
                .ForMember(domain => domain.IsComplited, exp => exp.Ignore())
                .ForMember(domain => domain.Note, exp => exp.Ignore());

            CreateMap<PatchNoteCheckListItemDto, NoteCheckListItem>()
               .ForMember(domain => domain.Id, exp => exp.Ignore())
               .ForMember(domain => domain.Note, exp => exp.Ignore());

        }
    }
}
