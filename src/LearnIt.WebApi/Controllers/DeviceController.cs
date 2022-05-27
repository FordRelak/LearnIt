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

        [HttpGet("{device}/learn/new")]
        public async Task<IActionResult> GetNewWordToLearn(
            [FromRoute] string deviceId,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _deviceService.GetNewWordsForLearn(deviceId, cancellationToken));
        }

        [HttpPost]
        public async Task Create(
            [FromBody] ShortUserDto dto,
            CancellationToken cancellationToken = default)
        {
            await _deviceService.CreateOrUpdateUser(dto, cancellationToken);
        }

        //[HttpGet("{device}/learn/repeat")]
    }
}