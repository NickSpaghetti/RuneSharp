using RuneSharp.Models.Enums.Osrs;

namespace RuneSharp.Models.Osrs;

public interface IOsrsStandardAccount
{
    string UserName { get; set; }
    int CombatLevel { get; set; }
    int TotalLevel { get; set; }
    long TotalExperience { get; set; }
    IDictionary<OsrsSkills, OsrsSkill> Skills { get; }
}