using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RuneSharp.Helpers.StringHelpers
{
    internal static class HtmlStringHelper
    {
        internal static string CheckAndRemoveHtmlCharacter(string html, char htmlCharToRemove)
        {
            var decodedHtml = WebUtility.HtmlDecode(html);
            if (decodedHtml.Contains(htmlCharToRemove))
            {
                decodedHtml = decodedHtml.Replace(htmlCharToRemove, ' ');
            }
            return decodedHtml;
        }
    }
}
