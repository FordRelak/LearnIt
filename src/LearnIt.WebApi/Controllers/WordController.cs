using LearnIt.DTO;
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

        [HttpGet]
        public async Task<IActionResult> GetWordByOriginalWord([FromQuery] string word, CancellationToken cancellationToken = default)
        {
            return Ok(await _wordService.GetWordByOriginalWord(word, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateWord([FromBody] CreateWordDto dto, CancellationToken cancellationToken = default)
        {
            return Ok(await _wordService.CreateWord(dto, cancellationToken));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] long wordId, CancellationToken cancellationToken = default)
        {
            await _wordService.DeleteWord(wordId, cancellationToken);
            return Ok();
        }
    }
}