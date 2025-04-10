using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Quests.Rs3
{
    public class Rs3Quest : Quest
    {
        public GameVersion GameVersion { get { return GameVersion.Runescape3; } set { value = GameVersion.Runescape3; } }
    }
}
