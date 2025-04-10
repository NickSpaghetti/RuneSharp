namespace RuneSharp.Models.Osrs.OsrsLevels;

public class OsrsLevel : IOsrsLevel
{
    public long CurrentExperience { get; set; }
    public int CurrentLevel { get; set; }
    public long ExperienceToNextLevel { get; set; }
    public int NextLevel { get; set; }
}