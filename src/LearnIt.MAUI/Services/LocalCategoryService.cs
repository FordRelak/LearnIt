using LearnIt.Common;
using LearnIt.MAUI.Constants;
using System.Text.Json;

namespace LearnIt.MAUI.Services
{
    public class LocalCategoryService
    {
        private readonly LocalStorageService _localStorageService;

        public LocalCategoryService(LocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public bool IsSkipStartPage()
        {
            return _localStorageService.GetBool(LocalStorageConstants.IS_SKIP_START_PAGE_KEY);
        }

        public void InsertCategoryIds(long[] newIds)
        {
            var json = JsonSerializer.Serialize(newIds);
            _localStorageService.Add(LocalStorageConstants.SELECTED_CATEGORIES_KEY, json);
        }

        public long[] GetCategoryIds()
        {
            var json = _localStorageService.Get(LocalStorageConstants.SELECTED_CATEGORIES_KEY);
            return JsonSerializeExtension.TryDeserializeArray<long>(json);
        }

        public void SetSkipStartPage()
        {
            _localStorageService.Add(LocalStorageConstants.IS_SKIP_START_PAGE_KEY, true);
        }
    }
}