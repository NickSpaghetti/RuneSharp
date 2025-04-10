using RuneSharp.Constants;
using RuneSharp.Models.Enums.Osrs;
using RuneSharp.Models.Osrs;
using RuneSharp.Models.Osrs.OsrsMinigames;
using RuneSharp.Models.OsrsStandardAccount;

namespace RuneSharp.Services.Foundations.OsrsHiscoreStandard;

public partial class OsrsHiscoreStandardService
{
    public OsrsStandardAccount ParseAccount(string userName, string csv)
    {
        var splitResults = csv.Split(OsrsConstants.CsvResultConstants.SplitOn, StringSplitOptions.TrimEntries);
        var account = new OsrsStandardAccount()
        {
            UserName = userName,
            StandardHiscoresRank = int.TryParse(splitResults[0], out var tempRank) ? tempRank : throw new Exception(),
            TotalLevel = int.TryParse(splitResults[1], out var tempTotal) ? tempTotal : throw new Exception(),
            TotalExperience = long.TryParse(splitResults[2], out var tempTotalXp) ? tempTotalXp : throw new Exception(),
        };

        ParseOsrsSkills(account.Skills,splitResults);
        ParseOsrsMinigames(account.Minigames,splitResults);

        account.CombatLevel = _osrsMath.GetCombatLevel(account.Skills.Values);

        return account;

    }

    public void ParseOsrsSkills(IDictionary<OsrsSkills, OsrsSkill> skills, string[] csvData)
    {
        ParseOsrsSkill(OsrsSkills.Attack,        3, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Defense,       6, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Strength,      9, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Hitpoints,    12, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Range,        15, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Prayer,       18, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Magic,        21, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Cooking,      24, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Woodcutting,  27, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Fletching,    30, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Fishing,      33, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Firemaking,   36, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Crafting,     39, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Smithing,     42, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Mining,       45, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Herblore,     48, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Agility,      51, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Thieving,     54, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Slayer,       57, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Farming,      60, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Runecrafting, 63, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Hunter,       66, skills, csvData);
        ParseOsrsSkill(OsrsSkills.Construction, 69, skills, csvData);
    }

    private void ParseOsrsSkill(OsrsSkills skillName, int startIndex, IDictionary<OsrsSkills, OsrsSkill> skills, string[] csvData)
    {
        var skill = skills.TryGetValue(skillName, out var tempSkill) ? tempSkill : null;
        if (skill is null)
        {
            throw new ArgumentNullException(nameof(skillName));
        }

        var rankIndex = startIndex;
        var level = startIndex + 1;
        var totalExperienceIndex = startIndex + 2;
        SetOsrsSkill(skill,csvData[level],csvData[totalExperienceIndex],csvData[rankIndex]);
        
    }

    private void SetOsrsSkill(OsrsSkill skill, string level, string totalExperience, string rank)
    {
        skill.Level.CurrentLevel = int.TryParse(level, out var tempLevel) ? tempLevel : throw new Exception();
        skill.Level.CurrentExperience = long.TryParse(totalExperience, out var tempTotalXp) ? tempTotalXp : throw new Exception();
        skill.Level.ExperienceToNextLevel = 0;
        skill.Level.NextLevel = _osrsMath.GetNextLevel(skill.Level.CurrentLevel);
        skill.Level.ExperienceToNextLevel = _osrsMath.ExperienceBetweenLevels(skill.Level.CurrentLevel,skill.Level.NextLevel);
        skill.Rank = long.TryParse(rank, out var tempRank) ? tempRank : throw new Exception();
    }

    public void ParseOsrsMinigames(IDictionary<OsrsMinigames, OsrsMinigame> minigames, string[] csvData)
    {
        ParseOsrsMinigame(OsrsMinigames.LeaugePoints,                  72,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.BountyHunterHunter,            74,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.BountyHunterRogue,             76,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.ClueScrollAll,                 78,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.ClueScrollBeginner,            80,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.ClueScrollEasy,                82,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.ClueScrollMedium,              84,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.ClueScrollHard,                86,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.ClueScrollElite,               88,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.ClueScrollMaster,              90,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.LastManStanding,               92,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.PvPAreana,                     94,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.SoulWarsZeal,                  96,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.GuardiansOfTheRift,            98,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.AbyssalSire,                   100,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.AlchemicalHydra,               102,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.BarrowsChests,                 104,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Bryophyta,                     106,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Callisto,                      108,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Cerberus,                      110,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.ChambersOfXeric,               112,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.ChambersOfXericChallangeMode,  114,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.ChaosElemental,                116,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.ChaosFanatic,                  118,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.CommanderZilyana,              120,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.CorporealBeast,                122,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.CrazyArchaeologist,            124,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.DagannothPrime,                126,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.DagannothSupreme,              128,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.DagannothRex,                  130,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.DerangedArchaeologist,         132,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.GeneralGraador,                134,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.GiantMole,                     136,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.GrotesqueGardians,             138,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Hespori,                       140,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.KalphiteQueen,                 142,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.KingBlackDragon,               144,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Kraken,                        146,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.KreeArra,                      148,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.KrillTsutsaroth,               150,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Mimic,                         152,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Nex,                           154,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Nightmare,                     156,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.PhosanisNightmare,             158,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Obor,                          160,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Sarachnis,                     162,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Scorpia,                       164,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Skotizo,                       166,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Tempoross,                     168,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.TheGauntlet,                   170,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.TheCorruptedGauntlet,          172,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.TheatreOfBlood,                174,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.TheatreOfBloodHardMode,        176,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.ThermonuclearSmokeDevil,       178,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.TombsOfAmascut,                180,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.TombsOfAmascutExpertMode,      182,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.TzKalZuk,                      184,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.TzTokJad,                      186,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Venenatis,                     188,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Vetion,                        190,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Vorkath,                       192,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Wintertodt,                    194,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Zalcano,                       196,minigames,csvData);
        ParseOsrsMinigame(OsrsMinigames.Zulrah,                        198,minigames,csvData);
    }

    public void ParseOsrsMinigame(OsrsMinigames minigameName, int startIndex,
        IDictionary<OsrsMinigames, OsrsMinigame> minigames, string[] csvData)
    {
        var minigame = minigames.TryGetValue(minigameName, out var tempMinigame) ? tempMinigame : null;
        if (minigame is null)
        {
            throw new ArgumentNullException(nameof(minigame));
        }

        var rankIndex = startIndex;
        var kcIndex = startIndex + 1;
        SetOsrsMinigame(minigame,csvData[rankIndex],csvData[kcIndex]);
    }

    private void SetOsrsMinigame(OsrsMinigame minigame, string rank, string timesCompleted)
    {
        minigame.Rank = long.TryParse(rank, out var tempRank) ? tempRank : throw new Exception();
        minigame.TimesCompleted = int.TryParse(timesCompleted, out var tempKc) ? tempKc : throw new Exception();
    }
}