using System;
using System.Collections.Generic;

namespace Savian.SaviTransport
{
    internal static class Common
    {
        /// <summary>
        ///     A list of SAS formats/informats. These are used to help determine whether a field is a date/datetime
        /// </summary>
        public static List<Format> Formats { get; set; }

        public static Endian Endian { get; set; } = Endian.LittleEndian;

        /// <summary>
        ///     Converts a SAS Date/DateTime value to a .NET DateTime value
        /// </summary>
        /// <param name="dateTime">The SAS date/datetime value</param>
        /// <param name="date">Whether the value being passed is a SAS date or datetime</param>
        /// <returns>A .NET datetime value</returns>
        public static DateTime ConvertSasToNetDateTime(double dateTime, bool date)
        {
            var dt = new DateTime(1960, 1, 1);
            if (date)
                dt = dt.AddDays(dateTime);
            else
                dt = dt.AddSeconds(dateTime);
            return dt;
        }

        /// <summary>
        ///     Converts a .NET datetime value to a SAS date or datetime value
        /// </summary>
        /// <param name="dt">.NET datetime</param>
        /// <param name="date">Whether a SAS date or datetime value is returned</param>
        /// <returns></returns>
        public static double ConvertNetToSasDateTime(DateTime dt, bool date)
        {
            var ts = dt - new DateTime(1960, 1, 1);
            if (date)
                return ts.Days;
            return ts.TotalSeconds;
        }
    }
}