using RuneSharp.Enums;
using RuneSharp.Helpers.AccountHelpers;
using RuneSharp.Models.Minigames;
using RuneSharp.Models.Quests.Rs3;
using RuneSharp.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.AccountTypes.Rs3
{
    public abstract class Rs3BaseAccount : IBaseAccount
    {
        public string Username { get; set; }
        public int CombatLevel { get; set; }
        public int TotalLevel { get; set; }
        public long TotalXP { get; set; }
        public long OverAllRank { get; set; }
        public int TotalQuestPoints {get; set;}
        public int YourQuestPoints { get; set; }
        public List<Rs3Quest> Quests { get; set; }
        public abstract GameVersion GameVersion { get; }
        public abstract AccountType AccountType { get; }
        public List<Rs3Skill> Skills { get; set; }
        public List<Rs3Minigame> Minigames { get; set; }

        public Rs3BaseAccount()
        {
            LoadSkills();
            LoadMinigames();
        }

        public virtual void LoadSkills()
        {
            Skills = SkillLoaderHelper.LoadRS3Skill();
        }

        public virtual void LoadMinigames()
        {
            Minigames = MinigameLoaderHelper.LoadRs3Minigames();
        }
    }
}
