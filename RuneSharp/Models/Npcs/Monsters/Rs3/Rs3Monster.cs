using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RuneSharp.Enums;
using RuneSharp.Models.GameWorld.Locations;
using RuneSharp.Models.Items;
using RuneSharp.Models.Npcs.Monsters.Metadata;

namespace RuneSharp.Models.Npcs.Monsters.Rs3
{
    public class Rs3Monster : IMonster
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("level")]
        public int CombatLevel {get; set;}
        [JsonProperty("lifepoints")]
        public int HitPoints {get; set;}
        public int AttackSpeed {get; set;}
        [JsonProperty("slayerlevel")]
        public int SlayerLevel {get; set;}
        [JsonProperty("xp")]
        public double Experence {get; set;}
        public double SlayerExperence {get; set;}
        public double HitPointsExperence {get; set;}
        public Dictionary<string, List<DroppedItem>> DropTables {get; set;}
        public List<string> AssignedBy {get; set;}
        [JsonProperty("weakness")]
        private string Weakness { get; set; }
        public List<Immunity> Immunities {get; set;}
        public Dictionary<string, int> MaxHit {get; set;}
        public bool IsMembers {get; set;}
        [JsonProperty("aggressive")]
        public bool IsAgressive {get; set;}
        [JsonProperty("poisonous")]
        public bool IsPoisonous {get; set;}
        [JsonProperty("attackable")]
        public bool IsAttackable { get; set;}
        public DateTime ReleaseDate {get; set;}
        [JsonProperty("name")]
        public string NpcName {get; set;}
        [JsonProperty("slayercat")]
        public string SlayerCat { get; set; }
        [JsonProperty("areas")]
        private List<string> Locations { get; set; }
        public GameVersion GameVersion { get { return GameVersion.Runescape3; } set { value = GameVersion.Runescape3; } }
        [JsonProperty("description")]
        public string Examine {get; set;}
    }
}
