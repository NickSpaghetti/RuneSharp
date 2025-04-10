using Newtonsoft.Json;
using RuneSharp.Models.Items.GEItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RuneSharp.Helpers.RESTHelpers
{
    public static class GetRequestGrandExchangeHelper
    {
        public static string FindItem(string itemName, string categoryUri, string directUri)
        {
            var webScraper = new WebClient();
            string result = GetItemString(categoryUri);

            var items = JsonConvert.DeserializeObject<GeItems>(result);
            if(items == null || items.Items.Count == 0)
            {
                return string.Empty;
            }

            var item = items.Items.FirstOrDefault(i => i.Name == itemName);
            if(item != null)
            {
                directUri = ReplaceItemId(directUri, item.Id);
                result = FindItemById(directUri);
                if(result == null)
                {
                    return string.Empty;
                }
                else
                {
                    return result;
                }
            }
            else if(item == null)
            {
                var newCategoryUri = GetNextPageUri(categoryUri);
                return FindItem(itemName,newCategoryUri,directUri);
            }


            return result;
        }

        private static string ReplaceItemId(string directUri, long itemId)
        {
            var lastIndex = directUri.LastIndexOf("=")+1;
            string newDirectUri = directUri.Remove(lastIndex, directUri.Length - lastIndex);
            return newDirectUri + itemId.ToString();
        }

        private static string GetItemString(string uri)
        {
            var webScraper = new WebClient();
            string result = "";
            try
            {
                result = webScraper.DownloadString(uri);
            }
            catch (WebException)
            {
                throw new WebException(string.Format("Could not find the item"));
            }

            return result;
        }

        private static string GetNextPageUri(string currentUri)
        {
            var lastIndex = currentUri.LastIndexOf("=")+1;
            int currentPage = Convert.ToInt32(currentUri.Remove(0,lastIndex));
            int nextPage = currentPage + 1;
            var newUri = currentUri.Remove(lastIndex,currentUri.Length - lastIndex) + nextPage.ToString();

           return newUri;
        }

        public static string FindItemById(string uri)
        {
            var result = GetItemString(uri);
            return result;
        }

        public static string GetLastGeUpdateDate(string uri)
        {
            var webScraper = new WebClient();
            string result = "";
            try
            {
                result = webScraper.DownloadString(uri);
            }
            catch(WebException)
            {
                throw new WebException("Could not find the latest date");
            }

            return result;
        }
    }
}
