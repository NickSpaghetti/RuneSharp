using RuneSharp.Models.OsrsStandardAccount.Exceptions;

namespace RuneSharp.Services.Foundations.OsrsHiscoreStandard;

public partial class OsrsHiscoreStandardService
{
    private void ValidateNotNullOrEmptyApiResponse(string accountName, string response)
    {
        if (string.IsNullOrEmpty(response))
        {
            throw new StandardAccountNotFoundException($"No hiscores found for player with the username {accountName}.");
        }
    }
}