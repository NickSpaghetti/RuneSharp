using RuneSharp.Enums;
using RuneSharp.Models.Rs3.Clans;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.Clans
{
    public interface IClanQuerying
    {
        List<Clan> GetTopThreeClans();
        List<Clan> GetTopThreeClansNoMembers();
        Clan GetClan(string clanName);
        List<Clan> GetManyClans(string[] clanNames);
        ClanMember GetClanMember(string clanName, string username);
        ClanRank GetMembersClanRank(string clanName, string username);
        long GetOverAllClanRank(string clanName);
    }
}
