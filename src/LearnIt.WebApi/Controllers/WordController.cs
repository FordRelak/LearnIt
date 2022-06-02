using LearnIt.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearnIt.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordController : ControllerBase
    {
        private readonly IWordService _wordService;

        public WordController(IWordService wordService)
        {
            _wordService = wordService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetWordBySearch([FromQuery] string searchWord, CancellationToken cancellationToken = default)
        {
            return Ok(await _wordService.GetWordBySearch(searchWord, cancellationToken));
        }
    }
}