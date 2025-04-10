using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Items.GEItems
{
    public class GeItems
    {
        public GeItems()
        {
            Items = new List<GeItem>();
        }
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("items")]
        public List<GeItem> Items { get; set; }
    }
}
