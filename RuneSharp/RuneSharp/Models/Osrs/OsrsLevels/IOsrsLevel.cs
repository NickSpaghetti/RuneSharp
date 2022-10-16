namespace RuneSharp.Models.Osrs.OsrsLevels;

public interface IOsrsLevel
{
    public long CurrentExperience { get; set; }
    public int CurrentLevel { get; set; }
    public long ExperienceToNextLevel { get; set; }
    public int NextLevel { get; set; }
}