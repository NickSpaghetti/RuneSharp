using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Constants;
using RuneSharp.Enums;
using RuneSharp.Helpers.ParsersHelper.GrandExchangeParsers;
using RuneSharp.Helpers.ParsersHelper.GrandExchangeParsers.Rs3;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.Items.GEItems;
using RuneSharp.Models.Items.GEItems.GeGraph;
using RuneSharp.Models.Items.GEItems.Rs3;

namespace RuneSharp.Querying.GrandExchange.Rs3
{
    public class Rs3GrandExchangeQuerying : IGrandExchangeQuerying<Rs3GrandExchangeItem, Rs3GrandExchangeItems>
    {
        public GeUpdate LastGeUpdate()
        {
            var json = GetRequestGrandExchangeHelper.GetLastGeUpdateDate(Constants.Rs3Constants.URIConstants.GrandExchangeConstants.GELastUpdated);
            return GrandExchangeParser.ParseGeUpdate(json);
        }

        public Rs3GrandExchangeItem SingleItem(long itemId)
        {
            var uri = string.Format(Constants.Rs3Constants.URIConstants.GrandExchangeConstants.DetailItem, itemId);
            var itemString = GetRequestGrandExchangeHelper.FindItemById(uri);
            return Rs3GrandExchangeParser.ResloveItem(itemString);
        }

        public Rs3GrandExchangeItem SingleItem(GrandExchangeItemCategory itemCategory, string itemName)
        {
            var firstLetter = itemName.Remove(1, itemName.Length-1).ToLower();
            var categoryUri = string.Format(Constants.Rs3Constants.URIConstants.GrandExchangeConstants.ItemsCategory, (int)itemCategory, firstLetter, 1);
            var itemString = GetRequestGrandExchangeHelper.FindItem(itemName, categoryUri, Constants.Rs3Constants.URIConstants.GrandExchangeConstants.DetailItem);
            return Rs3GrandExchangeParser.ResloveItem(itemString);
        }

        public Rs3GrandExchangeItems ManyItems(long[] itemids)
        {
            var rs3GeItems = new Rs3GrandExchangeItems();
            foreach (var id in itemids)
            {
                var item = SingleItem(id);
                if(item != null && item.Item.Name != null)
                {
                    rs3GeItems.Items.Items.Add(item.Item);
                }
            }

            return rs3GeItems;
        }

        public Rs3GrandExchangeItems ManyItems(Dictionary<GrandExchangeItemCategory, List<string>> itemNames)
        {
            var rs3GeItems = new Rs3GrandExchangeItems();
            foreach (KeyValuePair<GrandExchangeItemCategory, List<string>> pair in itemNames)
            {
                foreach (string value in pair.Value)
                {
                    var item = SingleItem(pair.Key, value);
                    if(item != null && item.Item.Name != null)
                    {
                        rs3GeItems.Items.Items.Add(item.Item);
                    }
                    
                }
                
            }

            return rs3GeItems;
        }

        public GeGraphItemHistory ItemHistory(GrandExchangeItemCategory itemCategory, string itemName)
        {
            var geItem = SingleItem(itemCategory,itemName);
            if(geItem == null && geItem.Item == null)
            {
                return null;
            }
            var priceHistory = ItemHistory(geItem.Item.Id);

            return priceHistory;
        }

        public GeGraphItemHistory ItemHistory(long itemId)
        {
            var graphString = GetRequestGrandExchangeHelper.FindItemById(string.Format(Rs3Constants.URIConstants.GrandExchangeConstants.GEPriceHistory,itemId));
            return GrandExchangeParser.ParsePriceGraph(graphString);
        }
    }
}
