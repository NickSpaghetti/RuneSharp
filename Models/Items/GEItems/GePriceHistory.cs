using Newtonsoft.Json;
using RuneSharp.Helpers.MathHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Items.GEItems
{
    public class GePriceHistory
    {
        [JsonProperty("trend")]
        public string Trend { get; set; }

        [JsonProperty("change")]
        private string _sPrice { get; set; }

        private double _percentChange { get; set; }

        public double PercentChange
        {
            get
            {
                if(_sPrice != null || _sPrice != string.Empty)
                {
                    double percent = RsGpHelper.ConvertGpToLong(_sPrice);
                    return percent / 100;
                }
                return _percentChange;
            }
            set
            {
                _percentChange = value;
            }
        }
    }
}
