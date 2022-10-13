using RuneSharp.Models.Enums.Osrs;

namespace RuneSharp.Models.Osrs;

public class OsrsSkill : IOsrsSkill
{
    public OsrsSkills Name { get; init; }
    public long TotalExperience { get; set; }
    public int Level { get; set; }
    public int ExperienceToNextLevel { get; set; }
    public long Rank { get; set; }
}