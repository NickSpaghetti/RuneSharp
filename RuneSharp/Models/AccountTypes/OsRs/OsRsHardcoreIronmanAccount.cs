using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;

namespace RuneSharp.Models.AccountTypes.OsRs
{
    public class OsRsHardcoreIronmanAccount : OsRsBaseAccount, IBaseHardcoreAccount
    {
        public override GameVersion GameVersion { get { return GameVersion.OldSchool; } }

        public override AccountType AccountType { get { return AccountType.HardcoreIronman; } }

        public long HardcoreRank { get; set; }
        public bool IsDead { get; set; }
    }
}
