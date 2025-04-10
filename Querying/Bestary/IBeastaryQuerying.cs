using RuneSharp.Models.Npcs.Monsters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Bestary
{
    public interface IBeastaryQuerying<MonsterType> where MonsterType : IMonster
    {
        MonsterType SingleMonster(string monsterName, int combatLevel);
        Dictionary<string,List<MonsterType>> ManyMonsters(List<string> monsterNames);
        List<MonsterType> AllMonsterVariances(string monsterName);
    }
}
