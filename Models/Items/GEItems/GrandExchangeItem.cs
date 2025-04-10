using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;

namespace RuneSharp.Models.Items.GEItems
{
    public abstract class GrandExchangeItem : IGrandExchangeItem
    {
        public GrandExchangeItem()
        {
            Item = new GeItem();
        }
        public abstract GameVersion GameVersion { get; set; }
        public GeItem Item {get; set;}
    }
}
