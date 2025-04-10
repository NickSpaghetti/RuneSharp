using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Npcs.Monsters.Rs3
{
    public class Rs3MonsterVarrations
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
