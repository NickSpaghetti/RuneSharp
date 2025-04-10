using RuneSharp.Models.Enums.Osrs;
using RuneSharp.Models.Osrs;
using RuneSharp.Models.Osrs.Exceptions;
using RuneSharp.Models.Osrs.OsrsLevels;
using RuneSharp.Services.Foundations.OsrsMath;

namespace RuneSharp.Test.Services.Foundations.OsrsMath;

public partial class OsrsMathTests
{
    private readonly IOsrsMathService _osRsMathService = new OsrsMathService();

    private static OsrsLevel GetLevel99() => new OsrsLevel
    {
        CurrentLevel = 99,
        CurrentExperience = OsrsMathService.ExperienceAtLevel99
    };
    [Test]
    public void GetCombatLevel_ThrowsSkillNotFoundException_Attack()
    {
        var skills = new List<OsrsSkill>
        {
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Magic,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = GetLevel99()
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
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Magic,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = GetLevel99()
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
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Magic,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = GetLevel99()
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
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Magic,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = GetLevel99()
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
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Magic,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = GetLevel99()
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
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = GetLevel99()
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
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = GetLevel99()
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
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Strength,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Defense,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Hitpoints,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Range,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Magic,
                Level = GetLevel99()
            },
            new OsrsSkill
            {
                Name = OsrsSkills.Prayer,
                Level = GetLevel99()
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