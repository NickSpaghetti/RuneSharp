namespace RuneSharp.Services.Foundations.OsrsMath;

public partial interface IOsrsMathService
{
   long ExperienceAtLevel(int level);
   long ExperienceBetweenLevels(int startLevel, int targetLevel);
   int LevelAtExperience(long xp);
   int GetNextLevel(int currentLevel);
}