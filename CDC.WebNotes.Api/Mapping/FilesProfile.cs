using AutoMapper;
using CDC.WebNotes.Api.Models.Files;
using CDC.WebNotes.Dto.Files;

namespace CDC.WebNotes.Api.Mapping
{
    public class FilesProfile : Profile
    {
        public FilesProfile()
        {
            CreateMap<CreateFile, FileDto>()
              .ForMember(dto => dto.Id, expression => expression.Ignore());

            CreateMap<PatchFile, FileDto>()
                .ForMember(dto => dto.Id, expression => expression.Ignore())
                .ReverseMap();

            CreateMap<FileDto, File>();
            CreateMap<FileDto, PatchFile>();

            CreateMap<CreateFile, UpdateFileDto>();
            CreateMap<PatchFile, UpdateFileDto>();

            CreateMap<FilesResponseDto, FilesPageResponce>();


            CreateMap<CreateAttachment, AttachmentDto>();

            CreateMap<AttachmentDto, Attachment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<AttachmentsResponseDto, AttachmentsResponce>();
        }
    }
}
