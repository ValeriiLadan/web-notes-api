using AutoMapper;
using CDC.WebNotes.Api.Models.Notes;
using CDC.WebNotes.Api.Models.Notes.NoteCheckListItems;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.NoteCheckListItems;
using CDC.WebNotes.Dto.Notes;

namespace CDC.WebNotes.Api.Mapping
{
    public class NotesProfile : Profile
    {
        public NotesProfile()
        {
            CreateMap<CreateNote, NoteDto>()
               .ForMember(dto => dto.Id, expression => expression.Ignore())
               .ForMember(dto => dto.CheckListItems, expression => expression.Ignore())
               .ForMember(dto => dto.Attachments, expression => expression.Ignore());

            CreateMap<PatchNote, NoteDto>()
                .ForMember(dto => dto.Id, expression => expression.Ignore())
                .ForMember(dto => dto.CheckListItems, expression => expression.Ignore())
                .ForMember(dto => dto.Attachments, expression => expression.Ignore())
                .ReverseMap();

            CreateMap<PatchNote, UpdateNoteDto>();

            CreateMap<PutNote, UpdateNoteDto>();

            CreateMap<PutNote, NoteDto>()
                .ForMember(dto => dto.Id, expression => expression.Ignore())
                .ForMember(dto => dto.CheckListItems, expression => expression.Ignore())
                .ForMember(dto => dto.Attachments, expression => expression.Ignore());

            CreateMap<Note, NoteDto>()
                .ReverseMap();

            CreateMap<NotesSortingRequest, SortingDto<NotesSortingFieldsDto>>();
            CreateMap<FilterNote, FilterNoteDto>();

            CreateMap<NotesPageDto, NotesPageResponce>();

            MapNoteCheckListItems();
        }

        private void MapNoteCheckListItems()
        {
            CreateMap<NoteCheckListItemDto, NoteCheckListItem>();

            CreateMap<CreateNoteCheckListItem, CreateNoteCheckListItemDto>();

            CreateMap<NoteCheckListItemDto, PatchNoteCheckListItem>();

            CreateMap<PatchNoteCheckListItem, PatchNoteCheckListItemDto>();
        }
    }
}
