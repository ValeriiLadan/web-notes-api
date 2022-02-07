using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        public MainController() {
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            await Task.Delay(0);
            return Ok($"Hello from WebNotes!");
        }
    }
}
