using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Npcs.Monsters.Metadata
{
    public class Immunity
    {
        public Immunity(StatusEffect statusEffect, GameVersion gameVersion, bool isImmune)
        {
            Name = statusEffect;
            GameVersion = gameVersion;
            IsImmune = isImmune;
        }
        public Immunity()
        {

        }
        public StatusEffect Name { get; set; }
        public GameVersion GameVersion { get; set; }
        public bool IsImmune { get; set; }
    }
}
