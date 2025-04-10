using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RuneSharp.Helpers.RESTHelpers
{
    public static class GetRequestRunemetricsHelper
    {
        public static string GetMetrics(string uri)
        {
            var webScraper = new WebClient();
            string result;
            try
            {
                result = webScraper.DownloadString(uri);
            }
            catch (Exception)
            {
                throw new Exception(string.Format("The uri was not found."));
            }

            return result;
        }
    }
}
