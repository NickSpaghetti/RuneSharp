using Newtonsoft.Json;
using RuneSharp.Models.Quests.Rs3;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Helpers.ParsersHelper.RunemetricsParser.Rs3
{
    public static class Rs3RunemetricsParser
    {
        public static Rs3Quests ParseRs3Quests(string results)
        {
            var questInfo = JsonConvert.DeserializeObject<Rs3Quests>(results);
            return questInfo;
        }

        public static void ParseAdventureLog(string results)
        {

        }

        public static void ParseMontlyXP(string results)
        {

        }
    }
}
