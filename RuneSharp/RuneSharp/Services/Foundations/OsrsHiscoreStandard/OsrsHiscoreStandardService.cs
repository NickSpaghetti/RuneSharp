using RuneSharp.Brokers.Apis;
using RuneSharp.Models.Osrs;
using RuneSharp.Services.Foundations.OsRsMath;

namespace RuneSharp.Services.Foundations.OsrsHiscoreStandard;

public partial class OsrsHiscoreStandardService
{
    private readonly IApiBroker _apiBroker;
    private readonly IOsRsMathService _osrsMath;
    public OsrsHiscoreStandardService(IApiBroker? apiBroker = default, IOsRsMathService? osrsMath = default)
    {
        _apiBroker = apiBroker ?? new ApiBroker();
        _osrsMath = osrsMath ?? new OsRsMathService();
    }

    public async ValueTask<OsrsStandardAccount> GetStandardAccountFromHiscoresAsync(string userName,
        CancellationToken cancellationToken = default)
    {
        var accountCsv = await _apiBroker.GetStandardAccountHiscore(userName, cancellationToken);
        var parsedAccount = ParseAccount(userName, accountCsv);
        return parsedAccount;
    }
}