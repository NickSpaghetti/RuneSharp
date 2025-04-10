using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.AccountTypes
{
    public interface IBaseHardcoreAccount : IBaseAccount
    {
        long HardcoreRank { get; set; }
        bool IsDead { get; set; }
    }
}
