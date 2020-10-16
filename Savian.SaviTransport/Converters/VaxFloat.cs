
namespace Savian.SaviTransport
{
    internal static class GlobalMembersVaxFloat
    {
        /***************************************************************************
                                  VaxFloat.c  -  description
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


        // transform vax single float to byte by LOG method
        internal static int VaxSingleFloat2ByteL(float VaxSingleFloat, byte[] bytes)
        {
            // ===================================
            // S EEEEEEEE FFFFFFF FFFFFFFF FFFFFFFF
            // 0 1      8 9                       31
            // byte1    byte0     byte3    byte2
            // ===================================	

            var S = new byte();
            var E = 0;
            uint F = 0;

            GlobalMembersFloat2SEF.SingleFloat2SEF(MethodNumber.ByLog, FloatType.VaxSingleFloat, (double) VaxSingleFloat,
                                                   ref S, ref E, ref F);

            GlobalMembersSEF2Byte.SingleSEF2Byte(FloatType.VaxSingleFloat, S, E, F, bytes);

            return 0;
        }

        // transform vax single float to byte by MULTIPLAE
        internal static int VaxSingleFloat2ByteM(float VaxSingleFloat, byte[] bytes)
        {
            // ===================================
            // S EEEEEEEE FFFFFFF FFFFFFFF FFFFFFFF
            // 0 1      8 9                       31
            // byte1    byte0     byte3    byte2
            // ===================================	

            var S = new byte();
            var E = 0;
            uint F = 0;


            GlobalMembersFloat2SEF.SingleFloat2SEF(MethodNumber.ByMultiple, FloatType.VaxSingleFloat,
                                                   (double) VaxSingleFloat, ref S, ref E, ref F);

            GlobalMembersSEF2Byte.SingleSEF2Byte(FloatType.VaxSingleFloat, S, E, F, bytes);

            return 0;
        }

        // transform byte to vax single precision float
        internal static int Byte2VaxSingleFloat(byte[] bytes, ref float VaxSingleFloat)
        {
            // ===================================
            // S EEEEEEEE FFFFFFF FFFFFFFF FFFFFFFF
            // 0 1      8 9                       31
            // byte1    byte0     byte3    byte2
            // ===================================			

            var S = new byte();
            var E = 0;
            uint F = 0;


            GlobalMembersByte2SEF.SingleByte2SEF(FloatType.VaxSingleFloat, bytes, ref S, ref E, ref F);

            GlobalMembersSEF2Float.SingleSEF2Float(FloatType.VaxSingleFloat, S, E, F, ref VaxSingleFloat);

            return 0;
        }
    }
}
