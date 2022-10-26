using RuneSharp.Services.Foundations.OsrsHiscoreStandard;

namespace RuneSharp.Test.Services.Foundations.OsrsHiscores;

public class OsrsStandardHiscoreTests
{
    [Test]
    public async ValueTask METHOD()
    {
        var standardHiscoreService = new OsrsHiscoreStandardService();
        var std = await standardHiscoreService.GetStandardAccountFromHiscoresAsync("iron hyger");
        Assert.IsNotNull(std.Minigames);
        
    }
}