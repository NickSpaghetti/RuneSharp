using RuneSharp.Models.Enums.Osrs;

namespace RuneSharp.Models.Osrs;

public interface IOsrsSkill
{
    OsrsSkills Name { get; init; }
    long TotalExperience { get; set; }
    int Level { get; set; }
    int ExperienceToNextLevel { get; set; }
    long Rank { get; set; }
}