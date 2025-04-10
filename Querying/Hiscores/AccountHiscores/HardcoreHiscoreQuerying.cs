using RuneSharp.Constants;
using RuneSharp.Enums;
using RuneSharp.Helpers.StringHelpers;
using RuneSharp.Models.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores
{
    public abstract class HardcoreHiscoreQuerying<HardcoreAccountType> : HiscoreQuerying<HardcoreAccountType>, IHardcoreHiscoreQuerying<HardcoreAccountType> where HardcoreAccountType : IBaseHardcoreAccount
    {
        public virtual bool IsAccountEliminated(HardcoreAccountType hardcoreType)
        {
            bool isDead = false;
            if (hardcoreType.GameVersion == GameVersion.OldSchool)
            {
                var uri = GetPageUrl(hardcoreType, OsRsConstants.URIConstants.HiscoreConstants.HtmlHiscoreConstants.HardcoreIronman, OsRsConstants.HTMLConstants.PageRankSize);
                uri = ValidateAndReturnUri(uri);
                isDead = FindPlayerDeadHtml(uri, OsRsConstants.HTMLConstants.HtmlOffSet, hardcoreType.Username, OsRsConstants.HTMLConstants.PlayerDead);
            }
            else if (hardcoreType.GameVersion == GameVersion.Runescape3)
            {
                var uri = GetPageUrl(hardcoreType, Rs3Constants.URIConstants.HiscoreAccountConstants.HtmlHiscoreConstants.HardcoreIronman, Rs3Constants.HTMLConstants.PageRankSize);
                uri = ValidateAndReturnUri(uri);
                isDead = FindPlayerDeadHtml(uri, Rs3Constants.HTMLConstants.HtmlOffSet, hardcoreType.Username, Rs3Constants.HTMLConstants.PlayerDied);
            }

            return isDead;
        }

        private string GetPageUrl(HardcoreAccountType account, string uri, double pageRankSize)
        {
            return uri += FindRankPage(account.HardcoreRank, pageRankSize).ToString();
        }

        private long FindRankPage(long hardcoreRank, double pageRankSize)
        {
            double pageRank = hardcoreRank / pageRankSize;
            double page = Math.Ceiling(pageRank);
            return Convert.ToInt64(page);
        }

        private bool FindPlayerDeadHtml(string html, int offSet, string username, string HtmlPlayerDead)
        {
            
            var htmlArray = HtmlStringHelper.CheckAndRemoveHtmlCharacter(html, '\uFFFD').Split('\n');
            for (int i = 0; i < htmlArray.Length; i++)
            {
                var line = htmlArray[i];
                if (line.Contains(username))
                {
                    if (i + offSet <= htmlArray.Length)
                    {
                        var nextLine = htmlArray[i + offSet];
                        if (nextLine.Contains(HtmlPlayerDead))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private string ValidateAndReturnUri(string testUri)
        {

            var webScraper = new WebClient();
            string result;
            try
            {
                result = webScraper.DownloadString(testUri);
            }
            catch (Exception)
            {
                throw new Exception(string.Format("The Page was not found."));
            }

            return result;

        }
    }
}
