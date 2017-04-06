using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFrontEnd.Converter
{
    class DateTimeConverter
    {
        public static DateTime DateTimeArrive(DateTimeOffset date, TimeSpan time)
        {
            return new DateTime(date.Year, date.Month, date.Day, 14, 0, 0);
        }

        public static DateTime DateTimeLeave(DateTimeOffset date, TimeSpan time)
        {
            return new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);
        }

    }
}
