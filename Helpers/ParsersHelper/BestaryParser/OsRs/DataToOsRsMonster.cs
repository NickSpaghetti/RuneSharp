using RuneSharp.Enums;
using RuneSharp.Helpers.EnumHelpers;
using RuneSharp.Models.GameWorld.Locations;
using RuneSharp.Models.Items;
using RuneSharp.Models.Npcs;
using RuneSharp.Models.Npcs.Monsters.Metadata;
using RuneSharp.Models.Npcs.Monsters.Metadata.OsRs;
using RuneSharp.Models.Npcs.Monsters.OsRs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RuneSharp.Helpers.ParsersHelper.BestaryParser.OsRs
{
    public static class DataToOsRsMonster
    {

        public static Dictionary<string, List<OsRsMonster>> GetManyMonsters(List<string> monsterNames)
        {
            return ResolveManyMonsters(monsterNames);
        }

        private static Dictionary<string,List<OsRsMonster>> ResolveManyMonsters(List<string> monsterNames)
        {
            Dictionary<string, List<OsRsMonster>> monsterKeyValuePairs = new Dictionary<string, List<OsRsMonster>>();
            foreach (var name in monsterNames)
            {
                monsterKeyValuePairs[name] = GetAllMonsterVarrations(name);
            }
            return monsterKeyValuePairs;
        }

        public static List<OsRsMonster> GetAllMonsterVarrations(string monsterName)
        {
            return ResolveAllMonstersVarriance(monsterName);
        }
        private static List<OsRsMonster> ResolveAllMonstersVarriance(string monsterName)
        {
            List<OsRsMonster> osrsMonsters = new List<OsRsMonster>();
            var monsterDict = OsRsBestaryWikiaParser.ScrapeWebPage(monsterName);
            List<string> combatLevels = monsterDict[monsterName];
            foreach (var cbLevels in combatLevels)
            {
                int outCbLevel = 0;
                if (int.TryParse(cbLevels, out outCbLevel))
                {
                    osrsMonsters.Add(ResloveSingleMonster(monsterDict, monsterName, outCbLevel));
                }
            }
            return osrsMonsters;
        }

        public static OsRsMonster GetSingleMonster(string monsterName, int combatLevel)
        {
            var monsterDict = OsRsBestaryWikiaParser.ScrapeWebPage(monsterName);
            return ResloveSingleMonster(monsterDict, monsterName, combatLevel);
        }

        private static OsRsMonster ResloveSingleMonster(Dictionary<string, List<string>> monsterData, string monsterName, int combatLevel)
        {
            var Monster = new OsRsMonster();
            var combatDict = GetKeyValuePairThatCointainsValue(monsterData, combatLevel.ToString());
            var dropTableDict = GetKeyValuePairThatCointainsValue(monsterData, "DROP TABLE");
            if(combatDict.Keys.Count == 0)
            {
                return Monster;
            }

            //Create OSRSMonster With combat data from CombatDict
            Monster.NpcName = ResolveMonsterName(monsterData, monsterName);
            Monster = ResolveGeneralInfo(combatDict, Monster, combatLevel);
            Monster = ResolveCombatInfo(monsterData, combatDict, Monster, combatLevel);
            Monster = ResolveCombatStats(monsterData, combatDict,Monster, combatLevel);
            Monster = ResolveDropTable(dropTableDict, Monster);
            Monster = ResolveMetadata(monsterData, Monster);

            return Monster;
            
        }

        private static Dictionary<string, List<string>> GetKeyValuePairThatCointainsValue(Dictionary<string, List<string>> monsterData, string value)
        {
            value = value.ToUpper();
            var listOfKeys = monsterData.Keys.ToList().Where(k => k.ToUpper().Contains(value));
            if (listOfKeys.Count() == 0)
            {
                return new Dictionary<string, List<string>>();
            }
            var filteredDictList = monsterData.Where(k => k.Key.ToUpper().Contains(value));

            return filteredDictList.ToDictionary(k => k.Key, v => v.Value);
        }

        private static string ResolveMonsterName(Dictionary<string, List<string>> monsterData, string monsterName)
        {
            var validMonsterName = monsterName;
            if(monsterName.Contains("_"))
            {
                validMonsterName = monsterName.Replace("_", " ");
            }
            return validMonsterName;
        }

        private static OsRsMonster ResolveGeneralInfo(Dictionary<string, List<string>> monsterData, OsRsMonster monster, int combatLevel)
        {
            var generalInfoList = monsterData["General Info " + combatLevel.ToString()];
            for (int i = 0; i < generalInfoList.Count; i++)
            {
                if (generalInfoList[i].ToUpper() == "RELEASE DATE" && IsNextIndexValid(i, generalInfoList.Count))
                {
                    monster.ReleaseDate = ResolveReleaseDate(generalInfoList[i + 1]);
                }
                else if (generalInfoList[i].ToUpper() == "MEMBERS?" && IsNextIndexValid(i, generalInfoList.Count))
                {
                    monster.IsMembers = ResolveBool(generalInfoList[i + 1]);
                }
                else if (generalInfoList[i].ToUpper() == "COMBAT LEVEL" && IsNextIndexValid(i, generalInfoList.Count))
                {
                    monster.CombatLevel = ResolveCombatLevel(combatLevel, generalInfoList[i + 1]);
                }
                else if (generalInfoList[i].ToUpper() == "EXAMINE" && IsNextIndexValid(i, generalInfoList.Count))
                {
                    monster.Examine = generalInfoList[i + 1].ToString();
                }
            }
            return monster;
        }

        private static bool IsNextIndexValid(int index, int count)
        {
            bool isValidIndex = false;
            index++;
            if(index <= count)
            {
                isValidIndex = true;
            }

            return isValidIndex;
        }

        private static DateTime ResolveReleaseDate(string date)
        {
            var dateSplit = date.Split(' ');
            string dateBuilder = string.Empty;
            if(dateSplit.Count() >= 3)
            {
                dateBuilder = string.Format("{0} {1} {2}", dateSplit[0], dateSplit[1], dateSplit[2]);
            }
            else
            {
                return new DateTime();
            }

            return DateTime.Parse(dateBuilder);
        }

        private static bool ResolveBool(string isMembersBool)
        {
            bool isMembers = false;
            isMembersBool = RemoveSpecialCharactersFromString(isMembersBool).ToUpper();
            if(isMembersBool.Contains("YES"))
            {
                isMembers = true;
            }
            return isMembers;
            
        }

        private static int ResolveCombatLevel(int combatLevel, string testCombatLevel)
        {
            int cbOut = 0;
            int combatToReturn = 0;
            if(combatLevel.ToString() == testCombatLevel)
            {
                combatToReturn = combatLevel;
            }
            else if(int.TryParse(testCombatLevel,out cbOut))
            {
                combatToReturn = cbOut;
            }
            else
            {
                combatToReturn = combatLevel;
            }

            return combatToReturn;
        }

        private static OsRsMonster ResolveCombatInfo(Dictionary<string, List<string>> monsterData, Dictionary<string, List<string>> combatDict, OsRsMonster monster, int combatLevel)
        {
            var combatInfoList = monsterData["Combat Info " + combatLevel.ToString()];

            for (int i = 0; i < combatInfoList.Count; i++)
            {
                if (combatInfoList[i].ToUpper() == "HITPOINTS" && IsNextIndexValid(i, combatInfoList.Count))
                {
                    monster.HitPoints = ResloveHitpoints(combatInfoList[i + 1]);
                    monster.HitPointsExperence = monster.HitPoints / 4;
                    monster.Experence = monster.HitPoints * 4;
                }
                else if (combatInfoList[i].ToUpper() == "AGGRESSIVE" && IsNextIndexValid(i, combatInfoList.Count))
                {
                    monster.IsMembers = ResolveBool(combatInfoList[i + 1]);
                }
                else if (combatInfoList[i].ToUpper() == "POISONOUS" && IsNextIndexValid(i, combatInfoList.Count))
                {
                    monster.IsPoisonous = ResolveBool(combatInfoList[1 + 1]);
                    monster.IsVenomious = ResolveIsVenomous(combatInfoList[i + 1]);
                }
                else if (combatInfoList[i].ToUpper() == "MAX HIT" && IsNextIndexValid(i, combatInfoList.Count))
                {
                    monster.MaxHit = ResolveMaxHit(combatInfoList[i + 1]);
                }
                else if (combatInfoList[i].ToUpper() == "WEAKNESS" && IsNextIndexValid(i, combatInfoList.Count))
                {
                    monster.Weaknesses = ResolveWeakness(combatInfoList[i + 1]);
                }
                else if (combatInfoList[i].ToUpper() == "ATTACK STYLES" && IsNextIndexValid(i, combatInfoList.Count))
                {
                    monster.AttackStyles = ResolveAttackStyles(combatInfoList[i + 1]);
                }
                else if (combatInfoList[i].ToUpper() == "SLAYER LEVEL" && IsNextIndexValid(i, combatInfoList.Count))
                {
                    monster.SlayerLevel = ResolveSlayerLevel(combatInfoList[i + 1]);
                }
                else if (combatInfoList[i].ToUpper() == "SLAYER XP" && IsNextIndexValid(i, combatInfoList.Count))
                {
                    monster.SlayerExperence = ResolveSlayerXp(combatInfoList[i + 1], monster);
                }
                else if (combatInfoList[i].ToUpper() == "ASSIGNED BY" && IsNextIndexValid(i, combatInfoList.Count))
                {
                    monster.AssignedBy = ResloveAssignedBy(monsterData); 
                }
                else if (combatInfoList[i].ToUpper() == "OTHER BONUSES" && IsNextIndexValid(i+6, combatInfoList.Count))
                {
                    monster.OtherBounses = ResolveOtherBounses(combatInfoList.Skip(i+2).Take(4).ToList());
                }
                else if (combatInfoList[i].ToUpper() == "IMMUNITIES" && IsNextIndexValid(i+2, combatInfoList.Count))
                {
                    monster.Immunities = ResolveImmunites(combatInfoList.Skip(i).Take(2).ToList());
                }
                else if (combatInfoList[i].ToUpper() == "ATTACK SPEED" && IsNextIndexValid(i, combatInfoList.Count))
                {
                    monster.AttackSpeed = ResolveAttackSpeed(monsterData);
                }
            }

            return monster;
        }

        private static string RemoveSpecialCharactersFromString(string strToRemove)
        {
            return new string(strToRemove.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-').ToArray());
        }

        private static int ResloveHitpoints(string hitPoints)
        {
            int outHitpoints = 0;
            var isHitpointsInt = int.TryParse(hitPoints, out outHitpoints);
            return outHitpoints;
        }

        private static bool ResolveIsVenomous(string isVenomusString)
        {
            string formattedString = RemoveSpecialCharactersFromString(isVenomusString);
            return formattedString.ToUpper().Contains("VENOM");
        }

        private static Dictionary<string, int> ResolveMaxHit(string maxHitString)
        {
            var maxHitDict = new Dictionary<string, int>();
            maxHitString = maxHitString.Replace("(",string.Empty).Trim();
            var splitString = maxHitString.Split(')');
            int maxHit = 0;
            if (splitString.Count() == 1 && int.TryParse(splitString[0],out maxHit))
            {
                maxHitDict["MaxHit"] = maxHit;
            }
            else
            {
                foreach (var item in splitString)
                {
                    var maxHitList = item.Split(' ');
                    if (IsNextIndexValid(0, maxHitList.Count()))
                    {
                        string maxHitWithOutSpecialCharacters = RemoveSpecialCharactersFromString(maxHitList[0]);
                        if (maxHitWithOutSpecialCharacters != string.Empty || maxHitWithOutSpecialCharacters != null)
                        {

                            if (int.TryParse(maxHitWithOutSpecialCharacters, out maxHit) && IsNextIndexValid(1, maxHitList.Count()))
                            {
                                maxHitDict[maxHitList[1]] = maxHit;
                            }

                        }

                    }
                }
            }
            
            return maxHitDict;
        }

        private static List<Weakness> ResolveWeakness(string weaknessCSV)
        {
            var weaknessSplit = weaknessCSV.Split(new string[] { ",", "and", "or" }, StringSplitOptions.None);
            var weaknessList = new List<Weakness>();
            foreach (var weakness in weaknessSplit)
            {
                if(weakness.Contains(" "))
                {
                    weaknessList.Add(StringToEnumHelper.ToEnumWithSpaces<Weakness>(weakness));
                }
                else
                {
                    weaknessList.Add(StringToEnumHelper.ToEnum<Weakness>(weakness));
                }
                
            }

            return weaknessList;
        }

        private static Dictionary<string,string> ResolveAttackStyles(string attackStyles)
        {
            var attackStylesDict = new Dictionary<string, string>();
            attackStyles = attackStyles.Replace("(", string.Empty).Trim();
            var splitString = attackStyles.Split(')',',');
            if (splitString.Count() == 1)
            {
                attackStylesDict["Attack Styles"] = splitString[0];
            }
            else
            {
                foreach (var item in splitString)
                {
                    var attackStyleList = item.Split(' ');
                    if (IsNextIndexValid(0, attackStyleList.Count()))
                    {
                        string attackStylesWithOutSpecialCharacters = new string(attackStyleList[0].Trim().Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-').ToArray());
                        if(attackStylesWithOutSpecialCharacters != null)
                        {
                            if (attackStylesWithOutSpecialCharacters != string.Empty && attackStylesWithOutSpecialCharacters != null)
                            {
                                attackStylesDict[attackStylesWithOutSpecialCharacters] = attackStyleList[0];
                            }
                            else if (attackStylesWithOutSpecialCharacters == string.Empty && attackStyleList.Count() > 1)
                            {
                                attackStylesDict[attackStyleList[1]] = attackStyleList[1];
                            }
                        }
                        
                    }
                }
            }

            return attackStylesDict;
        }

        private static double ResolveSlayerXp(string slayerXp, OsRsMonster monster)
        {
            double outSlayerXp = 0;
            if(!double.TryParse(slayerXp, out outSlayerXp))
            {
                outSlayerXp = monster.HitPoints;
            }
            return outSlayerXp;
        }

        private static int ResolveSlayerLevel(string slayerLevel)
        {
            int outSlayerLevel = 0;
            if (!int.TryParse(slayerLevel, out outSlayerLevel))
            {
                outSlayerLevel = 1;
            }
            return outSlayerLevel;
        }

        private static List<string> ResloveAssignedBy(Dictionary<string, List<string>> monsterData)
        {
            var assigedByList = monsterData["Assigned By"];
            var slayerMasterList = new List<string>();
            if(assigedByList.Count > 0)
            {
                slayerMasterList = assigedByList;
            }

            return slayerMasterList;
        }

        private static OtherBounses ResolveOtherBounses(List<string> otherBounsesList)
        {
            var formattedBounses = CreateFormattedGenericList<int>(otherBounsesList);
            var Bouneses = new OtherBounses();

            if(formattedBounses.Count >= 4)
            {
                Bouneses.Attack = formattedBounses[0];
                Bouneses.Strength = formattedBounses[1];
                Bouneses.RangedStrength = formattedBounses[2];
                Bouneses.MagicStrength = formattedBounses[3];
            }

            return Bouneses;
        }

        private static List<Immunity> ResolveImmunites(List<string> immunityValues)
        {
            var poisenImmunity = new Immunity() { Name = StatusEffect.Poison, GameVersion = GameVersion.OldSchool };
            var venomImmunity = new Immunity() { Name = StatusEffect.Venom, GameVersion = GameVersion.OldSchool };
            var ImmunityList = new List<Immunity>() {poisenImmunity,venomImmunity};
            
            if(immunityValues.Count != 0)
            {
                var count = 0;
                foreach (var immunity in ImmunityList)
                {
                    if(IsNextIndexValid(count, immunityValues.Count()))
                    {
                        if (immunityValues[count].ToUpper().Contains("NOT IMMUNE"))
                        {
                            immunity.IsImmune = false;
                        }
                    }
                    else
                    {
                        immunity.IsImmune = true;
                    }
                    count++;
                }
            }

            return ImmunityList;
        }

        private static int ResolveAttackSpeed(Dictionary<string,List<string>> monsterDict)
        {
            int outAttackSpeed = 0;
            string attackSpeed = monsterDict["Monster Attack Speed"][0];
            if(attackSpeed != string.Empty)
            {
                attackSpeed = RemoveSpecialCharactersFromString(attackSpeed);
                if (!int.TryParse(attackSpeed, out outAttackSpeed))
                {
                    outAttackSpeed = 1;
                }
            }
            return outAttackSpeed;
        }



        private static OsRsMonster ResolveCombatStats(Dictionary<string, List<string>> monsterData, Dictionary<string, List<string>> combatDict, OsRsMonster monster, int combatLevel)
        {
            var combatStatsList = monsterData["Combat Stats " + combatLevel.ToString()];
            for (int i = 0; i < combatStatsList.Count; i++)
            {
                if (combatStatsList[i].ToUpper().Contains("COMBAT STATS") && IsNextIndexValid(i+6, combatStatsList.Count))
                {
                    monster.CombatStats = ResloveCombatStats(combatStatsList.Skip(i).Take(6).ToList());
                }
                else if (combatStatsList[i].ToUpper().Contains("AGGRESSIVE STATS") && IsNextIndexValid(i+6, combatStatsList.Count))
                {
                    monster.AggressiveStats = ResloveAggressiveStats(combatStatsList.Skip(i).Take(6).ToList());
                }
                else if (combatStatsList[i].ToUpper().Contains("DEFENSIVE STATS") && IsNextIndexValid(i+4, combatStatsList.Count))
                {
                    monster.DefensiveStats = ResloveDefensiveStats(combatStatsList.Skip(i).Take(6).ToList());
                }
            }
            return monster;
        }

        private static CombatStats ResloveCombatStats(List<string> combatStatsList)
        {
            var cbStats = new CombatStats();
            var formattedBounses = CreateFormattedGenericList<int>(combatStatsList);

            if (formattedBounses.Count >= 5)
            {
                cbStats.Attack = formattedBounses[0];
                cbStats.Strength = formattedBounses[1];
                cbStats.Defence = formattedBounses[2];
                cbStats.Magic = formattedBounses[3];
                cbStats.Ranged = formattedBounses[4];
            }

            return cbStats;
        }

        private static AggressiveStats ResloveAggressiveStats(List<string> aggressiveStatsList)
        {
            var agStats = new AggressiveStats();
            var formattedBounses = CreateFormattedGenericList<int>(aggressiveStatsList);

            if (formattedBounses.Count >= 5)
            {
                agStats.Stab = formattedBounses[0];
                agStats.Slash = formattedBounses[1];
                agStats.Crush = formattedBounses[2];
                agStats.Magic = formattedBounses[3];
                agStats.Ranged = formattedBounses[4];
            }
            return agStats;
        }

        private static DefensiveStats ResloveDefensiveStats(List<string> defensiveStatsList)
        {
            var defStats = new DefensiveStats();
            var formattedBounses = CreateFormattedGenericList<int>(defensiveStatsList);

            if (formattedBounses.Count >= 5)
            {
                defStats.Stab = formattedBounses[0];
                defStats.Slash = formattedBounses[1];
                defStats.Crush = formattedBounses[2];
                defStats.Magic = formattedBounses[3];
                defStats.Ranged = formattedBounses[4];
            }
            return defStats;
        }

        private static List<T>CreateFormattedGenericList<T>(List<string> charsToRemove)
        {
            var formattedBounses = new List<T>();
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var bounes in charsToRemove)
            {
                var formattedBounes = RemoveSpecialCharactersFromString(bounes);
                if (converter != null && converter.IsValid(formattedBounes))
                {
                    formattedBounses.Add((T)converter.ConvertFromString(formattedBounes));
                }

            }
            return formattedBounses;
        }

        private static OsRsMonster ResolveDropTable(Dictionary<string, List<string>> dropTableDict, OsRsMonster monster)
        {
            if(monster.DropTables == null)
            {
                monster.DropTables = new Dictionary<string, List<DroppedItem>>();
            }

            foreach (var keyValuePair in dropTableDict)
            {
                if(keyValuePair.Key.ToUpper().Contains("100%"))
                {
                    monster.DropTables["Always"] = CreateListOfDropedItems(keyValuePair.Value);
                }
                else if (keyValuePair.Key.ToUpper().Contains("UNIQUE"))
                {
                    monster.DropTables["Unique"] = CreateListOfDropedItems(keyValuePair.Value);
                }
                else if (keyValuePair.Key.ToUpper().Contains("ARMOR WEAPONS"))
                {
                    monster.DropTables["Armor&Weapons"] = CreateListOfDropedItems(keyValuePair.Value);
                }
                else if (keyValuePair.Key.ToUpper().Contains("ARMOR"))
                {
                    monster.DropTables["Armor"] = CreateListOfDropedItems(keyValuePair.Value);
                }
                else if (keyValuePair.Key.ToUpper().Contains("WEAPONS"))
                {
                    monster.DropTables["Weapons"] = CreateListOfDropedItems(keyValuePair.Value);
                }
                else if (keyValuePair.Key.ToUpper().Contains("RUNES"))
                {
                    monster.DropTables["Runes"] = CreateListOfDropedItems(keyValuePair.Value);
                }
                else if (keyValuePair.Key.ToUpper().Contains("HERBS"))
                {
                    monster.DropTables["Herbs"] = CreateListOfDropedItems(keyValuePair.Value);
                }
                else if (keyValuePair.Key.ToUpper().Contains("SEEDS"))
                {
                    monster.DropTables["Seeds"] = CreateListOfDropedItems(keyValuePair.Value);
                }
                else if (keyValuePair.Key.ToUpper().Contains("MATERIALS"))
                {
                    monster.DropTables["Materials"] = CreateListOfDropedItems(keyValuePair.Value);
                }
                else if (keyValuePair.Key.ToUpper().Contains("GEM"))
                {
                    monster.DropTables["Gems"] = CreateListOfDropedItems(keyValuePair.Value.Skip(1).ToList());
                }
                else if (keyValuePair.Key.ToUpper().Contains("OTHER"))
                {
                    monster.DropTables["Other"] = CreateListOfDropedItems(keyValuePair.Value);
                }
                else if (keyValuePair.Key.ToUpper().Contains("RARE"))
                {
                    monster.DropTables["Rare"] = CreateListOfDropedItems(keyValuePair.Value.Skip(1).ToList());
                }
            }
            return monster;
        }

        private static List<DroppedItem> CreateListOfDropedItems(List<string> value)
        {
            var DropTable = new List<DroppedItem>();
            List<string> tempDropTable = new List<string>();
            if(value.Count() == 0)
            {
                return DropTable;
            }

            tempDropTable = value.Skip(4).ToList();
            if(tempDropTable.Count == 0 || tempDropTable.Count % 4 != 0)
            {
                return DropTable;
            }

            for (int i = 0; i <= tempDropTable.Count; i++)
            {
                if(IsNextIndexValid(i,tempDropTable.Count))
                {
                    var droppedItem = GetDroppedItem(tempDropTable.Take(4).ToList());
                    if(droppedItem != null)
                    {
                        DropTable.Add(droppedItem);
                        tempDropTable.RemoveRange(0, 4);
                    }
                }
            }


            return DropTable;
        }

        public static DroppedItem GetDroppedItem(List<string> listToAdd)
        {
            DroppedItem droppedItem = new DroppedItem();
            if(listToAdd.Count < 4)
            {
               return droppedItem;
            }

            droppedItem.ItemName = listToAdd[0];
            droppedItem.Rarity = StringToEnumHelper.ToEnumNonNumerics<ItemRarity>(ResolveRarity(listToAdd[2]));

            int quanityOut = 0;
            int priceOut = 0;
            if (listToAdd[1].Contains(";") || listToAdd[1].Contains("–"))
            {
                var quanityList = listToAdd[1].Split(new char[] { ';', '–' }).ToList();
                foreach (var item in quanityList)
                {
                    if (int.TryParse(RemoveSpecialCharactersFromString(item), out quanityOut))
                    {
                        droppedItem.QuanityList.Add(quanityOut);
                    }
                }
            }
            else
            {
                if(int.TryParse(RemoveSpecialCharactersFromString(listToAdd[1]), out quanityOut))
                {
                    droppedItem.Quanity = quanityOut;
                }
            }

            if (listToAdd[3].Contains("–") || listToAdd[3].Contains(";"))
            {
                var priceList = listToAdd[3].Split(new char[] { '–', ';' }).ToList();
                foreach (var item in priceList)
                {
                    if(int.TryParse(RemoveSpecialCharactersFromString(item), out priceOut))
                    {
                        droppedItem.Values.Add(priceOut);
                    }
                }
            }
            else
            {
                if (int.TryParse(RemoveSpecialCharactersFromString(listToAdd[3]), out priceOut))
                {
                    droppedItem.Value = priceOut;
                }
            }

            return droppedItem;
        }

        private static string ResolveRarity(string rarity)
        {
            var rarityValue = string.Empty;
            if(rarity.ToUpper().Contains("ALWAYS"))
            {
                rarityValue = "Always";
            }
            else if(rarity.ToUpper().Contains("COMMON"))
            {
                rarityValue = "Common";
            }
            else if (rarity.ToUpper().Contains("UNCOMMON"))
            {
                rarityValue = "Uncommon";
            }
            else if (rarity.ToUpper().Contains("RARE"))
            {
                rarityValue = "Rare";
            }
            else if (rarity.ToUpper().Contains("VERY RARE"))
            {
                rarityValue = "Very Rare";
            }
            else
            {
                rarityValue = "Not Available";
            }
            return rarityValue;
        }

        private static OsRsMonster ResolveMetadata(Dictionary<string, List<string>> monsterData, OsRsMonster monster)
        {
            foreach (var keyValuePair in monsterData)
            {
                if(keyValuePair.Key.Equals("Locations"))
                {
                    monster.Locations = ResolveLocations(keyValuePair.Value);
                }
            }
            return monster;
        }

        private static List<Location> ResolveLocations(List<string> locationValues)
        {
            var locations = new List<Location>();
            if(locationValues.Count == 0)
            {
                return locations;
            }

            foreach (var location in locationValues)
            {
                locations.Add(new Location()
                {
                    GameVersion = GameVersion.OldSchool,
                    LocationName = RemoveSpecialCharactersFromString(location)
                });
            }

            return locations;
        }



    }
}
