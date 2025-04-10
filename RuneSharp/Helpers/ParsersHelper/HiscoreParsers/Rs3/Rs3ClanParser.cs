using RuneSharp.Enums;
using RuneSharp.Helpers.EnumHelpers;
using RuneSharp.Models.Rs3.Clans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuneSharp.Helpers.ParsersHelper.HiscoreParsers.Rs3
{
    public static class Rs3ClanParser
    {
        public static Clan CreateClan(string clanName,string clanCSVData)
        {
            var clanDataArray = clanCSVData.Split('\n');
            var clan = new Clan();
            clan.ClanName = clanName;
            clan.ClanMates = GetClanMates(clanName, clanDataArray);
            clan.ClanMatesCount = clan.ClanMates.Count;
            clan.TotalXP = clan.ClanMates.Sum(x => x.TotalXp);
            clan.TotalKills = clan.ClanMates.Sum(k => k.Kills);

            return clan;
        }

        private static List<ClanMember> GetClanMates(string clanName, string[] clanDataArray)
        {
            var clanMemberList = new List<ClanMember>();
            var memberList = clanDataArray.ToList();
            memberList.RemoveAt(0);
            foreach (var feild in memberList)
            {
                var clanMember = new ClanMember();
                var feildArray = feild.Split(',');
                clanMember.Name = feildArray[0];
                clanMember.ClanRank = StringToEnumHelper.ToEnum<ClanRank>(feildArray[1].Replace(" ", ""));
                clanMember.TotalXp = Convert.ToInt64(feildArray[2]);
                clanMember.Kills = Convert.ToInt64(feildArray[3]);
                clanMember.ClanName = clanName;
                clanMemberList.Add(clanMember);
            }
            return clanMemberList;
        }

        
    }
}
