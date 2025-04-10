using RuneSharp.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RuneSharp.Helpers.MathHelpers
{
    public static class RsGpHelper
    {
        public static long ConvertGpToLong(string gp)
        {
            gp = gp.ToLower();
            bool isNegitive = gp.Contains('-');
            char lastIndex = gp.ToArray()[gp.Length-1];
            long result = Convert.ToInt64(GetNumbers(gp) * ResloveUnit(lastIndex));
            if (isNegitive)
            {
                result *= -1;
            }
            return result;
        }

        public static string ConvertGpToString(int gp)
        {
            return gp.ToString() + CreateUnit(gp);
        }

        private static long ResloveUnit(char unit)
        {
            switch(unit)
            {
                case RsConstants.GP.k:
                    return RsConstants.GP.OneK;
                case RsConstants.GP.mill:
                    return RsConstants.GP.OneMill;
                case RsConstants.GP.bill:
                    return RsConstants.GP.OneBill;
                default:
                    return RsConstants.GP.OneGp;
            }
        }

        private static string CreateUnit(int gp)
        {
            string unit = "";
            if(gp >= RsConstants.GP.OneGp && gp < RsConstants.GP.OneK)
            {
                unit = RsConstants.GP.gp;
            }
            else if(gp >= RsConstants.GP.OneK && gp < RsConstants.GP.OneMill)
            {
                unit = RsConstants.GP.k.ToString();
            }
            else if(gp >= RsConstants.GP.OneMill && gp < RsConstants.GP.OneBill)
            {
                unit = RsConstants.GP.mill.ToString();
            }
            else if(gp >= RsConstants.GP.OneBill)
            {
                unit = RsConstants.GP.bill.ToString();
            }
            else
            {
                unit = RsConstants.GP.gp;
            }
            return unit;
        }

        private static double GetNumbers(string gp)
        {
            return Convert.ToDouble(Regex.Replace(gp, "[^.0-9]", string.Empty));
        }
    }
}
