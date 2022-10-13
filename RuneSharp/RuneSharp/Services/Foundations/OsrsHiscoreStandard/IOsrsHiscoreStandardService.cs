using RuneSharp.Models.Osrs;

namespace RuneSharp.Services.Foundations.OsrsHiscoreStandard;

public partial interface IOsrsHiscoreStandardService
{
    ValueTask<OsrsStandardAccount> GetStandardAccountFromHiscoresAsync(string userName,
        CancellationToken cancellationToken = default);
}