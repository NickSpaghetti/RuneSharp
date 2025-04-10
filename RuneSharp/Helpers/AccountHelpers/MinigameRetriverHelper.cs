using RuneSharp.Enums;
using RuneSharp.Models.Minigames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuneSharp.Helpers.AccountHelpers
{
    public static class MinigameRetriverHelper
    {

        public static OsRsMinigame GetOsRsMinigame(List<OsRsMinigame> skills, MinigameName minigameName)
        {
            return skills.First(s => s.MinigameName == minigameName);
        }

        public static Rs3Minigame GetOsRsMiniGame(List<Rs3Minigame> skills, MinigameName minigameName)
        {
            return skills.First(s => s.MinigameName == minigameName);
        }
    }
}
