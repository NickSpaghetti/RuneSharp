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
            TotalLevel = int.TryParse(splitResults[1], out var tempTotal) ? tempTotal : throw new Exception(),
            TotalExperience = int.TryParse(splitResults[2], out var tempTotalXp) ? tempTotalXp : throw new Exception(),
        };

        ParseOsrsSkills(account.Skills,splitResults);

        account.CombatLevel = _osrsMath.GetCombatLevel(account.Skills.Values);

        return account;

    }

    public void ParseOsrsSkills(IDictionary<OsrsSkills, OsrsSkill> skills, string[] csvData)
    {
        ParseOsrsSkill(OsrsSkills.Attack, 4, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Defense, 7, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Strength, 11, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Hitpoints, 14, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Range, 17, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Prayer, 20, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Magic, 23, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Cooking, 27, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Woodcutting, 30, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Fletching, 33, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Fishing, 36, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Firemaking, 39, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Crafting, 42, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Smithing, 45, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Mining, 48, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Herblore, 51, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Agility, 53, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Thieving, 56, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Farming, 59, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Runecrafting, 62, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Hunter, 65, skills, csvData);
        
        ParseOsrsSkill(OsrsSkills.Construction, 68, skills, csvData);
    }

    private void ParseOsrsSkill(OsrsSkills skillName, int startIndex, IDictionary<OsrsSkills, OsrsSkill> skills, string[] csvData)
    {
        var skill = skills.TryGetValue(skillName, out var tempSkill) ? tempSkill : null;
        if (skill is null)
        {
            throw new ArgumentNullException(nameof(skillName));
        }

        var totalExperienceIndex = startIndex++;
        var rankIndex = startIndex++;
        SetOsrsSkill(skill,csvData[startIndex],csvData[totalExperienceIndex],csvData[rankIndex]);
        
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
       
    }

    public void ParseOsrsMinigame(OsrsMinigames minigameName, int startIndex,
        IDictionary<OsrsMinigames, OsrsMinigame> minigames, string[] csvData)
    {
        var minigame = minigames.TryGetValue(minigameName, out var tempMinigame) ? tempMinigame : null;
        if (minigame is null)
        {
            throw new ArgumentNullException(nameof(minigame));
        }
        var rankIndex = startIndex++;
        SetOsrsMinigame(minigame,csvData[rankIndex]);
    }

    private void SetOsrsMinigame(OsrsMinigame minigame, string rank)
    {
        minigame.Rank = long.TryParse(rank, out var tempRank) ? tempRank : throw new Exception();
    }
}