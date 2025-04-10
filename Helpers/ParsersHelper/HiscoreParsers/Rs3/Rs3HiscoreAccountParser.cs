using RuneSharp.Enums;
using RuneSharp.Helpers.AccountHelpers;
using RuneSharp.Helpers.MathHelpers;
using RuneSharp.Models.AccountTypes.Rs3;
using RuneSharp.Models.Minigames;
using RuneSharp.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Helpers.ParsersHelper.HiscoreParsers.Rs3
{
    public static class Rs3HiscoreAccountParser<AccountType>  where AccountType : Rs3BaseAccount
    {
        public static AccountType ParseAccount(string username, string results)
        {
            var splitResults = results.Split(new char[] { ',', '\n' });
            var account = Activator.CreateInstance<AccountType>();
            account = ParseRs3Account(account, splitResults);
            account.Username = username;
            account.CombatLevel = RsAccountMathHelper.Rs3CombatLevelCalculator(account.Skills);
            return account;
        }

        private static AccountType ParseRs3Account(AccountType baseAccount, string[] data )
        {
            baseAccount.OverAllRank = Convert.ToInt64(data[0]);
            baseAccount.TotalLevel = Convert.ToInt32(data[1]);
            baseAccount.TotalXP = Convert.ToInt64(data[2]);
            data = RemoveData(data, 0, 3);
            baseAccount.Skills = ParseRs3Skills(data);
            data = RemoveData(data, 0, baseAccount.Skills.Count * 3);
            baseAccount.Minigames = ParseRs3Minigames(data);
            return baseAccount;
        }

        private static List<Rs3Skill> ParseRs3Skills(string[] skillData)
        {
            var skillsList = SkillLoaderHelper.LoadRS3Skill();
            int count = 0;
            foreach (var skill in skillsList)
            {
                skill.Rank = Convert.ToInt64(skillData[count]);
                count++;
                skill.Level = Convert.ToInt32(skillData[count]);
                count++;
                skill.Experence = Convert.ToInt64(skillData[count]);
                count++;
            }
            skillsList = FillInVirtualLevel(skillsList);
            skillsList = FillInXpToNextLevel(skillsList);
            return skillsList;
        }

        private static List<Rs3Skill> FillInVirtualLevel(List<Rs3Skill> skillList)
        {
            foreach (var skill in skillList)
            {
                if(skill.SkillType == SkillType.Standard)
                {
                    skill.VirtualLevel = RsAccountMathHelper.LevelAtExperenceStandard(skill.Experence);
                }
                else if(skill.SkillType == SkillType.Elite)
                {
                    skill.VirtualLevel = RsAccountMathHelper.LevelAtExperenceElite(skill.Experence);
                }
            }
            return skillList;
        }
        private static List<Rs3Skill> FillInXpToNextLevel(List<Rs3Skill> skillsList)
        {
            foreach (var skill in skillsList)
            {
                if(skill.SkillType == SkillType.Standard)
                {
                    if (skill.Experence < RsAccountMathHelper.XpAtLevelStandard(128))
                    {
                        skill.ExperenceToNextLevel = RsAccountMathHelper.XpAtLevelStandard(skill.VirtualLevel+1) - skill.Experence;
                    }
                }
                else if(skill.SkillType == SkillType.Elite)
                {
                    if (skill.Experence < RsAccountMathHelper.XpAtLevelStandard(151))
                    {
                        skill.ExperenceToNextLevel = RsAccountMathHelper.XpAtLevelElite(skill.VirtualLevel+1) - skill.Experence;
                    }
                }
            }

            return skillsList;
        }

        private static List<Rs3Minigame> ParseRs3Minigames(string[] minigameData)
        {
            var minigameList = MinigameLoaderHelper.LoadRs3Minigames();
            int count = 0;
            foreach (var minigame in minigameList)
            {
                minigame.Rank = Convert.ToInt32(minigameData[count]);
                count++;
                minigame.Points = Convert.ToInt32(minigameData[count]);
                count++;
            }
            return minigameList;
        }

        private static string[] RemoveData(string[] dataArry, int start, int count)
        {
            var tempList = new List<string>(dataArry);
            tempList.RemoveRange(start, count);
            return dataArry = tempList.ToArray();
        }
    }
}
