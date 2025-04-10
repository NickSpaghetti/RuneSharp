using Newtonsoft.Json;
using RuneSharp.Models.Items.GEItems;
using RuneSharp.Models.Items.GEItems.GeGraph;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Helpers.ParsersHelper.GrandExchangeParsers
{
    public static class GrandExchangeParser
    {
        public static GeUpdate ParseGeUpdate(string results)
        {
            var updatedGe = JsonConvert.DeserializeObject<GeUpdate>(results);
            updatedGe.Years = Convert.ToInt32(updatedGe.UpdatedDay / 365);
            updatedGe.DateLastUpdated = DateTime.Now;
            return updatedGe;

        }

        public static GeGraphItemHistory ParsePriceGraph(string results)
        {
            var grandExchangePriceHistory = JsonConvert.DeserializeObject<GeGraphItemHistory>(results);
            return grandExchangePriceHistory;
        }
    }
}
