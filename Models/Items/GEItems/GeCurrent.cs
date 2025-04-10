using Newtonsoft.Json;
using RuneSharp.Helpers.MathHelpers;

namespace RuneSharp.Models.Items.GEItems
{
    public class GeCurrent
    {
        [JsonProperty("trend")]
        public string Trend { get; set; }

        [JsonProperty("price")]
        private string _sPrice { get; set; }
        private long _lPrice { get; set; }
       
        public long Price
        {
            get
            {
                return GetPrice();
            }
            set
            {
                value = _lPrice;
            }
        }

        private long GetPrice()
        {
            if(_sPrice != null || _sPrice != string.Empty)
            {
                return RsGpHelper.ConvertGpToLong(_sPrice);
            }
            return _lPrice;
        }

    }
}