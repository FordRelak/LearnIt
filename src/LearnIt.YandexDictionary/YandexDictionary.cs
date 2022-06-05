using Microsoft.Extensions.Options;
using RestSharp;

namespace LearnIt.YandexDictionary
{
    public class YandexDictionary: IYandexDictionary
    {
        private readonly YandexDictionaryOption _options;
        private readonly RestClient _restClient;

        public YandexDictionary(IOptions<YandexDictionaryOption> options)
        {
            _options = options.Value;
            _restClient = new RestClient(_options.Url);
        }

        public async Task<string> TranslateWordAsync(string originalWord, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest("lookup", Method.Get);
            request.AddQueryParameter("key", $"{_options.Token}");
            request.AddQueryParameter("lang", "en-ru");
            request.AddQueryParameter("text", originalWord);

            var response = await _restClient.ExecuteGetAsync<YandexResponse>(request, cancellationToken);

            if(!response.IsSuccessful)
                return string.Empty;

            if(response.Data is null)
                return string.Empty;

            return response.Data.Def?.FirstOrDefault()?.Tr?.FirstOrDefault()?.Text;
        }
    }
}