using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using RuneSharp.Constants;
using System.Text;

namespace RuneSharp.Helpers.ParsersHelper.BestaryParser.Rs3
{
    public static class Rs3BestaryWikiaParser
    {
        public static Dictionary<string, List<string>> ScrapeWebPage(string url)
        {
            var tblVals = new Dictionary<string, List<string>>();
            var uniqueValues = new Dictionary<string, List<string>>();
            var knownValues = new HashSet<List<string>>();

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(url);

            var currCol = new List<string>();
            foreach (var table in htmlDoc.DocumentNode.SelectNodes("//table"))
            {
                foreach (var row in table.SelectNodes("tr"))
                {
                    foreach (var column in row.SelectNodes("h3|th|td"))
                    {
                        var replacedString = column.InnerText.Replace("\n", "");

                        if (!replacedString.Equals(string.Empty) && replacedString != null && !replacedString.Equals(" "))
                        {
                            currCol.Add(replacedString);

                            if (!tblVals.ContainsKey(currCol[0].ToString()))
                            {
                                tblVals[currCol[0].ToString()] = currCol;
                            }
                            else
                            {
                                var nextNameLst = tblVals.Keys.Where(k => k.Contains(currCol[0]));
                                tblVals[currCol[0].ToString() + nextNameLst.Count().ToString()] = currCol;
                            }


                        }

                    }
                }
                currCol = new List<string>();
            }

            uniqueValues = FormatDict(tblVals);
            uniqueValues = ParseDict(uniqueValues, htmlDoc);

            return uniqueValues;
        }

        private static Dictionary<string, List<string>> FormatDict(Dictionary<string, List<string>> unformattedDict)
        {
            var formattedDict = new Dictionary<string, List<string>>();
            var knownValues = new HashSet<List<string>>();
            foreach (var pair in unformattedDict)
            {
                var lstOfOGKyes = unformattedDict.Keys;
                var keyName = pair.Key.TrimStart();
                if (knownValues.Add(pair.Value))
                {
                    formattedDict.Add(pair.Key.TrimStart(), pair.Value.Select(v => v.TrimStart()).ToList());
                }
            }

            return formattedDict;
        }

        private static Dictionary<string, List<string>> ParseDict(Dictionary<string, List<string>> dictToParse, HtmlDocument htmlDoc)
        {
            dictToParse = ParseItems(dictToParse, htmlDoc);
            dictToParse = ParseReleaseDate(dictToParse);
            dictToParse = ParseCombatInfo(dictToParse);
            dictToParse = ParseCombatStats(dictToParse);
            dictToParse = ParseRelatesTo(dictToParse);
            dictToParse = ParseMiscellaneous(dictToParse);
            dictToParse = ParseLocations(dictToParse, htmlDoc);
            dictToParse = ParseAssignedBy(dictToParse, htmlDoc);
            dictToParse = ParseAttackSpeed(dictToParse, htmlDoc);
            dictToParse = ParseImmunitiesBy(dictToParse, htmlDoc);

            return dictToParse;
        }

        private static Dictionary<string, List<string>> ParseItems(Dictionary<string, List<string>> dictToParse, HtmlDocument htmlDoc)
        {
            var lst = GetH3Headers(htmlDoc);
            var parsedDict = new Dictionary<string, List<string>>();
            foreach (var pair in dictToParse)
            {
                if (pair.Key.Contains("Item"))
                {
                    parsedDict[lst[0] + " Drop Table"] = pair.Value;
                    lst.RemoveAt(0);
                }
                else
                {
                    parsedDict[pair.Key] = pair.Value;
                }
            }
            return parsedDict;
        }

        private static List<string> GetH3Headers(HtmlDocument htmlDoc)
        {
            var headerList = new List<string>();
            foreach (var span in htmlDoc.DocumentNode.SelectNodes("//*[self::h3]"))
            {
                var innerTxt = span.InnerText;
                if (innerTxt.Contains("Edit"))
                {
                    headerList.Add(innerTxt.Remove(innerTxt.LastIndexOf("E"), (innerTxt.Count() - innerTxt.LastIndexOf("E"))));
                }


            }
            return headerList;
        }

        private static List<string> GetH2Headers(HtmlDocument htmlDoc)
        {
            var headerList = new List<string>();
            foreach (var span in htmlDoc.DocumentNode.SelectNodes("//*[self::h2]"))
            {
                var innerTxt = span.InnerText;
                if (innerTxt.Contains("Edit"))
                {
                    headerList.Add(innerTxt.Remove(innerTxt.LastIndexOf("E"), (innerTxt.Count() - innerTxt.LastIndexOf("E"))));
                }


            }
            return headerList;
        }

        private static List<string> GetUiLiLists(HtmlDocument htmlDoc)
        {
            var locationList = new List<string>();
            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"mw-content-text\"]/ul");
            if (nodes == null)
            {
                return locationList;
            }

            foreach (var html in htmlDoc.DocumentNode.SelectNodes("//*[@id=\"mw-content-text\"]/ul"))
            {
                locationList.Add(html.InnerText);
            }
            locationList.Remove("");
            return locationList;
        }

        private static Dictionary<string, List<string>> ParseReleaseDate(Dictionary<string, List<string>> dictToParse)
        {
            var parsedDict = new Dictionary<string, List<string>>();
            foreach (var pair in dictToParse)
            {
                if (pair.Key.Contains("Release date"))
                {
                    if (pair.Value.Contains("Combat level"))
                    {
                        parsedDict["General Info " + pair.Value[(pair.Value.IndexOf("Combat level") + 1)].ToString()] = pair.Value;
                    }
                }
                else
                {
                    parsedDict[pair.Key] = pair.Value;
                }
            }


            return parsedDict;
        }

        private static Dictionary<string, List<string>> ParseCombatInfo(Dictionary<string, List<string>> dictToParse)
        {
            var parsedDict = new Dictionary<string, List<string>>();
            var count = 0;
            var prevKey = string.Empty;
            foreach (var pair in dictToParse)
            {
                if (pair.Key.Contains("Combat info"))
                {
                    var combatLevel = prevKey.Remove(0, prevKey.LastIndexOf(" ") + 1);
                    parsedDict["Combat Info " + combatLevel] = pair.Value;
                }
                else
                {
                    parsedDict[pair.Key] = pair.Value;
                }
                count++;
                prevKey = pair.Key;
            }


            return parsedDict;
        }

        private static Dictionary<string, List<string>> ParseCombatStats(Dictionary<string, List<string>> dictToParse)
        {
            var parsedDict = new Dictionary<string, List<string>>();
            var count = 0;
            var prevKey = string.Empty;
            foreach (var pair in dictToParse)
            {
                if (pair.Key.Contains("Combat stats"))
                {
                    var combatLevel = prevKey.Remove(0, prevKey.LastIndexOf(" ") + 1);
                    parsedDict["Combat Stats " + combatLevel] = pair.Value;
                }
                else
                {
                    parsedDict[pair.Key] = pair.Value;
                }
                count++;
                prevKey = pair.Key;
            }


            return parsedDict;
        }

        private static Dictionary<string, List<string>> ParseRelatesTo(Dictionary<string, List<string>> dictToParse)
        {
            var parsedDict = new Dictionary<string, List<string>>();
            foreach (var pair in dictToParse)
            {
                if (pair.Key.Contains("v&#160"))
                {
                    parsedDict["Relates To"] = pair.Value;
                }
                else
                {
                    parsedDict[pair.Key] = pair.Value;
                }
            }


            return parsedDict;
        }

        private static Dictionary<string, List<string>> ParseMiscellaneous(Dictionary<string, List<string>> dictToParse)
        {
            var parsedDict = new Dictionary<string, List<string>>();
            foreach (var pair in dictToParse)
            {
                if (pair.Key.Contains("&#8226"))
                {
                    parsedDict["Miscellaneous"] = pair.Value;
                }
                else
                {
                    parsedDict[pair.Key] = pair.Value;
                }
            }


            return parsedDict;
        }

        private static Dictionary<string, List<string>> ParseLocations(Dictionary<string, List<string>> dictToParse, HtmlDocument htmlDoc)
        {
            var lst = GetUiLiLists(htmlDoc);
            if (lst.Count == 0)
            {
                return dictToParse;
            }
            dictToParse["Locations"] = lst[0].Split('\n').ToList().Where(x => !x.Equals("")).ToList();
            return dictToParse;
        }

        private static List<string> GetImages(HtmlDocument htmlDoc, string imageValue)
        {
            var imageList = new List<string>();
            var tempImages = htmlDoc.DocumentNode.Descendants("img")
                                .Select(e => e.GetAttributeValue("src", null))
                                .Where(s => !String.IsNullOrEmpty(s) && s.Contains(imageValue));
            foreach (var image in tempImages)
            {
                if (!imageList.Contains(image))
                {
                    imageList.Add(image);
                }
            }
            return imageList;
        }

        private static Dictionary<string, List<string>> ParseAssignedBy(Dictionary<string, List<string>> dictToParse, HtmlDocument htmlDoc)
        {
            var slayerMasterImageList = GetImages(htmlDoc, "chathead");

            if (slayerMasterImageList.Count == 0)
            {
                return dictToParse;
            }
            var slayerMasterList = new List<string>();
            foreach (var master in slayerMasterImageList)
            {
                var splitMaster = master.Split('/');
                foreach (var item in splitMaster)
                {
                    if (item.Contains("chathead."))
                    {
                        var slayerMaster = item.Remove(item.IndexOf("_"));
                        if (IsValidChatHead(Rs3Constants.NPCConstants.SlayerMasters.SlayerMastersList.ToList(), slayerMaster))
                        {
                            slayerMasterList.Add(slayerMaster);
                        }

                    }
                }

            }
            dictToParse["Assigned By"] = slayerMasterList;
            return dictToParse;
        }

        private static Dictionary<string, List<string>> ParseImmunitiesBy(Dictionary<string, List<string>> dictToParse, HtmlDocument htmlDoc)
        {
            var ImmunityImageList = GetImages(htmlDoc, "Immune");
            var MarkImageList = GetImages(htmlDoc, "_mark");
            var CheckImageList = GetImages(htmlDoc, "_check");
            //get back to this only set up images dont know if they come in order
            if (ImmunityImageList.Count == 0)
            {
                return dictToParse;
            }
            var immunitiesList = new List<string>();
            foreach (var immunities in ImmunityImageList)
            {
                var splitImmunities = immunities.Split('/');
                foreach (var item in splitImmunities)
                {
                    if (item.Contains("Immune"))
                    {
                        var immune = item.Remove(item.IndexOf("_"));
                        if (IsValidChatHead(Rs3Constants.NPCConstants.SlayerMasters.SlayerMastersList.ToList(), immune))
                        {
                            immunitiesList.Add(immune);
                        }

                    }
                }

            }
            dictToParse["Immunities"] = immunitiesList;
            return dictToParse;
        }

        private static bool IsValidChatHead(List<string> validValues, string valueToCheck)
        {
            bool isValid = false;
            if (validValues.Contains(valueToCheck))
            {
                isValid = true;
            }
            return isValid;
        }

        private static Dictionary<string, List<string>> ParseAttackSpeed(Dictionary<string, List<string>> dictToParse, HtmlDocument htmlDoc)
        {
            var attackSpeedImageList = GetImages(htmlDoc, "attack_speed");
            if (attackSpeedImageList.Count == 0)
            {
                return dictToParse;
            }
            var attackSpeedList = new List<string>();
            foreach (var master in attackSpeedImageList)
            {
                var splitMaster = master.Split('/');
                foreach (var item in splitMaster)
                {
                    if (item.ToString().Contains("attack_speed_"))
                    {
                        var attackSpeed = item.Remove(item.IndexOf("M"), item.LastIndexOf("_") + 1);
                        attackSpeedList.Add(attackSpeed.Remove(attackSpeed.IndexOf('.')));
                    }
                }

            }
            dictToParse["Monster Attack Speed"] = attackSpeedList;
            return dictToParse;
        }
    }
}
