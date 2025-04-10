using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RuneSharp.Enums;

namespace RuneSharp.Models.Quests.Rs3
{
    public class Rs3Quests
    {
        [JsonProperty("quests")]
        public List<Rs3Quest> QuestList = new List<Rs3Quest>();

        [JsonProperty("loggedIn")]
        public bool IsLoggedIn { get; set; }
    }
}
