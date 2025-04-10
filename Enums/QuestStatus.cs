using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RuneSharp.Enums
{
    public enum QuestStatus
    {
        [Description("NOT_STARTED")]
        Not_Started,
        [Description("STARTED")]
        Started,
        [Description("COMPLETED")]
        Completed
    }
}
