using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Items.GEItems.OsRs
{
    public class OsRsGrandExchangeItems : GrandExchangeItems
    {
        public override GameVersion GameVersion { get { return GameVersion.OldSchool; } set { value = GameVersion.OldSchool; } }
    }
}
