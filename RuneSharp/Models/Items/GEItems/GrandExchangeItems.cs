using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Items.GEItems
{
    public abstract class GrandExchangeItems : IGrandExchangeItem
    {
        public GrandExchangeItems()
        {
            Items = new GeItems();
        }
        public abstract GameVersion GameVersion { get; set; }
        public  GeItems Items { get;set; }
    }
}
