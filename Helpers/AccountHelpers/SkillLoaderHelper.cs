using RuneSharp.Enums;
using RuneSharp.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Helpers.AccountHelpers
{
    public static class SkillLoaderHelper
    {
        public static List<OsRsSkill> LoadOsRsSkills()
        {
            var SkillList = new List<OsRsSkill>();

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Attack,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat
                
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Defense,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Strength,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Hitpoints,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Range,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Prayer,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Magic,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat
               
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Cooking,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Woodcutting,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Fletching,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian
               
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Fishing,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Firemaking,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian
            
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Crafting,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Smithing,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Mining,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Herblore,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Artisian
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Agility,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Support
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Thieving,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Support
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Slayer,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Support
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Farming,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Support
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Runecrafting,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Hunter,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Artisian
                
            });

            SkillList.Add(new OsRsSkill()
            {
                Name = SkillName.Construction,
                Level = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Artisian
                
            });

            return SkillList;
        }


        public static List<Rs3Skill> LoadRS3Skill()
        {
            var SkillList = new List<Rs3Skill>();

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Attack,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat,
                SkillType = SkillType.Standard

            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Defense,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Strength,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Constitution,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Range,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Prayer,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Magic,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Combat,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Cooking,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Woodcutting,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Fletching,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Fishing,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Firemaking,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Crafting,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Smithing,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Mining,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Herblore,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Agility,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Support,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Thieving,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Support,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Slayer,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Support,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Farming,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Runecrafting,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Hunter,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Construction,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Summoning,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Combat,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Dungeoneering,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = false,
                SkillCategory = SkillCategory.Support,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Divination,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 83,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Artisian,
                SkillType = SkillType.Standard
            });

            SkillList.Add(new Rs3Skill()
            {
                Name = SkillName.Invention,
                Level = 1,
                VirtualLevel = 1,
                Rank = 0,
                Experence = 0,
                ExperenceToNextLevel = 830,
                IsMembersSkill = true,
                SkillCategory = SkillCategory.Support,
                SkillType = SkillType.Elite
            });

            return SkillList;
        }
    }
}
