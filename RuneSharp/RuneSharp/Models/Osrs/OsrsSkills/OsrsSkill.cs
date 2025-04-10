using RuneSharp.Models.Enums.Osrs;
using RuneSharp.Models.Osrs.OsrsLevels;

namespace RuneSharp.Models.Osrs;

public class OsrsSkill : IOsrsSkill
{
    public OsrsSkills Name { get; init; }
    public OsrsLevel Level { get; init; }
    public long Rank { get; set; }
}