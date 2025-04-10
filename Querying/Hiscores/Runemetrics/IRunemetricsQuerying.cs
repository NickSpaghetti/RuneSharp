using RuneSharp.Models.Quests;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.Runemetrics
{
    public interface IRunemetricsQuerying<QuestVersion> where QuestVersion : IQuests
    {
        QuestVersion SingleQuest(string username,string questName);
        List<QuestVersion> ManyQuests(string username, string[] questNames);
        List<QuestVersion> AllQuests(string username);
        bool IsPlayerOnline(string username);

    }
}
