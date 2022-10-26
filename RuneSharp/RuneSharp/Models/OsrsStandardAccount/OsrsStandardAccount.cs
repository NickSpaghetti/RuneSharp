using RuneSharp.Models.Enums.Osrs;
using RuneSharp.Models.Osrs;
using RuneSharp.Models.Osrs.OsrsLevels;
using RuneSharp.Models.Osrs.OsrsMinigames;

namespace RuneSharp.Models.OsrsStandardAccount;

public class OsrsStandardAccount : IOsrsStandardAccount
{
    public string UserName { get; set; } = string.Empty;
    public int CombatLevel { get; set; }
    
    public long StandardHiscoresRank { get; set; }
    public int TotalLevel { get; set; }
    public long TotalExperience { get; set; }

    public IDictionary<OsrsSkills, OsrsSkill> Skills { get; } = Enum.GetValues<OsrsSkills>()
        .Select(skill => new OsrsSkill 
            { Name = skill,
                Level = new OsrsLevel
                {
                    CurrentLevel = -1, 
                    CurrentExperience = -1,
                    ExperienceToNextLevel = -1,
                    NextLevel = -1
                }, 
                Rank = -1})
        .ToDictionary(kvp => kvp.Name, skill => skill);

    public IDictionary<OsrsMinigames, OsrsMinigame> Minigames { get; } = Enum.GetValues<OsrsMinigames>()
        .Select(minigame => 
            new OsrsMinigame 
                { 
                    Name = minigame,
                    Rank = -1 
                })
        .ToDictionary(kvp => kvp.Name, mingame => mingame);
}