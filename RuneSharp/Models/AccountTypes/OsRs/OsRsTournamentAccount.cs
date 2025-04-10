using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;

namespace RuneSharp.Models.AccountTypes.OsRs
{
    public class OsRsTournamentAccount : OsRsBaseAccount
    {
        public override GameVersion GameVersion { get { return GameVersion.OldSchool; } }

        public override AccountType AccountType { get { return AccountType.Tournament; } }

        public long TournamentRank { get; set; }
    }
}
