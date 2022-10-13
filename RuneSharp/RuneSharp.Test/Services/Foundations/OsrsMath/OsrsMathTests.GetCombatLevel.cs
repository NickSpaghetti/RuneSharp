using RuneSharp.Models.Enums.Osrs;
using RuneSharp.Models.Osrs;
using RuneSharp.Models.Osrs.Exceptions;
using RuneSharp.Services.Foundations.OsRsMath;

namespace RuneSharp.Test.Services.Foundations.OsrsMath;

public partial class OsrsMathTests
{
    private readonly IOsRsMathService _osRsMathService = new OsRsMathService();
    
    [Test]
    public void GetCombatLevel_ThrowsSkillNotFoundException_Attack()
    {
        var skills = new List<OsrsSkill>
        {
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Magic,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = 99
            }
        };

        Assert.Throws<OsrsSkillNotFoundException>(() =>
        {
            _osRsMathService.GetCombatLevel(skills);
        });

    }
    
    [Test]
    public void GetCombatLevel_ThrowsSkillNotFoundException_Strength()
    {
        var skills = new List<OsrsSkill>
        {
            new OsrsSkill
            {
                Name = OsrsSkills.Attack,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Magic,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = 99
            },
        };
        
        Assert.Throws<OsrsSkillNotFoundException>(() =>
        {
            _osRsMathService.GetCombatLevel(skills);
        });
    }
    
    [Test]
    public void GetCombatLevel_ThrowsSkillNotFoundException_Defense()
    {
        var skills = new List<OsrsSkill>
        {
            new OsrsSkill
            {
                Name = OsrsSkills.Attack,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Magic,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = 99
            },
        };
        
        Assert.Throws<OsrsSkillNotFoundException>(() =>
        {
            _osRsMathService.GetCombatLevel(skills);
        });
    }
    
    [Test]
    public void GetCombatLevel_ThrowsSkillNotFoundException_Hitpoints()
    {
        var skills = new List<OsrsSkill>
        {
            new OsrsSkill
            {
                Name = OsrsSkills.Attack,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Magic,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = 99
            },
        };
        
        Assert.Throws<OsrsSkillNotFoundException>(() =>
        {
            _osRsMathService.GetCombatLevel(skills);
        });
    }
    
    [Test]
    public void GetCombatLevel_ThrowsSkillNotFoundException_Range()
    {
        var skills = new List<OsrsSkill>
        {
            new OsrsSkill
            {
                Name = OsrsSkills.Attack,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Magic,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = 99
            },
        };
        
        Assert.Throws<OsrsSkillNotFoundException>(() =>
        {
            _osRsMathService.GetCombatLevel(skills);
        });
    }
    
    [Test]
    public void GetCombatLevel_ThrowsSkillNotFoundException_Magic()
    {
        var skills = new List<OsrsSkill>
        {
            new OsrsSkill
            {
                Name = OsrsSkills.Attack,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = 99
            },
        };
        
        Assert.Throws<OsrsSkillNotFoundException>(() =>
        {
            _osRsMathService.GetCombatLevel(skills);
        });
    }
    
    [Test]
    public void GetCombatLevel_ThrowsSkillNotFoundException_Prayer()
    {
        var skills = new List<OsrsSkill>
        {
            new OsrsSkill
            {
                Name = OsrsSkills.Attack,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = 99
            }
        };
        
        Assert.Throws<OsrsSkillNotFoundException>(() =>
        {
            _osRsMathService.GetCombatLevel(skills);
        });
    }
    
    
    
    [Test]
    public void GetCombatLevel_DoesNotThrowsSkillNotFoundException()
    {
        var skills = new List<OsrsSkill>
        {
            new OsrsSkill
            {
                Name = OsrsSkills.Attack,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Magic,
                Level = 99
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = 99
            },
        };
        
        Assert.Multiple(() =>
        {
            Assert.DoesNotThrow(() =>
            {
                _osRsMathService.GetCombatLevel(skills);
            });
            var cbLevel = _osRsMathService.GetCombatLevel(skills);
            Assert.That(cbLevel, Is.Not.Negative);
            Assert.That(cbLevel, Is.Not.LessThan(126));
            Assert.That(cbLevel, Is.EqualTo(126));
        });

    }
    
}