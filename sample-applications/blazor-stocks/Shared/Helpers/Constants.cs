using System;

namespace BlazorFinancePortfolio.Helpers
{
    public static class Constants
    {
        public const int MS_1_DAY = 86400000;

        public const int MS_5_MINUTES = MS_1_DAY / 24 / 12;
        public const int MS_15_MINUTES = MS_1_DAY / 24 / 4;
        public const int MS_30_MINUTES = MS_1_DAY / 24 / 2;
        public const int MS_1_HOUR = MS_1_DAY / 24;
        public const int MS_4_HOURS = MS_1_DAY / 6;
        public const int MS_12_HOURS = MS_1_DAY / 2;
        public const int MS_4_DAYS = MS_1_DAY * 4;
        public const int MS_1_WEEK = MS_1_DAY * 7;

        public const int MaxLabelStepsInStocksChart = 15;

        public static DateTime GetMaxDate()
        {
            return DateTime.Now.Date;
        }

        public static DateTime GetMinDate()
        {
            return GetMaxDate().AddMonths(-2).Date;
        }
    }
}
