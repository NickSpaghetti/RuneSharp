using RuneSharp.Models.Enums.Osrs;
using RuneSharp.Models.Osrs.OsrsLevels;

namespace RuneSharp.Models.Osrs;

public interface IOsrsSkill
{
    OsrsSkills Name { get; init; }
    OsrsLevel Level { get; init; }
    public long Rank { get; set; }
}