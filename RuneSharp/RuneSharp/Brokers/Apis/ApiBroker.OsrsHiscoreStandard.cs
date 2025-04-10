using RuneSharp.Constants;
using RuneSharp.Models.Enums;
using RuneSharp.Models.Osrs;

namespace RuneSharp.Brokers.Apis;

public partial class ApiBroker
{
    public async ValueTask<string> GetStandardAccountHiscore(string userName, CancellationToken cancellationToken)
    {
        _httpClient.BaseAddress = new Uri($"{OsrsConstants.URIConstants.HiscoreConstants.Standard}{userName}");
        return await GetAsync(string.Empty, cancellationToken);
    }
}