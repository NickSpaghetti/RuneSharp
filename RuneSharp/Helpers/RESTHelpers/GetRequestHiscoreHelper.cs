using RuneSharp.Constants;
using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RuneSharp.Helpers.RESTHelpers
{
    public static class GetRequestHiscoreHelper
    {
        public static string GetAccountHiscores(string uri, string username)
        {
            return FindPlayer(uri,username);
        }

        public static long GetAccountHiscoreRank(string uri, string username)
        {
            var results = FindPlayer(uri, username);

            var splitResults = results.Split(new char[] { ',', '\n' });

            return Convert.ToInt32(splitResults[0]);
        }

        private static string FindPlayer(string uri, string username)
        {
            var webScraper = new WebClient();
            string result;
            try
            {
                result = webScraper.DownloadString(uri += username);
            }
            catch (Exception)
            {
                throw new Exception(string.Format("The username {0} was not found.", username));
            }

            return result;
        }
    }


}
