using Newtonsoft.Json;
using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RuneSharp.Models.Skills.JsonSkillModel
{
    internal class JsonRs3Skill
    {
        [JsonProperty("name")]
        public string PlayerName { get; set; }
        [JsonProperty("score")]
        private string _xp { get; set; }
        public long XP
        {
            get
            {
                return long.Parse(_xp, NumberStyles.AllowThousands);
            }
        }

        [JsonProperty("rank")]
        public long SkillRank { get; set; }
    }
}
