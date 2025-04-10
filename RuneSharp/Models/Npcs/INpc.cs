using RuneSharp.Enums;
using RuneSharp.Models.GameWorld.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Npcs
{
    public interface INpc
    {
        string NpcName { get; set; }
        GameVersion GameVersion { get; set; }
        string Examine { get; set; }

    }
}
