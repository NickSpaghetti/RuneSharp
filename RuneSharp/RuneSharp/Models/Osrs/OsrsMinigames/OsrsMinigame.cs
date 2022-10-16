namespace RuneSharp.Models.Osrs.OsrsMinigames;

public class OsrsMinigame : IOsrsMinigame
{
    public Enums.Osrs.OsrsMinigames Name { get; init; }
    public long Rank { get; set; }
}