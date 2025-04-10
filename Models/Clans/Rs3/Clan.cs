using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Rs3.Clans
{
    public class Clan
    {
        [JsonProperty("rank")]
        public long Rank { get; set; }
        [JsonProperty("clan_name")]
        public string ClanName { get; set; }
        [JsonProperty("clan_mates")]
        public int ClanMatesCount { get; set; }
        public List<ClanMember> ClanMates { get; set; }
        [JsonProperty("xp_total")]
        public long TotalXP { get; set; }
        public long TotalKills { get; set; }
    }
}
