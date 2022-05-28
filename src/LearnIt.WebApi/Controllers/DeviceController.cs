using LearnIt.DTO;
using LearnIt.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearnIt.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        /// <summary>
        /// Получение новых слов для изучения
        /// </summary>
        [HttpGet("{deviceId}/learn/new")]
        public async Task<IActionResult> GetNewWordToLearn(
            [FromRoute] string deviceId,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _deviceService.GetNewWordsForLearn(deviceId, cancellationToken));
        }

        /// <summary>
        /// Получение слов для повторения.
        /// </summary>
        [HttpGet("{deviceId}/learn/repeat")]
        public async Task<IActionResult> GetRepeatWordsForLearn(
            [FromRoute] string deviceId,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _deviceService.GetRepeatWordsForLearn(deviceId, cancellationToken));
        }

        /// <summary>
        /// Сохранение слов для повтора.
        /// </summary>
        [HttpPost("learn/new")]
        public async Task SaveWordsToRepeat(
            [FromBody] SaveUserWordsDto dto,
            CancellationToken cancellationToken = default)
        {
            await _deviceService.SaveUserWords(dto, cancellationToken);
        }

        /// <summary>
        /// Сохранение выученных слов.
        /// </summary>
        [HttpPost("learn/repeat")]
        public async Task SaveLearnedWords(
            [FromBody] SaveUserWordsDto dto,
            CancellationToken cancellationToken = default)
        {
            await _deviceService.SaveLearnedWords(dto, cancellationToken);
        }

        /// <summary>
        /// Сохранение настроек пользователя
        /// </summary>
        [HttpPost]
        public async Task Create(
            [FromBody] ShortUserDto dto,
            CancellationToken cancellationToken = default)
        {
            await _deviceService.CreateOrUpdateUser(dto, cancellationToken);
        }

        [HttpGet("{deviceId}/info")]
        public async Task<IActionResult> GetUserInfo(
            [FromRoute] string deviceId,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _deviceService.GetUserInfo(deviceId, cancellationToken));
        }
    }
}