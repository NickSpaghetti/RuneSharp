using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Minigames
{
    public class OsRsMinigame : Minigame
    {
        public override GameVersion GameVersion { get { return GameVersion.OldSchool; } set { value = GameVersion.OldSchool; } }
    }
}
