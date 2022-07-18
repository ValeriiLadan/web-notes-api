using CDC.WebNotes.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly INoteService _noteService;

        public MainController(INoteService noteService) {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {

            try {
                var result = await _noteService.GetAllNotes();

                return Ok(result);

            } catch (Exception ex) {

                return Ok(ex.Message);
            }
        }
    }
}
