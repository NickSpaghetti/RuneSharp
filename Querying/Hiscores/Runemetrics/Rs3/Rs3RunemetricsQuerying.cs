using RuneSharp.Constants;
using RuneSharp.Enums;
using RuneSharp.Helpers.ParsersHelper.RunemetricsParser.Rs3;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.AccountTypes.Rs3;
using RuneSharp.Models.Quests;
using RuneSharp.Models.Quests.Rs3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuneSharp.Querying.Hiscores.Runemetrics.Rs3
{
    public class Rs3RunemetricsQuerying : IRunemetricsQuerying<Rs3Quest>
    {
        public List<Rs3Quest> AllQuests(string username)
        {
            var allQuests = GetRequestRunemetricsHelper.GetMetrics(string.Format(Rs3Constants.URIConstants.RuneMetricsConstants.Quests, username));
            var questList = Rs3RunemetricsParser.ParseRs3Quests(allQuests);
            return questList.QuestList;
        }

        public bool IsPlayerOnline(string username)
        {
            var allQuests = GetRequestRunemetricsHelper.GetMetrics(string.Format(Rs3Constants.URIConstants.RuneMetricsConstants.Quests, username));
            return Rs3RunemetricsParser.ParseRs3Quests(allQuests).IsLoggedIn;
        }

        public List<Rs3Quest> ManyQuests(string username, string[] questNames)
        {
            List<Rs3Quest> commonQuest = new List<Rs3Quest>();
            foreach (var quest in AllQuests(username))
            {
                foreach (var questName in questNames)
                {
                    if(quest.Name == questName)
                    {
                        commonQuest.Add(quest);
                    }
                }
            }

            return commonQuest;                    
        }

        public Rs3Quest SingleQuest(string username, string questName)
        {
            return AllQuests(username).FirstOrDefault(q => q.Name == questName);
        }

        public void FillInQuests(Rs3BaseAccount rs3BaseAccount)
        {
            rs3BaseAccount.Quests = AllQuests(rs3BaseAccount.Username);
            rs3BaseAccount.TotalQuestPoints = rs3BaseAccount.Quests.Sum(q => q.QuestPoints);
            rs3BaseAccount.YourQuestPoints = rs3BaseAccount.Quests.FindAll(qs => qs.Status == QuestStatus.Completed).Sum(qp => qp.QuestPoints);
        }
    }
}
