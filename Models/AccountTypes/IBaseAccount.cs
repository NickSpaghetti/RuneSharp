using RuneSharp.Enums;
using RuneSharp.Models.Minigames;
using RuneSharp.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.AccountTypes
{
    public interface IBaseAccount
    {
        string Username { get; set; }
        int CombatLevel { get; set; }
        int TotalLevel { get; set; }
        long TotalXP { get; set; }
        long OverAllRank { get; set; }
        AccountType AccountType { get; }
        GameVersion GameVersion { get; }
    }
}
