using LearnIt.DTO;
using LearnIt.MAUI.Constants;
using LearnIt.WebApi.Queries;

namespace LearnIt.MAUI.Services
{
    public class LocalWordsService
    {
        private readonly LocalStorageService _localStorageService;
        private readonly IWordApi _wordApi;

        public LocalWordsService(LocalStorageService localStorageService, IWordApi wordApi)
        {
            _localStorageService = localStorageService;
            _wordApi = wordApi;
        }

        public void AddNumberOfWordsInStorage(int numberOfWords)
        {
            _localStorageService.Add(LocalStorageConstants.NUMBER_OF_WORDS_KEY, numberOfWords);
        }

        public int GetNumberOfWordsInStorage()
        {
            return _localStorageService.GetInt(LocalStorageConstants.NUMBER_OF_WORDS_KEY);
        }

        public async Task<ShortWordDto[]> GetWordBySearch(string searchWord)
        {
            return await _wordApi.GetWordBySearch(searchWord);
        }
    }
}