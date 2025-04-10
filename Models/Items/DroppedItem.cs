using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Items
{
    public class DroppedItem : Item
    {
        public List<int> QuanityList = new List<int>();
        public List<int> Values = new List<int>();
        public ItemRarity Rarity { get; set; }
    }
}
