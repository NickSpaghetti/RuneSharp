namespace RuneSharp.Brokers.Apis;

public partial class ApiBroker
{
    public async ValueTask<string> GetStandardHiscore(string userName, CancellationToken cancellationToken)
    {
        var result = await GetAsync(userName, cancellationToken);
        return result;
    }

}