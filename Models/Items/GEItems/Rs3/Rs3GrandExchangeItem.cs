using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;

namespace RuneSharp.Models.Items.GEItems.Rs3
{
    public class Rs3GrandExchangeItem : GrandExchangeItem
    {
        public override GameVersion GameVersion { get { return GameVersion.Runescape3; } set { value = GameVersion.Runescape3; } }
    }
}
