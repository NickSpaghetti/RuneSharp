using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;

namespace RuneSharp.Models.AccountTypes.Rs3
{
    public class Rs3HardcoreIronmanAccount : Rs3BaseAccount, IBaseHardcoreAccount
    {
        public override AccountType AccountType { get { return AccountType.HardcoreIronman; } }
        public override GameVersion GameVersion { get { return GameVersion.Runescape3; } }
        public long HardcoreRank { get; set; }
        public bool IsDead { get; set; }
    }
}
