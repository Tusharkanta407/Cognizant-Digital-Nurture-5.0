using System;
using System.Collections.Generic;

namespace DSA.Recursion
{
    class Program
    {
        
        private static Dictionary<int, double> _memoCache = new Dictionary<int, double>();

        static void Main(string[] args)
        {
            double presentValue = 1000.0; 
            double growthRate = 0.05;    
            int years = 10;               

            Console.WriteLine("--- Financial Forecasting (Recursive) ---");
            
            double futureValue = CalculateFutureValue(presentValue, growthRate, years);
            Console.WriteLine($"Forecasted Value after {years} years: ${Math.Round(futureValue, 2)}");

        }

        public static double CalculateFutureValue(double pv, double rate, int year)
        {
            if (year == 0)
                return pv;

            if (_memoCache.ContainsKey(year))
                return _memoCache[year];

            double result = CalculateFutureValue(pv, rate, year - 1) * (1 + rate);

            _memoCache[year] = result;

            return result;
        }
    }
}