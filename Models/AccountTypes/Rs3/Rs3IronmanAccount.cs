using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;

namespace RuneSharp.Models.AccountTypes.Rs3
{
    public class Rs3IronmanAccount : Rs3BaseAccount, IIronmanBaseAccount
    {
        public override AccountType AccountType { get{ return AccountType.Ironman; } }
        public override GameVersion GameVersion { get { return GameVersion.Runescape3; } }
        public long IronmanRank { get; set; }
    }
}
