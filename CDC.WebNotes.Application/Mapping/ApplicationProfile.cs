using AutoMapper;
using CDC.WebNotes.Domain;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Files;
using CDC.WebNotes.Dto.NoteCheckListItems;
using CDC.WebNotes.Dto.Notes;

namespace CDC.WebNotes.Application.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Note, NoteDto>()
                .ReverseMap();

            CreateMap<UpdateNoteDto, Note>()
                .ForMember(domain => domain.Id, exp => exp.Ignore())
                .ForMember(domain => domain.CheckListItems, exp => exp.Ignore());

            CreateMap<NoteCheckListItem, NoteCheckListItemDto>()
                .ReverseMap();

            CreateMap<CreateNoteCheckListItemDto, NoteCheckListItem>()
                .ForMember(domain => domain.Id, exp => exp.Ignore())
                .ForMember(domain => domain.IsComplited, exp => exp.Ignore())
                .ForMember(domain => domain.Note, exp => exp.Ignore());

            CreateMap<PatchNoteCheckListItemDto, NoteCheckListItem>()
               .ForMember(domain => domain.Id, exp => exp.Ignore())
               .ForMember(domain => domain.Note, exp => exp.Ignore());

            //Files
            CreateMap<File, FileDto>()
             .ReverseMap();

            CreateMap<UpdateFileDto, File>()
              .ForMember(domain => domain.Id, exp => exp.Ignore());

            CreateMap<Attachment, AttachmentDto>()
             .ReverseMap();

            CreateMap<User, UserDto>()
             .ReverseMap();
        }
    }
}
