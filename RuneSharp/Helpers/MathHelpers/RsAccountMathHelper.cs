using RuneSharp.Enums;
using RuneSharp.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuneSharp.Helpers.MathHelpers
{
    public static class RsAccountMathHelper
    {
        public static long XpAtLevelStandard(int level)
        {
            if (level >= 127)
            {
                return 200000000;
            }

            double sumXp = 0;
            for (int n = 1; n <= level - 1; n++)
            {
                double powerOf = n / 7.0;
                sumXp += Convert.ToDouble(Math.Floor(n + 300 * Math.Pow(2, powerOf)));
            }
            sumXp = Math.Floor(.25 * sumXp);
            return Convert.ToInt64(sumXp);
        }

        public static long XpAtLevelElite(long level)
        {
            if (level >= 150)
            {
                return 200000000;
            }
            else if (level <= 0)
            {
                return 0;
            }

            return Constants.Rs3Constants.EliteSkill.EliteSkillXpTable[level - 1];
        }

        public static int LevelAtExperenceElite(long xp)
        {
            int maxLevel = 150;
            int level = 0;
            int nextLevel = 1;
            for (int i = 0; i < maxLevel; i++)
            {
                nextLevel++;
                if (xp >= XpAtLevelElite(i) && xp <= XpAtLevelElite(nextLevel))
                {
                    level = i;
                }
            }

            return level;
        }

        public static long XpBetweenLevelsStandard(int startLevel, int desiredLevel)
        {
            return XpAtLevelStandard(desiredLevel) - XpAtLevelStandard(startLevel);
        }

        public static int LevelAtExperenceStandard(long xp)
        {
            int maxLevel = 127;
            int level = 0;
            int nextLevel = 1;
            for (int i = 1; i < maxLevel; i++)
            {
                nextLevel++;
                if (xp >= XpAtLevelStandard(i) && xp <= XpAtLevelStandard(nextLevel))
                {
                    level = i;
                }
            }

            return level;
        }

        public static int Rs3CombatLevelCalculator(List<Rs3Skill> skillList)
        {
            var combatSkillList = skillList.Where(s => s.SkillCategory == SkillCategory.Combat);
            var AttackSkill = combatSkillList.First(s => s.Name == SkillName.Attack).Level;
            var StrengthSkill = combatSkillList.First(s => s.Name == SkillName.Strength).Level;
            var DefenceSkill = combatSkillList.First(s => s.Name == SkillName.Defense).Level;
            var ConsititutionSkill = combatSkillList.First(s => s.Name == SkillName.Constitution).Level;
            var MagicSkill = combatSkillList.First(s => s.Name == SkillName.Magic).Level;
            var RangedSkill = combatSkillList.First(s => s.Name == SkillName.Range).Level;
            var PrayerSkill = combatSkillList.First(s => s.Name == SkillName.Prayer).Level;
            var SummoningSkill = combatSkillList.First(s => s.Name == SkillName.Summoning).Level;

            return Rs3CombatLevelCalculator(AttackSkill, StrengthSkill, DefenceSkill, ConsititutionSkill, MagicSkill, RangedSkill, PrayerSkill, SummoningSkill);
        }

        public static int Rs3CombatLevelCalculator(int attack, int strength, int defence, int consititution, int magic, int ranged, int prayer, int summoning)
        {
            var max = Math.Max(Math.Max(attack + strength, 2 * ranged), 2 * magic);
            var combatLevel = (1.3 * max + defence + consititution + Math.Floor(.5 * prayer) + Math.Floor(.5 * summoning)) / 4;

            return Convert.ToInt32(combatLevel);
        }

        public static int OsRsCombatLevelCalculator(List<OsRsSkill> skillList)
        {
            var combatSkillList = skillList.Where(s => s.SkillCategory == SkillCategory.Combat);
            var AttackSkill = combatSkillList.First(s => s.Name == SkillName.Attack).Level;
            var StrengthSkill = combatSkillList.First(s => s.Name == SkillName.Strength).Level;
            var DefenceSkill = combatSkillList.First(s => s.Name == SkillName.Defense).Level;
            var HitpointsSkill = combatSkillList.First(s => s.Name == SkillName.Hitpoints).Level;
            var MagicSkill = combatSkillList.First(s => s.Name == SkillName.Magic).Level;
            var RangedSkill = combatSkillList.First(s => s.Name == SkillName.Range).Level;
            var PrayerSkill = combatSkillList.First(s => s.Name == SkillName.Prayer).Level;

            return OsRsCombatLevelCalculator(AttackSkill, StrengthSkill, DefenceSkill, HitpointsSkill, MagicSkill, RangedSkill, PrayerSkill);
        }

        public static int OsRsCombatLevelCalculator(int attack, int strength, int defence, int hitpoints, int magic, int ranged, int prayer)
        {
            var Base = 0.25 * (defence + hitpoints + Math.Floor(prayer * .5));

            var Melee = 0.325 * (attack + strength);

            var Range = 0.325 * (Math.Floor(.5 * ranged) + ranged);

            var Mage = 0.325 * (Math.Floor(.5 * magic) + magic);

            var CombatLevel = Math.Floor(Base + Math.Max(Melee, Math.Max(Range, Mage)));

            return Convert.ToInt32(CombatLevel);
        }
    }
}
