using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores.Rs3
{
    public class Rs3HiscoresAccountQuerying
    {
        public Rs3StandardHiscoreQuerying rs3StandardHiscores;
        public Rs3IronmanHiscoreQuerying rs3IronmanHiscores;
        public Rs3HardcoreIronmanHiscoreQuerying rs3HardcoreIronmanHiscores;
        public Rs3HiscoresAccountQuerying()
        {
            rs3StandardHiscores = new Rs3StandardHiscoreQuerying();
            rs3IronmanHiscores = new Rs3IronmanHiscoreQuerying();
            rs3HardcoreIronmanHiscores = new Rs3HardcoreIronmanHiscoreQuerying();
        }
    }
}
