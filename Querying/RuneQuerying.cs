using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying
{
    public class RuneQuerying
    {
        public OsRsQuerying osRsQuerying;
        public Rs3Querying rs3Querying;
        public RuneQuerying()
        {
            osRsQuerying = new OsRsQuerying();
            rs3Querying = new Rs3Querying();
        }
    }
}
