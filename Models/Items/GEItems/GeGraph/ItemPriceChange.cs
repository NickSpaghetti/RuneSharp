using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuneSharp.Models.Items.GEItems.GeGraph
{
    public class ItemPriceChange
    {
        public SortedDictionary<string, long> PriceChangeOverOneHunderedEightyDays = new SortedDictionary<string, long>();
        long TotalChange { get { return GetTotalChange(); } }
        double Mean { get { return GetMean(); } }
        long Median { get { return GetMedian(); } }
        long Mode { get { return GetMode(); } }
        double StandardDeviation { get { return GetStandardDeviation(); } }


        private bool IsDataInDictionary()
        {
            bool isDataAvailable = false;
            if(PriceChangeOverOneHunderedEightyDays.Count <= 0)
            {
                return isDataAvailable;
            }
            return isDataAvailable = true;
        }

        private long GetTotalChange()
        {
            if(!IsDataInDictionary())
            {
                return 0;
            }
            var first = PriceChangeOverOneHunderedEightyDays.Values.First();
            var last = PriceChangeOverOneHunderedEightyDays.Values.Last();

            return last - first;   
        }

        private double GetMean()
        {
            double mean = 0;
            if (!IsDataInDictionary())
            {
                return mean;
            }
            mean = ValuesToArray().Average();

            return mean;
        }

        private long GetMedian()
        {
            long median = 0;
            if(!IsDataInDictionary())
            {
                return median;
            }

            var priceList = ValuesToArray();

            median = priceList.ElementAt(PriceChangeOverOneHunderedEightyDays.Count / 2);

            return median;
        }

        private long GetMode()
        {
            long mode = 0;
            if (!IsDataInDictionary())
            {
                return mode;
            }

            var priceList = ValuesToArray();

            var groups = priceList.GroupBy(v => v);
            long maxCount = groups.Max(g => g.Count());
            mode = groups.First(g => g.Count() == maxCount).Key;

            return mode;

        }

        private double GetStandardDeviation()
        {
            double std = 0;

            if (!IsDataInDictionary())
            {
                return std;
            }

            var prices = ValuesToArray();
            double avg = prices.Average();
            std = Math.Sqrt(prices.Average(v => Math.Pow(v - avg, 2)));

            /*double sumOfSqu = prices.Select(val => (val - avg) * (val - avg)).Sum();
            std = Math.Sqrt(sumOfSqu / prices.Count);*/
            return std;
        }

        private List<long> ValuesToArray()
        {
            var priceList = new List<long>();

            if (!IsDataInDictionary())
            {
                return priceList;
            }
            foreach (var price in PriceChangeOverOneHunderedEightyDays.Values)
            {
                priceList.Add(price);
            }

            return priceList;
        }
    }
}
