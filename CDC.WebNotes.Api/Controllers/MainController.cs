using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Notes;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAuthService _authService;

        public MainController(INotesService noteService, IAuthService authService)
        {
            _noteService = noteService;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var currentUser = await _authService.GetUserByUsernameAsync(Request.HttpContext.User.Identity.Name);
                if (currentUser == null)
                {
                    return Unauthorized();
                }

                var result = await _noteService.GetAllNotes(currentUser.Id, new PagingDto(), new SortingDto<NotesSortingFieldsDto>(), new FilterNoteDto());

                return Ok(result);

            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }
    }
}
