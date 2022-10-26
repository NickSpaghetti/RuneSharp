namespace RuneSharp.Models.Osrs.OsrsMinigames;

public interface IOsrsMinigame
{
    public Enums.Osrs.OsrsMinigames Name { get; init; }
    public long Rank { get; set; }
    public int TimesCompleted { get; set; }
}