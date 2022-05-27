using LearnIt.MAUI.Constants;

namespace LearnIt.MAUI.Services
{
    public class LocalWordsService
    {
        private readonly LocalStorageService _localStorageService;

        public LocalWordsService(LocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public void AddNumberOfWordsInStorage(int numberOfWords)
        {
            _localStorageService.Add(LocalStorageConstants.NUMBER_OF_WORDS_KEY, numberOfWords);
        }

        public int GetNumberOfWordsInStorage()
        {
            return _localStorageService.GetInt(LocalStorageConstants.NUMBER_OF_WORDS_KEY);
        }
    }
}