using System;

namespace BlazorFinancePortfolio.Helpers
{
    public class NumbersHelper
    {
        public static string FormatDecimal(decimal num)
        {
            // Ensure number has max 3 significant digits (no rounding up can happen)
            long i = (long)Math.Pow(10, (int)Math.Max(0, Math.Log10(Convert.ToDouble(num)) - 2));

            if (i != 0)
            {
                num = num / i * i;
            }

            if (num >= 1000000000)
                return (num / 1000000000).ToString("0.##") + "B";
            if (num >= 1000000)
                return (num / 1000000).ToString("0.##") + "M";
            if (num >= 1000)
                return (num / 1000).ToString("0.##") + "K";

            return num.ToString("0.##");
        }

        public static string GetChangeNumberClass(decimal value)
        {
            if (value > 0)
            {
                return "grid-cell-positive";
            }
            else if (value < 0)
            {
                return "grid-cell-negative";
            }

            return string.Empty;
        }
    }
}
