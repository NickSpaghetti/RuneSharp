using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Items.GEItems
{
    public class GeUpdate
    {
        [JsonProperty("lastConfigUpdateRuneday")]
        public long UpdatedDay { get; set; }

        public int Years { get; set; }

        public DateTime DateLastUpdated { get; set; }
    }
}
