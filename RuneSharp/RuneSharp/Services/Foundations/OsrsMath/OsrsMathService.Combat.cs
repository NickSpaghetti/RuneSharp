using RuneSharp.Models.Enums.Osrs;
using RuneSharp.Models.Osrs;
using RuneSharp.Models.Osrs.Exceptions;

namespace RuneSharp.Services.Foundations.OsrsMath;

public partial class OsrsMathService : IOsrsMathService
{
    public int GetCombatLevel(IEnumerable<OsrsSkill> skills)
    {
        skills = skills.ToList();
        var attackLevel = skills.FirstOrDefault(s => s.Name == OsrsSkills.Attack)
            ?.Level.CurrentLevel ?? throw new OsrsSkillNotFoundException(nameof(OsrsSkills.Attack));
        
        var strengthLevel = skills.FirstOrDefault(s => s.Name == OsrsSkills.Strength)
            ?.Level.CurrentLevel ?? throw new OsrsSkillNotFoundException(nameof(OsrsSkills.Strength));
        
        var defenceLevel = skills.FirstOrDefault(s => s.Name == OsrsSkills.Defense)
            ?.Level.CurrentLevel ?? throw new OsrsSkillNotFoundException(nameof(OsrsSkills.Defense));
        
        var hitpointsLevel = skills.FirstOrDefault(s => s.Name == OsrsSkills.Hitpoints)
            ?.Level.CurrentLevel ?? throw new OsrsSkillNotFoundException(nameof(OsrsSkills.Hitpoints));
        
        var magicLevel = skills.FirstOrDefault(s => s.Name == OsrsSkills.Magic)
            ?.Level.CurrentLevel ?? throw new OsrsSkillNotFoundException(nameof(OsrsSkills.Magic));
        
        var rangedLevelLevel = skills.FirstOrDefault(s => s.Name == OsrsSkills.Range)
            ?.Level.CurrentLevel ?? throw new OsrsSkillNotFoundException(nameof(OsrsSkills.Range));
        
        var prayerLevel = skills.FirstOrDefault(s => s.Name == OsrsSkills.Prayer)
            ?.Level.CurrentLevel ?? throw new OsrsSkillNotFoundException(nameof(OsrsSkills.Prayer));
        
        return CalculateCombatLevel(attackLevel, strengthLevel, defenceLevel, hitpointsLevel, magicLevel, 
            rangedLevelLevel, prayerLevel);
    }

    public int CalculateCombatLevel(int attack, int strength, int defence, int hitpoints, int magic,
        int ranged, int prayer)
    {
        return Convert.ToInt32(CalculateActualCombatLevel(attack, strength, defence, hitpoints, magic, ranged, prayer));
    }
    
    public double CalculateActualCombatLevel(int attack, int strength, int defence, int hitpoints, int magic,
        int ranged, int prayer)
    {
        var Base = 0.25 * (defence + hitpoints + Math.Floor(prayer * .5));

        var Melee = 0.325 * (attack + strength);

        var Range = 0.325 * (Math.Floor(.5 * ranged) + ranged);

        var Mage = 0.325 * (Math.Floor(.5 * magic) + magic);

        var CombatLevel = Math.Floor(Base + Math.Max(Melee, Math.Max(Range, Mage)));

        return CombatLevel;
    }
}