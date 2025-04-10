using RuneSharp.Enums;
using RuneSharp.Helpers.AccountHelpers;
using RuneSharp.Models.Minigames;
using RuneSharp.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.AccountTypes.OsRs
{
    public abstract class OsRsBaseAccount : IBaseAccount
    {
        public string Username { get; set; }
        public int CombatLevel { get; set; }
        public int TotalLevel { get; set; }
        public long TotalXP { get; set; }
        public long OverAllRank { get; set; }
        public abstract GameVersion GameVersion { get; }
        public abstract AccountType AccountType { get; }
        public List<OsRsSkill> Skills { get; set; }
        public List<OsRsMinigame> Minigames { get; set; }

        public OsRsBaseAccount()
        {
            LoadSkills();
            LoadMinigames();
        }

        public virtual void LoadSkills()
        {
            Skills = SkillLoaderHelper.LoadOsRsSkills();
        }

        public virtual void LoadMinigames()
        {
            Minigames = MinigameLoaderHelper.LoadOsRsMinigames();
        }
    }
}
