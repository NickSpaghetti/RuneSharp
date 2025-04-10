using Newtonsoft.Json;
using RuneSharp.Enums;
using RuneSharp.Helpers.EnumHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace RuneSharp.Models.Items.GEItems
{
    public class GeItem
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icon_large")]
        public string IconLarge { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        private string _type { get; set; }
        private GrandExchangeItemCategory _itemCategory { get; set; }
        public GrandExchangeItemCategory ItemCategory
        {
            get
            {
                if (_type != null || _type != string.Empty)
                {
                    var toLower = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_type.ToLower());
                    var replaced = Regex.Replace(toLower, @"[^\w]", string.Empty);
                    return StringToEnumHelper.ToEnum<GrandExchangeItemCategory>(replaced);
                }
                return GrandExchangeItemCategory.Default;
            }
            set
            {
                value = _itemCategory;
            }
        }

        [JsonProperty("typeIcon")]
        public string TypeIcon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("current")]
        public GeCurrent Current { get; set; }

        [JsonProperty("today")]
        public GeCurrent Today { get; set; }

        [JsonProperty("members")]
        public bool IsMembers { get; set; }

        [JsonProperty(PropertyName = "day30")]
        public GePriceHistory ThirtyDays { get; set; }

        [JsonProperty(PropertyName = "day90")]
        public GePriceHistory NintyDays { get; set; }

        [JsonProperty(PropertyName = "day180")]
        public GePriceHistory OneHunderedEightyDays { get; set; }
    }
}
