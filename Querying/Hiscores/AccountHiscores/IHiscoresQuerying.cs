
using RuneSharp.Models.AccountTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores
{
    public interface IHiscoresQuerying<AccountType> where AccountType : IBaseAccount
    {
        AccountType SingleAccount(string username);

        List<AccountType> ManyAccounts(string[] usernames);
    }
}
