using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Enums;

namespace RuneSharp.Models.Items
{
    public class Item : IItem
    {
        public string ItemName { get; set; }
        public int Quanity { get; set; }
        public int Value { get; set; }
        public GameVersion GameVersion { get; set; }
    }
}
