using System;
using System.Collections.Generic;
using System.Text;
using RuneSharp.Constants;
using RuneSharp.Enums;
using RuneSharp.Helpers.ParsersHelper.GrandExchangeParsers;
using RuneSharp.Helpers.ParsersHelper.GrandExchangeParsers.OsRs;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.Items.GEItems;
using RuneSharp.Models.Items.GEItems.GeGraph;
using RuneSharp.Models.Items.GEItems.OsRs;

namespace RuneSharp.Querying.GrandExchange.OsRs
{
    public class OsRsGrandExchangeQuerying : IGrandExchangeQuerying<OsRsGrandExchangeItem, OsRsGrandExchangeItems>
    {
        public virtual GeUpdate LastGeUpdate()
        {
            var json = GetRequestGrandExchangeHelper.GetLastGeUpdateDate(OsRsConstants.URIConstants.GrandExchangeConstants.GELastUpdated);
            return GrandExchangeParser.ParseGeUpdate(json);
        }

        public OsRsGrandExchangeItem SingleItem(long itemId)
        {
            var uri = string.Format(OsRsConstants.URIConstants.GrandExchangeConstants.DetailItem, itemId);
            var itemString = GetRequestGrandExchangeHelper.FindItemById(uri);
            return OsRsGrandExchangeParser.ResloveItem(itemString);
        }

        public OsRsGrandExchangeItem SingleItem(string itemName)
        {
            var firstLetter = itemName.Remove(1, itemName.Length - 1).ToLower();
            var categoryUri = string.Format(OsRsConstants.URIConstants.GrandExchangeConstants.ItemsCategory, (int)GrandExchangeItemCategory.Default*-1, firstLetter, 1);
            var itemString = GetRequestGrandExchangeHelper.FindItem(itemName, categoryUri, OsRsConstants.URIConstants.GrandExchangeConstants.DetailItem);
            return OsRsGrandExchangeParser.ResloveItem(itemString);
        }

        public OsRsGrandExchangeItems ManyItems(long[] itemids)
        {
            var osGeItems = new OsRsGrandExchangeItems();
            foreach (var id in itemids)
            {
                var item = SingleItem(id);
                osGeItems.Items.Items.Add(item.Item);
            }

            return osGeItems;
        }

        public OsRsGrandExchangeItems ManyItems(string[] itemNames)
        {
            var osGeItems = new OsRsGrandExchangeItems();
            foreach (var name in itemNames)
            {
                var item = SingleItem(name);
                if(item != null && item.Item.Name != null)
                {
                    osGeItems.Items.Items.Add(item.Item);
                }
            }

            return osGeItems;
        }

        public GeGraphItemHistory ItemHistory(string itemName)
        {
            var geItem = SingleItem(itemName);
            if (geItem == null && geItem.Item == null)
            {
                return null;
            }
            var priceHistory = ItemHistory(geItem.Item.Id);

            return priceHistory;
        }

        public GeGraphItemHistory ItemHistory(long itemId)
        {
            var graphString = GetRequestGrandExchangeHelper.FindItemById(string.Format(OsRsConstants.URIConstants.GrandExchangeConstants.GEPriceHistory, itemId));
            return GrandExchangeParser.ParsePriceGraph(graphString);
        }
    }
}
