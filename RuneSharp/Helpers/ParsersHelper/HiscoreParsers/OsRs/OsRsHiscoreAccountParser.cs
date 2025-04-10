using RuneSharp.Helpers.AccountHelpers;
using RuneSharp.Helpers.MathHelpers;
using RuneSharp.Models.AccountTypes.OsRs;
using RuneSharp.Models.Minigames;
using RuneSharp.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuneSharp.Helpers.ParsersHelper.HiscoreParsers.OsRs
{
    public class OsRsHiscoreAccountParser<AccountType> where AccountType : OsRsBaseAccount
    {
        public static AccountType ParseAccount(string username, string results)
        {
            var splitResults = results.Split(new char[] { ',', '\n' });
            var account = Activator.CreateInstance<AccountType>();
            account = ParseOsRsAccount(account, splitResults);
            account.Username = username;
            account.CombatLevel = RsAccountMathHelper.OsRsCombatLevelCalculator(account.Skills);
            return account;
        }

        private static AccountType ParseOsRsAccount(AccountType baseAccount, string[] data)
        {
            baseAccount.OverAllRank = ConvertToLong(data[0]);
            baseAccount.TotalLevel = ConvertToInt(data[1]);
            baseAccount.TotalXP = ConvertToLong(data[2]);
            data = RemoveData(data, 0, 3);
            baseAccount.Skills = ParseOsRsSkills(data);
            data = RemoveData(data, 0, baseAccount.Skills.Count * 3);
            baseAccount.Minigames = ParseOsRsMinigames(data);
            return baseAccount;
        }

        private static List<OsRsSkill> ParseOsRsSkills(string[] skillData)
        {
            var skillsList = SkillLoaderHelper.LoadOsRsSkills();
            int count = 0;
            foreach (var skill in skillsList)
            {
                skill.Rank = ConvertToLong(skillData[count]);
                count++;
                skill.Level = ConvertToInt(skillData[count]);
                count++;
                skill.Experence = ConvertToLong(skillData[count]);
                count++;
            }

            skillsList = FillInXpToNextLevel(skillsList);
            return skillsList;
        }

        private static List<OsRsSkill> FillInXpToNextLevel(List<OsRsSkill> skillsList)
        {
            foreach (var skill in skillsList)
            {
                if (skill.Experence < RsAccountMathHelper.XpAtLevelStandard(128))
                {
                    var currentVirtualLevel = RsAccountMathHelper.LevelAtExperenceStandard(skill.Experence);
                    skill.ExperenceToNextLevel = RsAccountMathHelper.XpAtLevelStandard(currentVirtualLevel += 1) - skill.Experence;
                }
            }

            return skillsList;
        }

        private static List<OsRsMinigame> ParseOsRsMinigames(string[] minigameData)
        {
            var minigameList = MinigameLoaderHelper.LoadOsRsMinigames();
            int count = 0;
            minigameData = minigameData.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            foreach (var minigame in minigameList)
            {
                minigame.Rank = ConvertToLong(minigameData[count]);
                count++;
                minigame.Points = ConvertToLong(minigameData[count]);
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

        private static long ConvertToLong(string value)
        {
            long outValue = -1;
            long.TryParse(value, out outValue);
            return outValue;
        }

        private static int ConvertToInt(string value)
        {
            int outValue = -1;
            int.TryParse(value, out outValue);
            return outValue;
        }
    }
}
