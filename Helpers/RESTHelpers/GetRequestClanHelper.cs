using Newtonsoft.Json;
using RuneSharp.Constants;
using RuneSharp.Helpers.StringHelpers;
using RuneSharp.Models.Rs3.Clans;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace RuneSharp.Helpers.RESTHelpers
{
    public static class GetRequestClanHelper
    {
        public static string GetClanContent(string clanName)
        {

            WebClient client = new WebClient();
            var stream = client.DownloadString(System.Web.HttpUtility.UrlPathEncode(Rs3Constants.URIConstants.ClanHiscoreConstants.GetClan + clanName));
            var content = HtmlStringHelper.CheckAndRemoveHtmlCharacter(stream, '\uFFFD');
      
            return content;
        }

        public static List<Clan> GetTopThreeClansContent()
        {  
            WebClient client = new WebClient();
            var result = client.DownloadString(Rs3Constants.URIConstants.ClanHiscoreConstants.TopThreeClans);
            var clanList = JsonConvert.DeserializeObject<List<Clan>>(result);
            return clanList;
        }
    }
}
