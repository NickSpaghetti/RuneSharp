using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RuneSharp.Constants;
using RuneSharp.Enums;
using RuneSharp.Helpers.EnumHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Quests
{
    public class Quest : IQuests
    {
        [JsonProperty("title")]
        public string Name { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public QuestStatus Status { get; set; }

        [JsonProperty("difficulty")]
        [JsonConverter(typeof(StringEnumConverter))]
        public  QuestDifficulty Difficulty { get; set; }

        [JsonProperty("members")]
        public bool IsMembers { get; set; }

        [JsonProperty("questPoints")]
        public int QuestPoints { get; set; }

        [JsonProperty("userEligible")]
        public bool IsEligible { get; set; }

    }
}
