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

        [HttpGet("new")]
        public async Task<IActionResult> GetNewWords(
            [FromQuery] long[] categoryIds,
            int numberOfWords,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _wordService.GetNewWordsForLearn(
                categoryIds,
                numberOfWords,
                cancellationToken));
        }

        [HttpGet("new/{deviceId}")]
        public async Task<IActionResult> GetNewWordsForDevice(
            [FromRoute] string deviceId,
            [FromQuery] long[] categoryIds,
            int numberOfWords,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _wordService.GetNewWordsForLearn(
                categoryIds,
                numberOfWords,
                cancellationToken));
        }
    }
}