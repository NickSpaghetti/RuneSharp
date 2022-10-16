using RuneSharp.Models.Enums.Osrs;
using RuneSharp.Models.Osrs;
using RuneSharp.Models.Osrs.OsrsMinigames;

namespace RuneSharp.Models.OsrsStandardAccount;

public interface IOsrsStandardAccount
{
    string UserName { get; set; }
    int CombatLevel { get; set; }
    int TotalLevel { get; set; }
    long TotalExperience { get; set; }
    IDictionary<OsrsSkills, OsrsSkill> Skills { get; }
    IDictionary<OsrsMinigames,OsrsMinigame> Minigames { get; }
}