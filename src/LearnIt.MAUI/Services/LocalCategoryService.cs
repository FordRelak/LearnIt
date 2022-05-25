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
            return _localStorageService.Get(LocalStorageConstants.IS_SKIP_START_PAGE_KEY, false);
        }

        public void InsertCategoryIds(long[] newIds)
        {
            string idsFromStorage = _localStorageService.Get(LocalStorageConstants.SELECTED_CATEGORIES_KEY, "");
            var oldIds = JsonSerializeExtension.TryDeserializeArray<long>(idsFromStorage);
            var ids = newIds.Union(oldIds).OrderBy(x => x);
            var json = JsonSerializer.Serialize(ids);
            _localStorageService.Add(LocalStorageConstants.SELECTED_CATEGORIES_KEY, json);
        }

        public void SetSkipStartPage()
        {
            _localStorageService.Add(LocalStorageConstants.IS_SKIP_START_PAGE_KEY, true);
        }
    }
}