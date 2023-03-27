using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedTextHelper
{
    public static class FixedTextHelper
    {
        public static string FixedDateTime(this DateTime DateTime, bool Time = false)
        {
            PersianCalendar pc = new PersianCalendar();
            int y = pc.GetYear(DateTime);
            int m = pc.GetMonth(DateTime);
            int d = pc.GetDayOfMonth(DateTime);
            int h = DateTime.Hour;
            int s = DateTime.Minute;
            if (Time)
            {
                return y + "/" + m + "/" + d + "  " + h + ":" + s;
            }
            else
            {
                return y + "/" + m + "/" + d;
            }
        }

        public static string FixedPrice(this string Price)
        {
            return string.Format("{0:N0}", int.Parse(Price));
        }
    }
}
