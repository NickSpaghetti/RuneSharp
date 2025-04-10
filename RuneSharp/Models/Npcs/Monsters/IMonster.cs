using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;
using RuneSharp.Models.GameWorld.Locations;
using RuneSharp.Models.Items;
using RuneSharp.Models.Npcs.Monsters.Metadata;

namespace RuneSharp.Models.Npcs.Monsters
{
    public interface IMonster : INpc
    {
        int CombatLevel { get; set; }
        int HitPoints { get; set; }
        int AttackSpeed { get; set; }
        int SlayerLevel { get; set; }
        double Experence { get; set; }
        double SlayerExperence { get; set; }
        double HitPointsExperence { get; set; }
        Dictionary<string, List<DroppedItem>> DropTables { get; set; }
        List<string> AssignedBy { get; set; }
        List<Immunity> Immunities { get; set; }
        Dictionary<string,int> MaxHit { get; set; }
        bool IsMembers { get; set; }
        bool IsAgressive { get; set; }
        bool IsPoisonous { get; set; }
        DateTime ReleaseDate { get; set; }

    }
}
