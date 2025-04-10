using RuneSharp.Models.Items.GEItems;
using RuneSharp.Models.Items.GEItems.GeGraph;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.GrandExchange
{
    public interface IGrandExchangeQuerying<BaseItem, BaseItems> where BaseItem : GrandExchangeItem where BaseItems : GrandExchangeItems
    {
        GeUpdate LastGeUpdate();
        BaseItem SingleItem(long itemId);
        BaseItems ManyItems(long[] itemids);
        GeGraphItemHistory ItemHistory(long itemId);

        
    }
}
