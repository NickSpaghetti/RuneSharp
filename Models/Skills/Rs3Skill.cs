using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Skills
{
    public class Rs3Skill : Skill
    {
        public int VirtualLevel { get; set; }
        public SkillType SkillType { get; set; }
    }
}
