using System;

namespace Yaringa.Extensions {
    public static class DateTimeExtensions {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek) {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime StartOfWeek(this DateTime dt) {
            return dt.StartOfWeek(DayOfWeek.Monday);
        }

        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek endOfWeek) {
            int diff = (endOfWeek - dt.DayOfWeek + 7) % 7;
            return dt.AddDays(diff).Date;
        }

        public static DateTime EndOfWeek(this DateTime dt) {
            return dt.EndOfWeek(DayOfWeek.Sunday);
        }
    }
}
