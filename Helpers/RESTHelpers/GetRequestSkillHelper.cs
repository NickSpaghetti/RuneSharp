using Newtonsoft.Json;
using RuneSharp.Constants;
using RuneSharp.Enums;
using RuneSharp.Helpers.AccountHelpers;
using RuneSharp.Helpers.MathHelpers;
using RuneSharp.Models.Skills;
using RuneSharp.Models.Skills.JsonSkillModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RuneSharp.Helpers.RESTHelpers
{
    public static class GetRequestSkillHelper
    {
        public static Dictionary<string,Rs3Skill> GetTopFiftyRankedSkills(SkillName skillName, int numberOfPlayers)
        {
            WebClient client = new WebClient();
            var result = client.DownloadString(string.Format(Rs3Constants.URIConstants.SkillHiscoreConstants.GetTopFiftySkills, Convert.ToInt32(skillName).ToString(), numberOfPlayers.ToString()));
            var skillList = JsonConvert.DeserializeObject<List<JsonRs3Skill>>(result);
            return ConvertJsonRs3SkillToRs3Skill(skillList, skillName);
        }

        private static Dictionary<string,Rs3Skill> ConvertJsonRs3SkillToRs3Skill(List<JsonRs3Skill> jsonRs3SkillList, SkillName skillName)
        {
            var rs3Dict = new Dictionary<string, Rs3Skill>();

            foreach (var skill in jsonRs3SkillList)
            {
                var rs3Skill = SkillLoaderHelper.LoadRS3Skill().FirstOrDefault(s => s.Name == skillName);
                rs3Skill.Rank = skill.SkillRank;
                rs3Skill.Experence = skill.XP;
                rs3Skill.Level = RsAccountMathHelper.LevelAtExperenceStandard(rs3Skill.Experence);
                rs3Skill.VirtualLevel = rs3Skill.Level;

                rs3Dict.Add(skill.PlayerName, rs3Skill);
            }

            return rs3Dict;
        }
    }
}
