using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Minigames
{
    public abstract class Minigame : IMinigame
    {
        public MinigameName MinigameName { get; set; }
        public long Rank { get; set; }
        public long Points { get; set; }
        public abstract GameVersion GameVersion { get; set; }
    }
}
