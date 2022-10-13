using RuneSharp.Models.Osrs;

namespace RuneSharp.Services.Foundations.OsRsMath;

public interface IOsRsMathService
{
    int GetCombatLevel(IEnumerable<OsrsSkill> skillList);

    int CalculateCombatLevel(int attack, int strength, int defence, int hitpoints, int magic,
        int ranged, int prayer);

    double CalculateActualCombatLevel(int attack, int strength, int defence, int hitpoints, int magic,
        int ranged, int prayer);
}