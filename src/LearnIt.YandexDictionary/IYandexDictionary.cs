using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnIt.YandexDictionary
{
    public interface IYandexDictionary
    {
        Task<string> TranslateWordAsync(string originalWord, CancellationToken cancellationToken = default);
    }
}
