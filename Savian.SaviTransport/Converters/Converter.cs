namespace Savian.SaviTransport
{
    public class Converter
    {
        /*
        The Basics
	
        "Little Endian" means that the low-order byte of the number is stored in memory at the lowest address, and the high-order byte at the highest address. (The little end comes first.) For example, a 4 byte LongInt
	
            Byte3 Byte2 Byte1 Byte0
	
        will be arranged in memory as follows:
	
            Base Address+0   Byte0
            Base Address+1   Byte1
            Base Address+2   Byte2
            Base Address+3   Byte3
	
        Intel processors (those used in PC's) use "Little Endian" byte order.
	
        "Big Endian" means that the high-order byte of the number is stored in memory at the lowest address, and the low-order byte at the highest address. (The big end comes first.) Our LongInt, would then be stored as:
	
            Base Address+0   Byte3
            Base Address+1   Byte2
            Base Address+2   Byte1
            Base Address+3   Byte0
	
        Motorola processors (those used in Mac's) use "Big Endian" byte order.
         */


        /// <summary>
        ///     Converts a series of bytes to a double after conversion. Only 8 bytes are allowed.
        /// </summary>
        /// <param name="platform">The platform where the bytes originated</param>
        /// <param name="bytes">The series of byte sto evaulate</param>
        /// <returns>A .NET double</returns>
        public double ConvertBytesToDouble(Platform platform, byte[] bytes)
        {
            double result = 0;
            if (bytes.Length != 8)
                return 0;

            switch (platform)
            {
                case Platform.IbmFloat:
                    GlobalMembersIbmFloat.Byte2IbmDoubleFloat(bytes, ref result);
                    break;
                case Platform.IeeeFloat:
                    GlobalMembersIeeeFloat.Byte2IeeeDoubleFloat(bytes, ref result);
                    break;
            }

            return result;
        }

        /// <summary>
        ///     Converts a series of bytes to a single after conversion. Only 4 bytes are allowed.
        /// </summary>
        /// <param name="platform">The platform where the bytes originated</param>
        /// <param name="bytes">The series of byte sto evaulate</param>
        /// <returns>A .NET double</returns>
        public double ConvertBytesToSingle(Platform platform, byte[] bytes)
        {
            float result = 0;
            if (bytes.Length != 4)
                return 0;

            switch (platform)
            {
                case Platform.IbmFloat:
                    GlobalMembersIbmFloat.Byte2IbmSingleFloat(bytes, ref result);
                    break;
                case Platform.IeeeFloat:
                    GlobalMembersIeeeFloat.Byte2IeeeSingleFloat(bytes, ref result);
                    break;
                case Platform.VaxFloat:
                    GlobalMembersVaxFloat.Byte2VaxSingleFloat(bytes, ref result);
                    break;
            }

            return result;
        }

        /// <summary>
        ///     Converts a double to a series of bytes.
        /// </summary>
        /// <param name="platform">
        ///     The platform where the bytes are destined. A VAX does not use a double so the return value will
        ///     always be 0 for a VAX.
        /// </param>
        /// <param name="value">The double value to convert to bytes</param>
        /// <returns>A byte array</returns>
        public byte[] ConvertDoubleToBytes(Platform platform, double value)
        {
            var bytes = new byte[8];
            switch (platform)
            {
                case Platform.IbmFloat:
                    GlobalMembersIbmFloat.IbmDoubleFloat2ByteM(value, bytes);
                    break;
                case Platform.IeeeFloat:
                    GlobalMembersIeeeFloat.IeeeDoubleFloat2ByteM(value, bytes);
                    break;
                default:
                    return bytes;
            }

            return bytes;
        }

        /// <summary>
        ///     Converts a single to a series of bytes.
        /// </summary>
        /// <param name="platform">The platform where the bytes are destined.</param>
        /// <param name="value">The single value to convert to bytes</param>
        /// <returns>A byte array</returns>
        public byte[] ConvertSingleToBytes(Platform platform, float value)
        {
            var bytes = new byte[8];
            switch (platform)
            {
                case Platform.IbmFloat:
                    GlobalMembersIbmFloat.IbmSingleFloat2ByteM(value, bytes);
                    break;
                case Platform.IeeeFloat:
                    GlobalMembersIeeeFloat.IeeeSingleFloat2ByteM(value, bytes);
                    break;
                case Platform.VaxFloat:
                    GlobalMembersVaxFloat.VaxSingleFloat2ByteL(value, bytes);
                    break;
            }

            return bytes;
        }
    }
}