namespace RuneSharp.Constants;

public static class OsrsConstants
{
    public static class HTMLConstants
    {
            public const string PlayerDead = "Player died";
            public const int HtmlOffSet = 1;
            public const int PageRankSize = 25;
    }

    public static class CsvResultConstants
    {
        public static readonly char[] SplitOn = new[] { ',', '\n' };
    }

    public static class URIConstants
    {
        public static class HiscoreConstants
        {
            public const string Standard = @"http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=";

            public const string Ironman =
                @"http://services.runescape.com/m=hiscore_oldschool_ironman/index_lite.ws?player=";

            public const string HardcoreIronman =
                @"http://services.runescape.com/m=hiscore_oldschool_hardcore_ironman/index_lite.ws?player=";

            public const string UlitmateIronman =
                @"http://services.runescape.com/m=hiscore_oldschool_ultimate/index_lite.ws?player=";

            public const string DeadmanMode =
                @"http://services.runescape.com/m=hiscore_oldschool_deadman/index_lite.ws?player=";

            public const string Seasonal =
                @"http://services.runescape.com/m=hiscore_oldschool_seasonal/index_lite.ws?player=";

            public const string Tordment =
                @"http://services.runescape.com/m=hiscore_oldschool_tournament/index_lite.ws?player=";

            public static class HtmlHiscoreConstants
            {
                public const string HardcoreIronman =
                    @"http://services.runescape.com/m=hiscore_oldschool_hardcore_ironman/overall.ws?table=0&page=";
            }
        }

        public static class GrandExchangeConstants
        {
            public const string ItemsCategory =
                "http://services.runescape.com/m=itemdb_oldschool/api/catalogue/items.json?category={0}&alpha={1}&page={2}";

            public const string DetailItem =
                "http://services.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item={0}";

            public const string GELastUpdated = "http://services.runescape.com/m=itemdb_oldschool/api/info.json";
            public const string GEPriceHistory = "http://services.runescape.com/m=itemdb_oldschool/api/graph/{0}.json";
        }
    }
}