using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;

namespace RuneSharp.Models.AccountTypes.OsRs
{
    public class OsRsStandardAccount : OsRsBaseAccount
    {
        public override AccountType AccountType { get { return AccountType.Standard; } }

        public override GameVersion GameVersion { get { return GameVersion.OldSchool; } }
    }
}
