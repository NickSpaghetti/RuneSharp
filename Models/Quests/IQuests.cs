using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Quests
{
    public interface IQuests
    {
        string Name { get; set; }
        QuestDifficulty Difficulty { get; set; }
        bool IsMembers { get; set; }
        int QuestPoints { get; set; }
        bool IsEligible { get; set; }

    }
}
