
namespace Savian.SaviTransport
{
    internal static class GlobalMembersIeeeFloat
    {
        /***************************************************************************
                                  IeeeFloat.c  -  description
                                     -------------------
            begin                : November 2005
            copyright            : (C) 2005 by John Jiyang Hou
            email                : jyhou69@hotmail.com
         ***************************************************************************/

        /***************************************************************************
         *                                                                         *
         *   This program is free software; you can redistribute it and/or modify  *
         *   it under the terms of the GNU General Public License as published by  *
         *   the Free Software Foundation; either version 2 of the License, or     *
         *   (at your option) any later version.                                   *
         *                                                                         *
         ***************************************************************************/


        // all bytes array ( either input parameter or return parameter ) assume as local memory order

        // transform ieee single float to bytes by LOG method
        internal static int IeeeSingleFloat2ByteL(float IeeeSingleFloat, byte[] bytes)
        {
            // ===================================
            // S EEEEEEEE FFFFFFF FFFFFFFF FFFFFFFF
            // 0 1      8 9                       31
            // byte0    byte1     byte2    byte3
            // ===================================	

            byte S = new byte();
            int E = 0;
            uint F = 0;

            GlobalMembersFloat2SEF.SingleFloat2SEF(MethodNumber.ByLog, FloatType.IeeeSingleFloat,
                                                   (double) IeeeSingleFloat, ref S, ref E, ref F);

            GlobalMembersSEF2Byte.SingleSEF2Byte(FloatType.IeeeSingleFloat, S, E, F, bytes);

            return 0;
        }

        // transform ieee single float to bytes by MULTIPLE method
        internal static int IeeeSingleFloat2ByteM(float IeeeSingleFloat, byte[] bytes)
        {
            // ===================================
            // S EEEEEEEE FFFFFFF FFFFFFFF FFFFFFFF
            // 0 1      8 9                       31
            // byte0    byte1     byte2    byte3
            // ===================================	

            byte S = new byte();
            int E = 0;
            uint F = 0;


            GlobalMembersFloat2SEF.SingleFloat2SEF(MethodNumber.ByMultiple, FloatType.IeeeSingleFloat,
                                                   (double) IeeeSingleFloat, ref S, ref E, ref F);

            GlobalMembersSEF2Byte.SingleSEF2Byte(FloatType.IeeeSingleFloat, S, E, F, bytes);

            return 0;

        }

        // transform byte to ieee single precision float
        internal static int Byte2IeeeSingleFloat(byte[] bytes, ref float IeeeSingleFloat)
        {
            // ===================================
            // S EEEEEEEE FFFFFFF FFFFFFFF FFFFFFFF
            // 0 1      8 9                       31
            // byte0    byte1     byte2    byte3
            // ===================================			

            byte S = new byte();
            int E = 0;
            uint F = 0;


            GlobalMembersByte2SEF.SingleByte2SEF(FloatType.IeeeSingleFloat, bytes, ref S, ref E, ref F);

            GlobalMembersSEF2Float.SingleSEF2Float(FloatType.IeeeSingleFloat, S, E, F, ref IeeeSingleFloat);

            return 0;
        }

        // transform ieee double float to byte by LOG method
        internal static int IeeeDoubleFloat2ByteL(double IeeeDoubleFloat, byte[] bytes)
        {
            // ===================================
            // S EEEEEEE EEEE FFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF
            // 0 1          1112                                                       63
            // byte0     byte1     byte2    byte3    byte4    byte5    byte6    byte7
            //                L1                     L2
            // ===================================	

            byte S = new byte();
            int E = 0;
            uint L1 = 0;
            uint L2 = 0;

            GlobalMembersFloat2SEF.DoubleFloat2SEF(MethodNumber.ByLog, FloatType.IeeeDoubleFloat, IeeeDoubleFloat, ref S,
                                                   ref E, ref L1, ref L2);

            GlobalMembersSEF2Byte.DoubleSEF2Byte(FloatType.IeeeDoubleFloat, S, E, L1, L2, bytes);

            return 0;
        }

        // transform ieee double float to bytes by MUlTIPLE method
        internal static int IeeeDoubleFloat2ByteM(double IeeeDoubleFloat, byte[] bytes)
        {
            // ===================================
            // S EEEEEEE EEEE FFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF
            // 0 1          1112                                                       63
            // byte0     byte1     byte2    byte3    byte4    byte5    byte6    byte7
            //                L1                     L2
            // ===================================	

            byte S = new byte();
            int E = 0;
            uint L1 = 0;
            uint L2 = 0;

            GlobalMembersFloat2SEF.DoubleFloat2SEF(MethodNumber.ByMultiple, FloatType.IeeeDoubleFloat, IeeeDoubleFloat,
                                                   ref S, ref E, ref L1, ref L2);

            GlobalMembersSEF2Byte.DoubleSEF2Byte(FloatType.IeeeDoubleFloat, S, E, L1, L2, bytes);

            return 0;
        }

        // transform byte to ieee double precision float
        internal static int Byte2IeeeDoubleFloat(byte[] bytes, ref double IeeeDoubleFloat)
        {
            // ===================================
            // S EEEEEEE EEEE FFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF
            // 0 1          1112                                                       63
            // byte0     byte1     byte2    byte3    byte4    byte5    byte6    byte7
            //                L1                     L2
            // ===================================			

            byte S = new byte();
            int E = 0;
            uint L1 = 0;
            uint L2 = 0;

            GlobalMembersByte2SEF.DoubleByte2SEF(FloatType.IeeeDoubleFloat, bytes, ref S, ref E, ref L1, ref L2);

            GlobalMembersSEF2Float.DoubleSEF2Float(FloatType.IeeeDoubleFloat, S, E, L1, L2, ref IeeeDoubleFloat);

            return 0;
        }

        internal static void IeeeSingleFloat2ByteUnion(float IeeeSingleFloat, byte[] bytes)
        {
            Ieee4Bytes u = new Ieee4Bytes();
            u.f = IeeeSingleFloat;

            if (Common.Endian == Endian.LittleEndian)
            {
                bytes[0] = u.b[0];
                bytes[1] = u.b[1];
                bytes[2] = u.b[2];
                bytes[3] = u.b[3];
            }
            else // BigEndian
            {
                bytes[0] = u.b[3];
                bytes[1] = u.b[2];
                bytes[2] = u.b[1];
                bytes[3] = u.b[0];
            }

        }

        internal static void Byte2IeeeSingleFloatUnion(byte[] bytes, ref float IeeeSingleFloat)
        {
            Ieee4Bytes u = new Ieee4Bytes();

            if (Common.Endian == Endian.LittleEndian)
            {
                u.b[0] = bytes[0];
                u.b[1] = bytes[1];
                u.b[2] = bytes[2];
                u.b[3] = bytes[3];
            }
            else // BigEndian
            {
                u.b[0] = bytes[3];
                u.b[1] = bytes[2];
                u.b[2] = bytes[1];
                u.b[3] = bytes[0];
            }

            IeeeSingleFloat = u.f;
        }

        internal static void IeeeDoubleFloat2ByteUnion(double IeeeDoubleFloat, byte[] bytes)
        {
            Ieee8Bytes u = new Ieee8Bytes();
            u.f = IeeeDoubleFloat;

            if (Common.Endian == Endian.LittleEndian)
            {
                bytes[0] = u.b[0];
                bytes[1] = u.b[1];
                bytes[2] = u.b[2];
                bytes[3] = u.b[3];
                bytes[4] = u.b[4];
                bytes[5] = u.b[5];
                bytes[6] = u.b[6];
                bytes[7] = u.b[7];

            }
            else // BigEndian
            {
                bytes[0] = u.b[7];
                bytes[1] = u.b[6];
                bytes[2] = u.b[5];
                bytes[3] = u.b[4];
                bytes[4] = u.b[3];
                bytes[5] = u.b[2];
                bytes[6] = u.b[1];
                bytes[7] = u.b[0];
            }
        }

        internal static void Byte2IeeeDoubleFloatUnion(byte[] bytes, ref double IeeeDoubleFloat)
        {
            Ieee8Bytes u = new Ieee8Bytes();

            if (Common.Endian == Endian.LittleEndian)
            {
                u.b[0] = bytes[0];
                u.b[1] = bytes[1];
                u.b[2] = bytes[2];
                u.b[3] = bytes[3];
                u.b[4] = bytes[4];
                u.b[5] = bytes[5];
                u.b[6] = bytes[6];
                u.b[7] = bytes[7];
            }
            else // BigEndian
            {
                u.b[0] = bytes[7];
                u.b[1] = bytes[6];
                u.b[2] = bytes[5];
                u.b[3] = bytes[4];
                u.b[4] = bytes[3];
                u.b[5] = bytes[2];
                u.b[6] = bytes[1];
                u.b[7] = bytes[0];
            }

            IeeeDoubleFloat = u.f;

        }
    }

}