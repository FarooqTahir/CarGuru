using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGuru.Extensions
{
    public static class Extension
    {
        public static string DateTimeFormat(this DateTime date)
        {
            return String.Format("{0: dd MMMM  h:mm tt}", date);
        }
        public static string DateTimeFormat(this DateTime? date)
        {
            if (date.HasValue) return String.Format("{0: dd MMMM  h:mm tt}", date);
            else return "";
        }
        public static string DateFormat(this DateTime date)
        {
            return String.Format("{0: MM/dd/yyyy}", date);
        }
        public static string DateFormat(this DateTime? date)
        {
            if (date.HasValue) return String.Format("{0: MM/dd/yyyy}", date);
            else return "";
        }
    }
}
