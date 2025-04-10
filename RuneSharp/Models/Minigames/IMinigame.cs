using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Minigames
{
    public interface IMinigame
    {
        MinigameName MinigameName { get; set; }
        long Rank { get; set; }
        long Points { get; set; }
        GameVersion GameVersion { get; set; }
    }
}
