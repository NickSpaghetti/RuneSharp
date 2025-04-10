using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.AccountTypes
{
    public interface IIronmanBaseAccount : IBaseAccount
    {
        long IronmanRank { get; set; }
    }
}
