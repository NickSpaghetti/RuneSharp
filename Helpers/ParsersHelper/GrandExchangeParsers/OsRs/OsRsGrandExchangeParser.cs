using Newtonsoft.Json;
using RuneSharp.Enums;
using RuneSharp.Models.Items.GEItems.OsRs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Helpers.ParsersHelper.GrandExchangeParsers.OsRs
{
    public static class OsRsGrandExchangeParser
    {
        public static OsRsGrandExchangeItem ResloveItem(string jsonResults)
        {
            return JsonConvert.DeserializeObject<OsRsGrandExchangeItem>(jsonResults);
        }
    }
}
