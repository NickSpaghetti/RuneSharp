using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;

namespace RuneSharp.Models.AccountTypes.OsRs
{
    public class OsRsIronmanAccount : OsRsBaseAccount, IIronmanBaseAccount
    {
        public override GameVersion GameVersion { get { return GameVersion.OldSchool; } }

        public override AccountType AccountType { get { return AccountType.Ironman; } }

        public long IronmanRank { get; set; }
    }
}
