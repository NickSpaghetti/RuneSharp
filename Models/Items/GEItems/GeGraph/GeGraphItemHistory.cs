using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Items.GEItems.GeGraph
{
    public class GeGraphItemHistory
    {
        public ItemPriceChange Daily;
        public ItemPriceChange Average;
        public GeGraphItemHistory()
        {
            Daily = new ItemPriceChange()
            {
                PriceChangeOverOneHunderedEightyDays = _dailyOneHundredEightyDayPriceHistory
            };

            Average = new ItemPriceChange()
            {
                PriceChangeOverOneHunderedEightyDays = _averageOneHundredEightyDayPriceHistory
            };
        }

        [JsonProperty("daily")]
        private SortedDictionary<string, long> _dailyOneHundredEightyDayPriceHistory = new SortedDictionary<string, long>();
        



        [JsonProperty("average")]
        private SortedDictionary<string, long> _averageOneHundredEightyDayPriceHistory = new SortedDictionary<string, long>();
        

    }
}
