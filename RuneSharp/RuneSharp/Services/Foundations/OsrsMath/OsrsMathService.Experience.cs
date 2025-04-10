namespace RuneSharp.Services.Foundations.OsrsMath;

public partial class OsrsMathService
{
    public const long MaxExperience = 200_000_000;
    public const long ExperienceAtLevel99 = 13_034_431;
    public const long MinExperience = 0;
    public const int MaxLevel = 127;
    public const int MinLevel = 1;
    public long ExperienceAtLevel(int level)
    {
        if (level >= MaxLevel)
        {
            return MaxExperience;
        }

        var sumXp = 0.0;
        for (var n = 1; n <= level - 1; n++)
        {
            var powerOf = n / 7.0;
            sumXp += Convert.ToDouble(Math.Floor(n + 300 * Math.Pow(2, powerOf)));
        }
        sumXp = Math.Floor(.25 * sumXp);
        
        return Convert.ToInt64(sumXp);
    }

    public int GetNextLevel(int currentLevel)
    {
        if (currentLevel >= MaxLevel)
        {
            return MaxLevel;
        }

        var nextLevel = currentLevel + 1;
        return nextLevel;
    } 

    public long ExperienceBetweenLevels(int startLevel, int targetLevel)
    {
        return ExperienceAtLevel(targetLevel) - ExperienceAtLevel(startLevel);
    }
    
    public int LevelAtExperience(long xp)
    {
        var level = 1;
        var nextLevel = 2;
        for (var i = 1; i < MaxLevel; i++)
        {
            if (xp >= ExperienceAtLevel(i) && xp <= ExperienceAtLevel(nextLevel))
            {
                level = i;
            }
            nextLevel++;
        }

        return level;
    }
    
}