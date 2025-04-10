namespace RuneSharp.Test.Services.Foundations.OsrsMath;

public partial class OsrsMathTests
{
    [Test]
    public void CalculateCombatLevel_MinimumCombatLevel()
    {
        var combatLevel = _osRsMathService.CalculateCombatLevel(1, 1, 1, 10, 1, 1, 1);
        Assert.That(combatLevel, Is.EqualTo(3));
    }
    
    [Test]
    public void CalculateCombatLevel_MaximumCombatLevel()
    {
        var combatLevel = _osRsMathService.CalculateCombatLevel(99, 99, 99, 99, 99, 99, 99);
        Assert.That(combatLevel, Is.EqualTo(126));
    }
}