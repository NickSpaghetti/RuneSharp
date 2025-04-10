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
    public class Rs3IronmanHiscoreQuerying : HiscoreQuerying<Rs3IronmanAccount>
    {
        private Rs3RunemetricsQuerying runemetricsQuerying = new Rs3RunemetricsQuerying();
        public override Rs3IronmanAccount SingleAccount(string username)
        {
            var stanardRank = GetRequestHiscoreHelper.GetAccountHiscoreRank(Rs3Constants.URIConstants.HiscoreAccountConstants.StandardHiscores, username);
            var ironResult = GetRequestHiscoreHelper.GetAccountHiscores(Rs3Constants.URIConstants.HiscoreAccountConstants.IronmansHiscores, username);
            var parsedIron = Rs3HiscoreAccountParser<Rs3IronmanAccount>.ParseAccount(username, ironResult);
            parsedIron.IronmanRank = parsedIron.OverAllRank;
            parsedIron.OverAllRank = stanardRank;
            runemetricsQuerying.FillInQuests(parsedIron);
            return parsedIron;
        }
    }
}
