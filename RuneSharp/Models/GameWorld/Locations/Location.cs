using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.GameWorld.Locations
{
    public class Location : ILocation
    {
        public string LocationName { get; set; }
        public GameVersion GameVersion { get; set; }
    }
}
