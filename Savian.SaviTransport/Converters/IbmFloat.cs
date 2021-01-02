namespace Savian.SaviTransport
{
    internal static class GlobalMembersIbmFloat
    {
        /***************************************************************************
                                  IbmFloat.c  -  description
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


        // transform ibm single float to byte by LOG method
        internal static int IbmSingleFloat2ByteL(float IbmSingleFloat, byte[] bytes)
        {
            // ===================================
            // S EEEEEEE FFFFFFFF FFFFFFFF FFFFFFFF
            // 0 1     7 9                        31
            // byte0     byte1    byte2    byte3
            // ===================================			

            var S = new byte();
            var E = 0;
            uint F = 0;

            GlobalMembersFloat2SEF.SingleFloat2SEF(MethodNumber.ByLog, FloatType.IbmSingleFloat, IbmSingleFloat,
                ref S, ref E, ref F);

            GlobalMembersSEF2Byte.SingleSEF2Byte(FloatType.IbmSingleFloat, S, E, F, bytes);

            return 0;
        }

        // transform ibm single float to byte by MULTIPLE 
        internal static int IbmSingleFloat2ByteM(float IbmSingleFloat, byte[] bytes)
        {
            // ===================================
            // S EEEEEEE FFFFFFFF FFFFFFFF FFFFFFFF
            // 0 1     7 9                        31
            // byte0     byte1    byte2    byte3
            // ===================================			

            var S = new byte();
            var E = 0;
            uint F = 0;

            GlobalMembersFloat2SEF.SingleFloat2SEF(MethodNumber.ByMultiple, FloatType.IbmSingleFloat,
                IbmSingleFloat, ref S, ref E, ref F);

            GlobalMembersSEF2Byte.SingleSEF2Byte(FloatType.IbmSingleFloat, S, E, F, bytes);

            return 0;
        }

        // transform byte to ibm single precision float
        internal static int Byte2IbmSingleFloat(byte[] bytes, ref float IbmSingleFloat)
        {
            // ===================================
            // S EEEEEEE FFFFFFFF FFFFFFFF FFFFFFFF
            // 0 1     7 9                        31
            // byte0     byte1    byte2    byte3
            // ===================================			

            var S = new byte();
            var E = 0;
            uint F = 0;


            GlobalMembersByte2SEF.SingleByte2SEF(FloatType.IbmSingleFloat, bytes, ref S, ref E, ref F);

            GlobalMembersSEF2Float.SingleSEF2Float(FloatType.IbmSingleFloat, S, E, F, ref IbmSingleFloat);

            return 0;
        }

        // transform IBM double float to bytes by LOG method
        internal static int IbmDoubleFloat2ByteL(double IbmDoubleFloat, byte[] bytes)
        {
            // ===================================
            // S EEEEEEE FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF
            // 0 1     7 9                                                            63
            // byte0     byte1    byte2    byte3    byte4    byte5    byte6    byte7
            // ===================================			

            var S = new byte();
            var E = 0;
            uint L1 = 0;
            uint L2 = 0;

            GlobalMembersFloat2SEF.DoubleFloat2SEF(MethodNumber.ByLog, FloatType.IbmDoubleFloat, IbmDoubleFloat, ref S,
                ref E, ref L1, ref L2);

            GlobalMembersSEF2Byte.DoubleSEF2Byte(FloatType.IbmDoubleFloat, S, E, L1, L2, bytes);

            return 0;
        }

        // transform IBM double float to bytes by MULTIPLE method
        internal static int IbmDoubleFloat2ByteM(double IbmDoubleFloat, byte[] bytes)
        {
            // ===================================
            // S EEEEEEE FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF
            // 0 1     7 9                                                            63
            // byte0     byte1    byte2    byte3    byte4    byte5    byte6    byte7
            // ===================================			

            var S = new byte();
            var E = 0;
            uint L1 = 0;
            uint L2 = 0;

            GlobalMembersFloat2SEF.DoubleFloat2SEF(MethodNumber.ByMultiple, FloatType.IbmDoubleFloat, IbmDoubleFloat,
                ref S, ref E, ref L1, ref L2);

            GlobalMembersSEF2Byte.DoubleSEF2Byte(FloatType.IbmDoubleFloat, S, E, L1, L2, bytes);

            return 0;
        }

        internal static int Byte2IbmDoubleFloat(byte[] bytes, ref double IbmDoubleFloat)
        {
            // ===================================
            // S EEEEEEE FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF
            // 0 1     7 9                                                            63
            // byte0     byte1    byte2    byte3    byte4    byte5    byte6    byte7
            // ===================================			

            var S = new byte();
            var E = 0;
            uint L1 = 0;
            uint L2 = 0;

            GlobalMembersByte2SEF.DoubleByte2SEF(FloatType.IbmDoubleFloat, bytes, ref S, ref E, ref L1, ref L2);

            GlobalMembersSEF2Float.DoubleSEF2Float(FloatType.IbmDoubleFloat, S, E, L1, L2, ref IbmDoubleFloat);

            return 0;
        }
    }
}