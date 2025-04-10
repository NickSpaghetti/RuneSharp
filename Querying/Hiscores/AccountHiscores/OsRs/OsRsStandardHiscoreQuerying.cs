using RuneSharp.Constants;
using RuneSharp.Helpers.ParsersHelper.HiscoreParsers.OsRs;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.AccountTypes.OsRs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores.OsRs
{
    public class OsRsStandardHiscoreQuerying : HiscoreQuerying<OsRsStandardAccount>
    {
        public override OsRsStandardAccount SingleAccount(string username)
        {
            var result = GetRequestHiscoreHelper.GetAccountHiscores(OsRsConstants.URIConstants.HiscoreConstants.Standard, username);
            return OsRsHiscoreAccountParser<OsRsStandardAccount>.ParseAccount(username, result);
        }
    }
}
