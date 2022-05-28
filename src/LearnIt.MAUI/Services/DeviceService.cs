using LearnIt.DTO;
using LearnIt.WebApi.Queries;

namespace LearnIt.MAUI.Services
{
    public class DeviceService
    {
        private readonly LocalWordsService _localWordsService;
        private readonly LocalCategoryService _localCategoryService;
        private readonly IDeviceApi _deviceApi;

        public DeviceService(
            LocalWordsService localWordsService,
            IDeviceApi deviceApi,
            LocalCategoryService localCategoryService)
        {
            _localWordsService = localWordsService;
            _deviceApi = deviceApi;
            _localCategoryService = localCategoryService;
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
            var categoryIds = _localCategoryService.GetCategoryIds();
            var deviceId = GetDeviceId();
            await _deviceApi.Create(new ShortUserDto
            {
                DeviceId = deviceId,
                NumberOfWords = numberOfWords,
                SelectedCategoryIds = categoryIds
            });
        }

        public async Task<ShortWordDto[]> GetNewWordsToLearn()
        {
            var deviceId = GetDeviceId();
            return (await _deviceApi.GetNewWordToLearn(deviceId)).ToArray();
        }

        public async Task<ShortWordDto[]> GetRepeatWordsForLearn()
        {
            var deviceId = GetDeviceId();
            return (await _deviceApi.GetRepeatWordsForLearn(deviceId)).ToArray();
        }

        public async Task SaveWordsToRepeat(long[] wordIds)
        {
            var deviceId = GetDeviceId();
            var dto = new SaveUserWordsDto(deviceId, wordIds);

            await _deviceApi.SaveWordsToRepeat(dto);
        }

        public async Task SaveLearnedWords(long[] wordIds)
        {
            var deviceId = GetDeviceId();
            var dto = new SaveUserWordsDto(deviceId, wordIds);

            await _deviceApi.SaveLearnedWords(dto);
        }

        public async Task<UserInfoDto> GetUserInfo()
        {
            var deviceId = GetDeviceId();
            return await _deviceApi.GetUserInfo(deviceId);
        }
    }
}