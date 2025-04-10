using RuneSharp.Constants;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RuneSharp.Helpers.RESTHelpers
{
    public static class GetRequestBeastaryHelper
    {

        public async static Task<HttpResponseMessage> GetMonster(long id)
        {
            return await MakeGetRequest(string.Format(Rs3Constants.URIConstants.BeastirayConstants.BeastById, id.ToString()));
        }


        public async static Task<HttpResponseMessage> GetMonsterVarration(string monsterName)
        {
            return await MakeGetRequest(string.Format(Rs3Constants.URIConstants.BeastirayConstants.BeastSearch, monsterName));
        }

        public async static Task<HttpResponseMessage> GetMonstersThatStarWith(char startsWith)
        {
            return await MakeGetRequest(string.Format(Rs3Constants.URIConstants.BeastirayConstants.BeastStartsWith,startsWith));
        }

        public async static Task<HttpResponseMessage> GetAreaNames()
        {
            return await MakeGetRequest(Rs3Constants.URIConstants.BeastirayConstants.AreaNames);
        }

        public async static Task<HttpResponseMessage> GetMonstersByAreaName(string areaName)
        {
            return await MakeGetRequest(string.Format(Rs3Constants.URIConstants.BeastirayConstants.AreaBeasts,areaName));
        }

        public async static Task<HttpResponseMessage> GetSlayerCategoryNames()
        {
            return await MakeGetRequest(Rs3Constants.URIConstants.BeastirayConstants.SlayerCatNames);
        }

        public async static Task<HttpResponseMessage> GetMonsterBySlayerCategory(long slayerCategoryId)
        {
            return await MakeGetRequest(string.Format(Rs3Constants.URIConstants.BeastirayConstants.SlayerBeastByCat, slayerCategoryId.ToString()));
        }

        public async static Task<HttpResponseMessage> GetWeakness()
        {
            return await MakeGetRequest(Rs3Constants.URIConstants.BeastirayConstants.Weakness);
        }

        public async static Task<HttpResponseMessage> GetMonstersByWeakness(long weaknessId)
        {
            return await MakeGetRequest(string.Format(Rs3Constants.URIConstants.BeastirayConstants.WeaknessBeastSearch, weaknessId.ToString()));
        }

        public async static Task<HttpResponseMessage> GetMonsterByLevelGroup(long startLevel, long endLevel)
        {
            return  await MakeGetRequest(string.Format(Rs3Constants.URIConstants.BeastirayConstants.LevelGroupSearch, startLevel.ToString(),endLevel.ToString()));
        }


        private async static Task<HttpResponseMessage> MakeGetRequest(string uri)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(uri);
            return response;
        }
        
        
    }
}
