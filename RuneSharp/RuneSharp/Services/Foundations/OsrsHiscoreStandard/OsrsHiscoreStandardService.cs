using RuneSharp.Brokers.Apis;
using RuneSharp.Models.Osrs;
using RuneSharp.Models.OsrsStandardAccount;
using RuneSharp.Services.Foundations.OsrsMath;

namespace RuneSharp.Services.Foundations.OsrsHiscoreStandard;

public partial class OsrsHiscoreStandardService
{
    private readonly IApiBroker _apiBroker;
    private readonly IOsrsMathService _osrsMath;
    public OsrsHiscoreStandardService(IApiBroker? apiBroker = default, IOsrsMathService? osrsMath = default)
    {
        _apiBroker = apiBroker ?? new ApiBroker();
        _osrsMath = osrsMath ?? new OsrsMathService();
    }

    public async ValueTask<OsrsStandardAccount> GetStandardAccountFromHiscoresAsync(string userName,
        CancellationToken cancellationToken = default)
    {
        var accountCsv = await _apiBroker.GetStandardAccountHiscore(userName, cancellationToken);
        ValidateNotNullOrEmptyApiResponse(userName,accountCsv);
        var parsedAccount = ParseAccount(userName, accountCsv);
        return parsedAccount;
    }
}