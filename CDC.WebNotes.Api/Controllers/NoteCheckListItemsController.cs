using AutoMapper;
using CDC.WebNotes.Api.Models.Notes;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Dto.Notes;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteCheckListItemsController : ControllerBase
    {
        private readonly INoteCheckListItemsService _noteCheckListItemsService;
        private readonly IMapper _mapper;

        public NoteCheckListItemsController(INoteCheckListItemsService noteCheckListItemsService, 
                                            IMapper mapper)
        {
            _noteCheckListItemsService = noteCheckListItemsService;
            _mapper = mapper;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCheckListItem([FromRoute] int id,
                                                            [FromBody] JsonPatchDocument<PatchNoteCheckListItem> patchDocument)
        {
            NoteCheckListItemDto checkListItem = await _noteCheckListItemsService.GetCheckListItem(id);

            PatchNoteCheckListItem patchNote = _mapper.Map<PatchNoteCheckListItem>(checkListItem);

            patchDocument.ApplyTo(patchNote);

            await _noteCheckListItemsService.UpdateCheckListItem(id, _mapper.Map<PatchNoteCheckListItemDto>(patchNote));

            return NoContent();
        }
    }
}
