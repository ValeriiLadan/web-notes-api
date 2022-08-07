using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Notes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly INotesService _noteService;

        public MainController(INotesService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var result = await _noteService.GetAllNotes(new PagingDto(), new SortingDto<NotesSortingFieldsDto>());

                return Ok(result);

            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }
    }
}
