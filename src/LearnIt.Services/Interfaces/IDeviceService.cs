using LearnIt.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnIt.Services.Interfaces
{
    public interface IDeviceService
    {
        Task CreateOrUpdateUser(ShortUserDto dto, CancellationToken cancellationToken);
        Task<ICollection<ShortWordDto>> GetNewWordsForLearn(string deviceId, CancellationToken cancellationToken = default);
    }
}
