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
    public class Rs3StandardHiscoreQuerying : HiscoreQuerying<Rs3StandardAccount> 
    {
        private Rs3RunemetricsQuerying runemetricsQuerying = new Rs3RunemetricsQuerying();
        public override Rs3StandardAccount SingleAccount(string username)
        {
            var result = GetRequestHiscoreHelper.GetAccountHiscores(Rs3Constants.URIConstants.HiscoreAccountConstants.StandardHiscores, username);
            var stdAccount = Rs3HiscoreAccountParser<Rs3StandardAccount>.ParseAccount(username, result);
            runemetricsQuerying.FillInQuests(stdAccount);
            return stdAccount;
        }
    }
}
