using RuneSharp.Models.AccountTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores
{
    public interface IHardcoreHiscoreQuerying<HardcoreAccountType> where HardcoreAccountType : IBaseHardcoreAccount
    {
        bool IsAccountEliminated(HardcoreAccountType hardcoreType);
    }
}
