using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Rs3.Clans
{
    public class ClanMember
    {
        public string Name { get; set; }
        public string ClanName { get; set; }
        public ClanRank ClanRank { get; set; }
        public long TotalXp { get; set; }
        public long Kills { get; set; }
        
    }
}
