using AutoMapper;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain;
using CDC.WebNotes.Dto.NoteCheckListItems;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Services
{
    public class NoteCheckListItemsService : INoteCheckListItemsService
    {
        private readonly INoteCheckListItemsRepository _noteCheckListItemsRepository;
        private readonly IMapper _mapper;

        public NoteCheckListItemsService(INoteCheckListItemsRepository noteCheckListItemsRepository,
                                         IMapper mapper)
        {
            _mapper = mapper;
            _noteCheckListItemsRepository = noteCheckListItemsRepository;
        }

        public async Task<NoteCheckListItemDto> GetCheckListItem(int id)
        {
            return _mapper.Map<NoteCheckListItemDto>(await _noteCheckListItemsRepository.GetNoteCheckListItem(id));
        }

        public async Task UpdateCheckListItem(int id, PatchNoteCheckListItemDto checkListItemDto)
        {
            NoteCheckListItem checkListItem = await _noteCheckListItemsRepository.GetNoteCheckListItem(id);

            _mapper.Map(checkListItemDto, checkListItem);

            await _noteCheckListItemsRepository.SaveChanges();
        }
    }
}
