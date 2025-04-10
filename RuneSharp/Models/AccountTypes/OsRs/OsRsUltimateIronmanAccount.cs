using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;

namespace RuneSharp.Models.AccountTypes.OsRs
{
    public class OsRsUltimateIronmanAccount : OsRsBaseAccount
    {
        public override GameVersion GameVersion { get { return GameVersion.OldSchool; } }

        public override AccountType AccountType { get { return AccountType.UltimateIronman; } }

        public long UlitmateRank { get; set; }
    }
}
