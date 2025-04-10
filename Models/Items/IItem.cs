using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Items
{
    public interface IItem
    {
        GameVersion GameVersion { get; set; }
    }
}
