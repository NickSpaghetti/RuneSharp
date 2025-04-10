using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Helpers.StringHelpers;
using RuneSharp.Models.Npcs.Monsters.Rs3;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RuneSharp.Helpers.ParsersHelper.BestaryParser.Rs3
{
    public static class Rs3BeastaryParser
    {
        public static Rs3Monster GetRs3Monster(long monsterId)
        {
            var response =  GetRequestBeastaryHelper.GetMonster(monsterId);
            return DeserlizeJsonRequest<Rs3Monster>(response.Result);
        }

        public static Rs3Monster Rs3Monster(string monsterName, int comabtLevel)
        {
            var monsterLabel = string.Format("{0} ({1})", monsterName, comabtLevel.ToString());
            var MonsterVarrations = GetAllRs3MonsterVarrationList(monsterName);
            if (MonsterVarrations == null || MonsterVarrations.Count == 0)
            {
                return null;
            }

            var value = MonsterVarrations.SingleOrDefault(mv => mv.Label.ToLower() == monsterLabel.ToLower());
            if (value == null)
            {
                return null;
            }

            return GetRs3Monster(value.Value);

        }

        public static List<Rs3Monster> GetAllMonsterVarrations(string monsterName)
        {
            var monsterVarrationList = GetAllRs3MonsterVarrationList(monsterName);
            if (monsterVarrationList == null || monsterVarrationList.Count == 0)
            {
                return null;
            }

            var rs3Monsters = new List<Rs3Monster>();
            foreach (var monster in monsterVarrationList)
            {
                var monsterData = GetRs3Monster(monster.Value);
                if (monsterData != null)
                {
                    rs3Monsters.Add(monsterData);
                }
            }

            return rs3Monsters;
        }

        public static List<Rs3MonsterVarrations> GetAllRs3MonsterVarrationList(string monsterName)
        {
            var response = GetRequestBeastaryHelper.GetMonsterVarration(monsterName);
            return DeserlizeJsonRequest<List<Rs3MonsterVarrations>>(response.Result);
        }


        public static List<string> GetRs3Areas()
        {
            var areaNames = GetRequestBeastaryHelper.GetAreaNames();
            if (areaNames == null)
            {
                return null;
            }

            return areaNames.Result.Content.ReadAsStringAsync().Result.ToString()
                .Replace("\"",string.Empty).Replace("[",string.Empty).Replace("]",string.Empty)
                .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static List<Rs3MonsterVarrations> GetRs3MonstersByArea(string area)
        {
            var areaNames = GetRs3Areas();
            area = areaNames.SingleOrDefault(s => s.ToLower().Equals(area.ToLower()));
            if (string.IsNullOrEmpty(area))
            {
                return null;
            }

            var request = GetRequestBeastaryHelper.GetMonstersByAreaName(area);
            return DeserlizeJsonRequest<List<Rs3MonsterVarrations>>(request.Result);
        }

        public static Dictionary<string, long> GetRs3SlayerCategories()
        {
            var response = GetRequestBeastaryHelper.GetSlayerCategoryNames();
            return DeserlizeJsonRequest<Dictionary<string, long>>(response.Result);
        }

        public static List<Rs3MonsterVarrations> GetSlayerMonsterByCagegory(long slayerCategoryId)
        {
            var response = GetRequestBeastaryHelper.GetMonsterBySlayerCategory(slayerCategoryId);
            return DeserlizeJsonRequest<List<Rs3MonsterVarrations>>(response.Result);
        }

        public static List<Rs3MonsterVarrations> GetMonstersInBetweenCombatLevels(long startLevel, long endLevel)
        {
            var response = GetRequestBeastaryHelper.GetMonsterByLevelGroup(startLevel, endLevel);
            return DeserlizeJsonRequest<List<Rs3MonsterVarrations>>(response.Result);
        }

        public static Dictionary<string, long> GetRs3Weaknesses()
        {
            var response = GetRequestBeastaryHelper.GetWeakness();
            return DeserlizeJsonRequest<Dictionary<string, long>>(response.Result);
        }

        public static List<Rs3MonsterVarrations> GetMonstersByWeakness(long weaknessId)
        {
            var response = GetRequestBeastaryHelper.GetMonstersByWeakness(weaknessId);
            return DeserlizeJsonRequest<List<Rs3MonsterVarrations>>(response.Result);
        }

        public static List<Rs3MonsterVarrations> GetMonstersThatStartWith(char startingChar)
        {
            if (!FormatStringHelper.IsCharValidLetter(startingChar))
            {
                return null;
            }
            char startingLetter = FormatStringHelper.UppercaseFirst(startingChar.ToString()).ToCharArray()[0];
            var response = GetRequestBeastaryHelper.GetMonstersThatStarWith(startingLetter);
            return DeserlizeJsonRequest<List<Rs3MonsterVarrations>>(response.Result);
        }


        private static string CreateMutiplePrams(params string[] words)
        {
            var paramters = string.Empty;
            foreach (var name in words)
            {
                paramters += string.Format("+{0}", FormatStringHelper.UppercaseFirst(name.ToLower()));
            }

            return paramters;
        }

        private static T DeserlizeJsonRequest<T>(HttpResponseMessage response)
        {
            var isOkay = IsResponceOkay(response);
            if (!isOkay)
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result.ToString());
        }

        private static bool IsResponceOkay(HttpResponseMessage response)
        {
            bool isOkay = false;
            if (response.StatusCode == System.Net.HttpStatusCode.OK || !string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result.ToString()) || !response.Content.ReadAsStringAsync().Result.ToString().ToLower().Equals("[\"none\"]"))
            {
                isOkay = true;
            }
            return isOkay;
        }
    }
}
