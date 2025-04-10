using RuneSharp.Models.Osrs;

namespace RuneSharp.Brokers.Apis;

public partial interface IApiBroker
{
    ValueTask<string> GetStandardAccountHiscore(string userName, CancellationToken cancellationToken);
}