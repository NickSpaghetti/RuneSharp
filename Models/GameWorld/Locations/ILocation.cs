using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.GameWorld.Locations
{
    public interface ILocation
    {
        string LocationName { get; set; }
        GameVersion GameVersion { get; set; }
    }
}
