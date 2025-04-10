using Newtonsoft.Json;
using RuneSharp.Models.Items.GEItems.Rs3;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Helpers.ParsersHelper.GrandExchangeParsers.Rs3
{
    public static class Rs3GrandExchangeParser
    {
        public static Rs3GrandExchangeItem ResloveItem(string jsonResults)
        {
            return JsonConvert.DeserializeObject<Rs3GrandExchangeItem>(jsonResults);
        }
    }
}
