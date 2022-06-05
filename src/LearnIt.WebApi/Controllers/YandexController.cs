using LearnIt.YandexDictionary;
using Microsoft.AspNetCore.Mvc;

namespace LearnIt.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YandexController : ControllerBase
    {
        private readonly IYandexDictionary _yandexDictionary;

        public YandexController(IYandexDictionary yandexDictionary)
        {
            _yandexDictionary = yandexDictionary;
        }

        [HttpGet]
        public async Task<IActionResult> GetTranslate([FromQuery] string originalWord, CancellationToken cancellationToken)
        {
            return Ok(await _yandexDictionary.TranslateWordAsync(originalWord, cancellationToken));
        }
    }
}