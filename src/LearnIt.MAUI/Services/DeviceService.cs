using LearnIt.DTO;
using LearnIt.WebApi.Queries;
using System.Text;

namespace LearnIt.MAUI.Services
{
    public class DeviceService
    {
        private readonly LocalWordsService _localWordsService;
        private readonly IDeviceApi _deviceApi;

        public DeviceService(
            LocalWordsService localWordsService,
            IDeviceApi deviceApi)
        {
            _localWordsService = localWordsService;
            _deviceApi = deviceApi;
        }

        public string GetDeviceId()
        {
            return Android.Provider.Settings.Secure.GetString(
                Android.App.Application.Context.ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);
        }

        public async Task SaveStartSettings()
        {
            var numberOfWords = _localWordsService.GetNumberOfWordsInStorage();
            var deviceId = GetDeviceId();
            await _deviceApi.Create(new ShortUserDto
            {
                DeviceId = deviceId,
                NumberOfWords = numberOfWords
            });
        }
    }
}