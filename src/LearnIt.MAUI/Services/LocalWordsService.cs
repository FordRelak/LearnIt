using LearnIt.DTO;
using LearnIt.MAUI.Constants;
using LearnIt.MAUI.Models;
using System.Text.Json;

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

        public void InsertWordToLocalCategory(string originalText, string translatedText)
        {
            var json = _localStorageService.Get(LocalStorageConstants.LOCAL_CATEGORY_KEY);

            if(string.IsNullOrEmpty(json))
            {
                json = CreateLocalCategory();
            }

            var localCategory = JsonSerializer.Deserialize<CategoryDto>(json);
            localCategory.Words.Add(new ShortWordDto
            {
                OriginalText = originalText,
                TranslatedText = translatedText
            });

            var newJson = JsonSerializer.Serialize(localCategory);
            _localStorageService.Add(LocalStorageConstants.LOCAL_CATEGORY_KEY, newJson);
        }

        public long GetLearnedWordsToday()
        {
            var json = _localStorageService.Get(LocalStorageConstants.LEARNED_WORDS_COUNT_TODAY_KEY);

            if(string.IsNullOrEmpty(json))
            {
                var learnedWord = new UserLearnedAccess
                {
                    CurrentLearnDay = DateTime.Now,
                    LearnedWordsNumber = 0
                };

                var newJson = JsonSerializer.Serialize(learnedWord);
                _localStorageService.Add(LocalStorageConstants.LEARNED_WORDS_COUNT_TODAY_KEY, newJson);

                return 0;
            }

            var learnedWordAccess = JsonSerializer.Deserialize<UserLearnedAccess>(json);

            if(learnedWordAccess.CurrentLearnDay.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                return learnedWordAccess.LearnedWordsNumber;
            }
            else
            {
                learnedWordAccess.CurrentLearnDay = DateTime.Now;
                learnedWordAccess.LearnedWordsNumber = 0;
                var newJson = JsonSerializer.Serialize(learnedWordAccess);
                _localStorageService.Add(LocalStorageConstants.LEARNED_WORDS_COUNT_TODAY_KEY, newJson);
                return 0;
            }
        }

        public void InserLearnedWordsCount(long learnedWordsCount)
        {
            var json = _localStorageService.Get(LocalStorageConstants.LEARNED_WORDS_COUNT_TODAY_KEY);
            var learnedAccess = JsonSerializer.Deserialize<UserLearnedAccess>(json);
            learnedAccess.LearnedWordsNumber += learnedWordsCount;
            var newJson = JsonSerializer.Serialize(learnedAccess);
            _localStorageService.Add(LocalStorageConstants.LEARNED_WORDS_COUNT_TODAY_KEY, newJson);
        }

        private string CreateLocalCategory()
        {
            var localCategory = new CategoryDto
            {
                Id = 0,
                Name = "Мои слова",
                Words = Array.Empty<ShortWordDto>()
            };

            return JsonSerializer.Serialize(localCategory);
        }
    }
}