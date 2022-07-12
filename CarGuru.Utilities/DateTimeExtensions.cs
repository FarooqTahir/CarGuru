using System;
using System.Collections.Generic;
using System.Text;

namespace FSOPT.Utilities
{
    public static class DateTimeExtensions
    {
        public static string DateFormate()
        {
            return "MM/dd/yyyy";
        }
        public static string ToFormatDateTime(this DateTime dateTime)
        {
            return string.Format("{0: ddd, dd MMM yyy HH:mm}", dateTime);
        }
        public static string ToFormatDateTime(this DateTime? dateTime)
        {
            if(dateTime.HasValue) return string.Format("{0: ddd, dd MMM yyy HH:mm}", dateTime.Value);
            return "";
        }
        public static string ToFormatDate(this DateTime dateTime)
        {
            return string.Format("{0: ddd, dd MMM yyy}", dateTime);
        }
        public static string ToFormatDate(this DateTime? dateTime)
        {
            if (dateTime.HasValue) return string.Format("{0: ddd, dd MMM yyy}", dateTime.Value);
            return "";
        }
    }
}
