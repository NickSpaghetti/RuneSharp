namespace RuneSharp.Test.Services.Foundations.OsrsMath;

public partial class OsrsMathTests
{
    [Test]
    public void CalculateActualCombatLevel_MinimumCombatLevel()
    {
        var combatLevel = _osRsMathService.CalculateActualCombatLevel(1, 1, 1, 10, 1, 1, 1);
        Assert.That(combatLevel, Is.EqualTo(3.0d));
    }
    
    [Test]
    public void CalculateActualCombatLevel_MaximumCombatLevel()
    {
        var combatLevel = _osRsMathService.CalculateActualCombatLevel(99, 99, 99, 99, 99, 99, 99);
        Assert.That(combatLevel, Is.EqualTo(126));
    }
}