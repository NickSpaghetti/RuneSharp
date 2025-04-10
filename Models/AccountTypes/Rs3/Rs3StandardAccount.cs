using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;

namespace RuneSharp.Models.AccountTypes.Rs3
{
    public class Rs3StandardAccount : Rs3BaseAccount
    {
        public override AccountType AccountType { get { return AccountType.Standard; } }
        public override GameVersion GameVersion { get { return GameVersion.Runescape3; } }
    }
}
