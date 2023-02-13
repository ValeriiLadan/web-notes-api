using AutoMapper;
using CDC.WebNotes.Api.Models;
using CDC.WebNotes.Dto;

namespace CDC.WebNotes.Api.Mapping
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<PagingRequest, PagingDto>();
        }
    }
}
