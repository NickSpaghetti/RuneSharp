using RuneSharp.Constants;
using RuneSharp.Helpers.ParsersHelper.HiscoreParsers.Rs3;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.AccountTypes.Rs3;
using RuneSharp.Querying.Hiscores.Runemetrics.Rs3;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores.Rs3
{
    public class Rs3HardcoreIronmanHiscoreQuerying : HardcoreHiscoreQuerying<Rs3HardcoreIronmanAccount>
    {
        private Rs3RunemetricsQuerying runemetricsQuerying = new Rs3RunemetricsQuerying();
        public override Rs3HardcoreIronmanAccount SingleAccount(string username)
        {
            var stanardRank = GetRequestHiscoreHelper.GetAccountHiscoreRank(Rs3Constants.URIConstants.HiscoreAccountConstants.StandardHiscores, username);
            var hardcoreResult = GetRequestHiscoreHelper.GetAccountHiscores(Rs3Constants.URIConstants.HiscoreAccountConstants.HardcoreIronman, username);
            var parsedHardcore = Rs3HiscoreAccountParser<Rs3HardcoreIronmanAccount>.ParseAccount(username, hardcoreResult);
            parsedHardcore.HardcoreRank = parsedHardcore.OverAllRank;
            parsedHardcore.OverAllRank = stanardRank;
            parsedHardcore.IsDead = IsAccountEliminated(parsedHardcore);
            runemetricsQuerying.FillInQuests(parsedHardcore);

            return parsedHardcore;
        }
    }
}
