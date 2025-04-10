using RuneSharp.Enums;
using RuneSharp.Models.AccountTypes;
using RuneSharp.Models.AccountTypes.Rs3;
using RuneSharp.Querying.Hiscores.Runemetrics.Rs3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores
{
    public abstract class HiscoreQuerying<AccountType> : IHiscoresQuerying<AccountType> where AccountType : IBaseAccount
    {
        public virtual List<AccountType> ManyAccounts(string[] usernameList)
        {
            var AccountList = new List<AccountType>();
            foreach (var name in usernameList)
            {
                AccountList.Add(SingleAccount(name));
            }

            return AccountList;
        }

        public abstract AccountType SingleAccount(string username);
    }
}
