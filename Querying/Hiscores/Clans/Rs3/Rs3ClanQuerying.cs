using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuneSharp.Constants;
using RuneSharp.Enums;
using RuneSharp.Helpers.ParsersHelper.HiscoreParsers.Rs3;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.Rs3.Clans;

namespace RuneSharp.Querying.Hiscores.Clans.Rs3
{
    public class Rs3ClanQuerying : IClanQuerying
    {
        public Clan GetClan(string clanName)
        {
            var clanData = GetRequestClanHelper.GetClanContent(clanName).Trim();
            if (clanData.Contains(Rs3Constants.HTMLConstants.htmlDocType))
            {
                throw new Exception(string.Format("The Clan Name {0} does not exist", clanName));
            }
            var clan = Rs3ClanParser.CreateClan(clanName,clanData);
            return clan;
        }

        public List<Clan> GetManyClans(string[] clanNames)
        {
            var clanList = new List<Clan>();
            foreach (var clan in clanNames)
            {
                clanList.Add(GetClan(clan));
            }

            return clanList;
        }

        public ClanMember GetClanMember(string clanName, string username)
        {
            var member = GetClan(clanName).ClanMates.FirstOrDefault(rsn => rsn.Name == username);
            if(member == null)
            {
                throw new Exception(string.Format("{0} was not found as a member of {1}", username, clanName));
            }
            return member;
        }

        public ClanRank GetMembersClanRank(string clanName, string username)
        {
            var member = GetClanMember(clanName, username);
            return member.ClanRank;
        }

        public long GetOverAllClanRank(string clanName)
        {
            throw new NotImplementedException();
        }

        public List<Clan> GetTopThreeClans()
        {
            var clanList = GetTopThreeClansNoMembers();
            var fullClanList = new List<Clan>();
            foreach (var clan in clanList)
            {
                fullClanList.Add(GetClan(clan.ClanName));
            }
            return fullClanList;
        }

        public List<Clan> GetTopThreeClansNoMembers()
        {
            return GetRequestClanHelper.GetTopThreeClansContent();
        }

    }
}
