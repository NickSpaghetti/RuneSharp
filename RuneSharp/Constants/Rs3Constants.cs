using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RuneSharp.Constants
{
    public static class Rs3Constants
    {
        public static class HTMLConstants
        {
            public const string PlayerDied = "Player Died";
            public const int HtmlOffSet = 4;
            public const int PageRankSize = 25;
            public const string htmlDocType = "<!doctype html>";
        }
        public static class Files
        {
            public const string EliteSkillXpFile = @"\bin\Debug\netcoreapp2.0\Constants\EliteSkillXp.txt";
        }
        public static class URIConstants
        {
            public static class HiscoreAccountConstants
            {
                public const string StandardHiscores = @"http://services.runescape.com/m=hiscore/index_lite.ws?player=";
                public const string IronmansHiscores = @"http://services.runescape.com/m=hiscore_ironman/index_lite.ws?player=";
                public const string HardcoreIronman = @"http://services.runescape.com/m=hiscore_hardcore_ironman/index_lite.ws?player=";

                public static class HtmlHiscoreConstants
                {
                    public const string HardcoreIronman = @"http://services.runescape.com/m=hiscore_hardcore_ironman/ranking?category_type=0&table=0&time_filter=0&date=0&page=";
                }
            }

            public static class ClanHiscoreConstants
            {
                public const string TopThreeClans = @"http://services.runescape.com/m=clan-hiscores/clanRanking.json";
                public const string GetClan = @"http://services.runescape.com/m=clan-hiscores/members_lite.ws?clanName=";
            }

            public static class SkillHiscoreConstants
            {
                public const string GetTopFiftySkills = "http://services.runescape.com/m=hiscore/ranking.json?table={0}&category=0&size={1}";
                public static class SkillHiscoreDataMembers
                {
                    public const int MaxUsers = 50;
                }

            }

            public static class GrandExchangeConstants
            {
                public const string ItemsCategory = "http://services.runescape.com/m=itemdb_rs/api/catalogue/items.json?category={0}&alpha={1}&page={2}";
                public const string DetailItem = "http://services.runescape.com/m=itemdb_rs/api/catalogue/detail.json?item={0}";
                public const string GELastUpdated = "https://secure.runescape.com/m=itemdb_rs/api/info.json";
                public const string GEPriceHistory = "http://services.runescape.com/m=itemdb_rs/api/graph/{0}.json";
            }

            public static class RuneMetricsConstants
            {
                public const string RuneMetrics = "https://apps.runescape.com/runemetrics/profile/profile?user={0}&activities=20";
                public const string Quests = "https://apps.runescape.com/runemetrics/quests?user={0}";
                public const string MontlyXp = "https://apps.runescape.com/runemetrics/xp-monthly?searchName={0}&skillid={1}";
            }

            public static class BeastirayConstants
            {
                public const string BeastById = "http://services.runescape.com/m=itemdb_rs/bestiary/beastData.json?beastid={0}";
                public const string BeastSearch = "http://services.runescape.com/m=itemdb_rs/bestiary/beastSearch.json?term={0}";
                public const string BeastStartsWith = "http://services.runescape.com/m=itemdb_rs/bestiary/bestiaryNames.json?letter={0}";
                public const string AreaNames = "http://services.runescape.com/m=itemdb_rs/bestiary/areaNames.json";
                public const string AreaBeasts = "http://services.runescape.com/m=itemdb_rs/bestiary/areaBeasts.json?identifier={0}";
                public const string SlayerCatNames = "http://services.runescape.com/m=itemdb_rs/bestiary/slayerCatNames.json";
                public const string SlayerBeastByCat = "http://services.runescape.com/m=itemdb_rs/bestiary/slayerBeasts.json?identifier={0}";
                public const string Weakness = "http://services.runescape.com/m=itemdb_rs/bestiary/weaknessNames.json";
                public const string WeaknessBeastSearch = "http://services.runescape.com/m=itemdb_rs/bestiary/weaknessBeasts.json?identifier={0}";
                public const string LevelGroupSearch = "http://services.runescape.com/m=itemdb_rs/bestiary/levelGroup.json?identifier={0}-{1}";

            }

            public static class WikiaConstants
            {
                public const string Rs3WikiaUrl = @"http://runescape.wikia.com/wiki/{0}";
            }

        }
        public static class EliteSkill
        {
            public static readonly long[] EliteSkillXpTable = { 0, 830, 1861, 2902, 3980, 5126, 6380, 7787, 9400, 11275, 13605, 16372, 19656,
                                                                23546, 28134, 33520, 39809, 47109, 55535, 65209, 77190, 90811, 106221, 123573,
                                                                143025, 164742, 188893, 215651, 245196, 277713, 316311, 358547, 404634, 454796,
                                                                509259, 568254, 632019, 700797, 774834, 854383, 946227, 1044569, 1149696, 1261903,
                                                                1381488, 1508756, 1644015, 1787581, 1939773, 2100917, 2283490, 2476369, 2679917, 2894505,
                                                                3120508, 3358307, 3608290, 3870846, 4146374, 4435275, 4758122, 5096111, 5449685, 5819299,
                                                                6205407, 6608473, 7028964, 7467354, 7924122, 8399751, 8925664, 9472665, 10041285, 10632061,
                                                                11245538, 11882262, 12542789, 13227679, 13937496, 14672812, 15478994, 16313404, 17176661,
                                                                18069395, 18992239, 19945833, 20930821, 21947856, 22997593, 24080695, 25259906, 26475754,
                                                                27728955, 29020233, 30350318, 31719944, 33129852, 34580790, 36073511, 37608773, 39270442,
                                                                40978509, 42733789, 44537107, 46389292, 48291180, 50243611, 52247435, 54303504, 56412678,
                                                                58575824, 60793812, 63067521, 65397835, 67785643, 70231841, 72737330, 75303019, 77929820,
                                                                80618654, 83370445, 86186124, 89066630, 92012904, 95025896, 98106559, 101255855, 104474750,
                                                                107764216, 111125230, 114558777, 118065845, 121647430, 125304532, 129038159, 132849323, 136739041,
                                                                140708338, 144758242, 148889790, 153104021, 157401983, 161784728, 166253312, 170808801, 175452262,
                                                                180184770, 185007406, 189921255, 194927409
                                                              };
        }

        public static class NPCConstants
        {
            public static class SlayerMasters
            {
                public const string Turael = "Turael";
                public const string Spria = "Spria";
                public const string Mazchna = "Mazchna";
                public const string Achtryn = "Achtryn";
                public const string Vannaka = "Vannaka";
                public const string Chaeldar = "Chaeldar";
                public const string Sumona = "Sumona";
                public const string Duradel = "Duradel";
                public const string Lapalok = "Lapalok";
                public const string Kuradal = "Kuradal";
                public const string Morvran = "Morvran";
                public const string Death = "Death";
                public const string Frank = "Frank";
                public const string Erskine = "Erskine";
                public const string Ling = "Ling";
                public const string Markus = "Markus";
                public const string TheRaptor = "The Raptor";
                public const string Catolax = "Catolax";
                public const string Faiza = "Faiza";
                public static readonly ReadOnlyCollection<string> SlayerMastersList = new ReadOnlyCollection<string>(new List<string> { Turael, Spria, Mazchna, Vannaka, Chaeldar, Sumona, Duradel, Lapalok, Kuradal, Morvran, Death, Frank, Erskine, Ling, Markus, TheRaptor, Catolax, Faiza });

            }
        }
    }
}
