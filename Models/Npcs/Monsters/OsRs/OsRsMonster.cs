using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;
using RuneSharp.Models.GameWorld.Locations;
using RuneSharp.Models.Items;
using RuneSharp.Models.Npcs.Monsters.Metadata;
using RuneSharp.Models.Npcs.Monsters.Metadata.OsRs;

namespace RuneSharp.Models.Npcs.Monsters.OsRs
{
    public class OsRsMonster : IMonster
    {
        public string NpcName { get; set; }
        public string Examine { get; set; }
        public int CombatLevel { get; set; }
        public int HitPoints { get; set; }
        public int AttackSpeed { get; set; }
        public int SlayerLevel { get; set; }
        public double Experence { get; set; }
        public double SlayerExperence { get; set; }
        public double HitPointsExperence { get; set; }
        public Dictionary<string, List<DroppedItem>> DropTables { get; set; }
        public Dictionary<string, int> MaxHit { get; set; }
        public Dictionary<string,string> AttackStyles { get; set; }
        public List<string> AssignedBy { get; set; }
        public List<Weakness> Weaknesses { get; set; }
        public List<Immunity> Immunities { get; set; }
        public bool IsMembers { get; set; }
        public bool IsAgressive { get; set; }
        public bool IsPoisonous { get; set; }
        public bool IsVenomious { get; set; }
        public DateTime ReleaseDate { get; set; }
        public GameVersion GameVersion { get; set; }
        public List<Location> Locations { get; set; }
        public CombatStats CombatStats { get; set; }
        public AggressiveStats AggressiveStats { get; set; }
        public DefensiveStats DefensiveStats { get; set; }
        public OtherBounses OtherBounses { get; set; }
    }
}
