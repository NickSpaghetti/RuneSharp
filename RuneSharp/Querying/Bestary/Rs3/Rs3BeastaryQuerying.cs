using RuneSharp.Helpers.ParsersHelper.BestaryParser.Rs3;
using RuneSharp.Models.Npcs.Monsters.Rs3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuneSharp.Querying.Bestary.Rs3
{
    public class Rs3BeastaryQuerying : IBeastaryQuerying<Rs3Monster>
    {
        public List<Rs3Monster> AllMonsterVariances(string monsterName)
        {
            return Rs3BeastaryParser.GetAllMonsterVarrations(monsterName);
        }

        public Dictionary<string, List<Rs3Monster>> ManyMonsters(List<string> monsterNames)
        {
            var rs3MonsterDict = new Dictionary<string, List<Rs3Monster>>();
            foreach (var monster in monsterNames)
            {
                rs3MonsterDict[monster] = AllMonsterVariances(monster);
            }

            return rs3MonsterDict;
        }

        public Rs3Monster SingleMonster(string monsterName, int combatLevel)
        {
            return Rs3BeastaryParser.Rs3Monster(monsterName, combatLevel);
        }

        public List<string> GetRs3Areas()
        {
            return Rs3BeastaryParser.GetRs3Areas();
        }

        public List<Rs3MonsterVarrations> GetRs3MonstersByArea(string area)
        {
            return Rs3BeastaryParser.GetRs3MonstersByArea(area);
        }

        public Dictionary<string, long> GetRs3SlayerCategories()
        {
            return Rs3BeastaryParser.GetRs3SlayerCategories();
        }

        public Dictionary<string, List<Rs3Monster>> GetSlayerMonstersByCagegory(long slayerCategoryId)
        {
            var Rs3MonsterDict = new Dictionary<string, List<Rs3Monster>>();
            var SlayerMonsterByCagegory = Rs3BeastaryParser.GetSlayerMonsterByCagegory(slayerCategoryId);
            if(SlayerMonsterByCagegory != null && SlayerMonsterByCagegory.Count > 0)
            {
                Rs3MonsterDict = GetMonsterVarrations(SlayerMonsterByCagegory);                
            }

            return Rs3MonsterDict;
        }

        public Dictionary<string, List<Rs3Monster>> GetMonstersInBetweenCombatLevels(long startLevel, long endLevel)
        {
            var Rs3MonsterDict = new Dictionary<string, List<Rs3Monster>>();
            var monstersInLevels = Rs3BeastaryParser.GetMonstersInBetweenCombatLevels(startLevel,endLevel);
            if (monstersInLevels != null && monstersInLevels.Count > 0)
            {
                Rs3MonsterDict = GetMonsterVarrations(monstersInLevels);
            }

            return Rs3MonsterDict;
        }

        public Dictionary<string, List<Rs3Monster>> GetMonstersByWeakness(long weaknessId)
        {
            var Rs3MonsterDict = new Dictionary<string, List<Rs3Monster>>();
            var monsterByWeakness = Rs3BeastaryParser.GetMonstersByWeakness(weaknessId);
            if (monsterByWeakness != null && monsterByWeakness.Count > 0)
            {
                Rs3MonsterDict = GetMonsterVarrations(monsterByWeakness);
            }

            return Rs3MonsterDict;
        }

        public Dictionary<string, List<Rs3Monster>> GetMonstersThatStartWith(char firstLetter)
        {
            var Rs3MonsterDict = new Dictionary<string, List<Rs3Monster>>();
            var monstersStartWith = Rs3BeastaryParser.GetMonstersThatStartWith(firstLetter);
            if (monstersStartWith != null && monstersStartWith.Count > 0)
            {
                Rs3MonsterDict = GetMonsterVarrations(monstersStartWith);
            }

            return Rs3MonsterDict;
        }

        private Dictionary<string, List<Rs3Monster>> GetMonsterVarrations(List<Rs3MonsterVarrations> rs3MonstersCagegories)
        {
            var Rs3MonsterDict = new Dictionary<string, List<Rs3Monster>>();
            var tempMonsterList = new List<Rs3Monster>();
            foreach (var monster in rs3MonstersCagegories)
            {
                tempMonsterList.Add(Rs3BeastaryParser.GetRs3Monster(monster.Value));
            }

            var monsterNames = tempMonsterList.Select(m => m.NpcName).Distinct().ToList();
            foreach (var name in monsterNames)
            {
                Rs3MonsterDict[name] = tempMonsterList.Where(m => m.NpcName == name).ToList();
            }

            return Rs3MonsterDict;
        }
    }
}
