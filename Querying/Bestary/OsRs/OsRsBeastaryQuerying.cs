using RuneSharp.Helpers.ParsersHelper.BestaryParser.OsRs;
using RuneSharp.Models.Npcs.Monsters.OsRs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Bestary.OsRs
{
    public class OsRsBeastaryQuerying : IBeastaryQuerying<OsRsMonster>
    {
        public List<OsRsMonster> AllMonsterVariances(string monsterName)
        {
            return DataToOsRsMonster.GetAllMonsterVarrations(monsterName);
        }

        public Dictionary<string, List<OsRsMonster>> ManyMonsters(List<string> monsterNames)
        {
            return DataToOsRsMonster.GetManyMonsters(monsterNames);
        }

        public OsRsMonster SingleMonster(string monsterName, int combatLevel)
        {
            return DataToOsRsMonster.GetSingleMonster(monsterName, combatLevel);
        }
    }
}
