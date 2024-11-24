using System;

namespace SupplySyncBackend.Utilities
{
    public static class DateTimeUtility
    {
        public static bool IsDateWithinRange(DateTime date, int days)
        {
            return date <= DateTime.Now.AddDays(days);
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static int DaysUntil(DateTime date)
        {
            return (date - DateTime.Now).Days;
        }
    }
}
