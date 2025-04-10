using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;

namespace RuneSharp.Models.Minigames
{
    public class Rs3Minigame : Minigame
    {
        public override GameVersion GameVersion { get { return GameVersion.Runescape3; } set { value = GameVersion.Runescape3; } }
    }
}
