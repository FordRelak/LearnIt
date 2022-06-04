using LearnIt.DTO;
using LearnIt.WebApi.Queries;
using System.Net;

namespace LearnIt.MAUI.Services
{
    public class WordService
    {
        private readonly IWordApi _wordApi;

        public WordService(IWordApi wordApi)
        {
            _wordApi = wordApi;
        }

        public async Task<ShortWordDto> GetWordByOriginalWord(string word)
        {
            var response = await _wordApi.GetWordByOriginalWord(word);

            if(response.StatusCode == HttpStatusCode.NoContent)
            {
                return null;
            }

            return response.Content;
        }

        public async Task<long> CreateWord(long categoryId, string originalText, string translatedText)
        {
            var newWord = new CreateWordDto
            {
                CategoryId = categoryId,
                OriginalText = originalText,
                TranslatedText = translatedText,
            };

            return await _wordApi.CreateWord(newWord);
        }
    }
}