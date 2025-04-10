using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;
using RuneSharp.Helpers.AccountHelpers;
using RuneSharp.Models.Minigames;

namespace RuneSharp.Models.AccountTypes.OsRs
{
    public class OsRsSeasonalAccount : OsRsBaseAccount
    {
        public override GameVersion GameVersion { get { return GameVersion.OldSchool; } }

        public override AccountType AccountType { get { return AccountType.Seasonal; } }

        public long SeasonalRank { get; set; }

        public OsRsSeasonalAccount()
        {
            Minigames = MinigameLoaderHelper.LoadSeasonalMinigames();
        }

    }
}
