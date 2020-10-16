using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Savian.SaviTransport
{
    public static class Extensions
    {
        public static byte[] Subset(this byte[] bytes, int start, int count)
        {
            try
            {
                var subset = new byte[count];
                if ((count + start) <= bytes.Length)
                    Buffer.BlockCopy(bytes, start, subset, 0, count);
                return subset;
            }
            catch (Exception)
            {
                return new byte[0];
                throw;
            }
        }

        public static short GetShortValue(this byte[] p)
        {
            var s = BitConverter.ToInt16(p, 0);
            return s;
        }

        public static int GetIntValue(this object p)
        {
            return GetIntValue(p, Int32.MinValue);
        }

        public static string GetStringValue(this object p)
        {
            return GetStringValue(p, null);
        }

        public static string GetStringValue(this object p, string defaultValue)
        {
            var v = defaultValue;
            if (p != null)
            {
                v = DetermineValue(p);
            }
            return v;
        }

        internal static string DetermineValue(object p)
        {
            var t = p.GetType();
            var i = String.Empty;

            if (t == typeof(byte[]))
            {
                i = Encoding.UTF8.GetString((byte[])p).Replace("\0", "").Trim();
            }
            else
            {
                var pi = t.GetProperty("Value");
                if (pi != null)
                {
                    var o = pi.GetValue(p, null);
                    if (o != null)
                        i = o.ToString();
                }
                else
                    i = p.ToString();
            }
            return i;
        }


        public static int GetIntValue(this object p, int defaultValue)
        {
            var v = defaultValue;
            if (p != null)
            {
                var t = p.GetType();
                if (t == typeof(byte[]))
                {
                    var bytes = (byte[])p;
                    if (bytes.Length == 1)
                        v = bytes[0];
                    else if (bytes.Length == 2)
                        v = BitConverter.ToInt16(bytes, 0);
                    else if (bytes.Length == 4)
                        v = BitConverter.ToInt32(bytes, 0);
                }
                else
                {
                    var i = DetermineValue(p);
                    if (i != "")
                        int.TryParse(i, out v);
                }
            }
            return v;
        }
 
    }
}
