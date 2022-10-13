using RuneSharp.Models.Enums.Osrs;

namespace RuneSharp.Models.Osrs;

public class OsrsStandardAccount : IOsrsStandardAccount
{
    public string UserName { get; set; } = string.Empty;
    public int CombatLevel { get; set; }
    public int TotalLevel { get; set; }
    public long TotalExperience { get; set; }
    public IDictionary<OsrsSkills, OsrsSkill> Skills { get; } = Enum.GetValues<OsrsSkills>()
        .Select(skill => new OsrsSkill { Name = skill })
        .ToDictionary(kvp => kvp.Name, skill => skill);
}