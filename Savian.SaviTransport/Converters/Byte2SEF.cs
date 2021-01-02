namespace Savian.SaviTransport
{
    internal static class GlobalMembersByte2SEF
    {
        /***************************************************************************
                                  Byte2SEF.c  -  description
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


        internal static void SingleByte2SEF(FloatType floatType, byte[] bytes, ref byte S, ref int E, ref uint F)
        {
            byte b1;
            byte b2;
            byte b3;
            byte b4;

            switch (floatType)
            {
                case FloatType.IeeeSingleFloat:
                    if (Common.Endian == Endian.BigEndian)
                    {
                        b1 = bytes[0];
                        b2 = bytes[1];
                        b3 = bytes[2];
                        b4 = bytes[3];
                    }
                    else
                    {
                        b1 = bytes[3];
                        b2 = bytes[2];
                        b3 = bytes[1];
                        b4 = bytes[0];
                    }

                    S = (byte) ((b1 & 0x80) >> 7);

                    E = ((b1 & 0x7f) << 1) + ((b2 & 0x80) >> 7);

                    F = (uint) (((b2 & 0x7f) << 16) + (b3 << 8) + b4);

                    break;
                case FloatType.IbmSingleFloat:
                    if (Common.Endian == Endian.BigEndian)
                    {
                        b1 = bytes[0];
                        b2 = bytes[1];
                        b3 = bytes[2];
                        b4 = bytes[3];
                    }
                    else
                    {
                        b1 = bytes[3];
                        b2 = bytes[2];
                        b3 = bytes[1];
                        b4 = bytes[0];
                    }

                    S = (byte) ((b1 & 0x80) >> 7);

                    E = b1 & 0x7f;

                    F = (uint) ((b2 << 16) + (b3 << 8) + b4);

                    break;
                case FloatType.VaxSingleFloat:
                    b1 = bytes[1];
                    b2 = bytes[0];
                    b3 = bytes[3];
                    b4 = bytes[2];

                    S = (byte) ((b1 & 0x80) >> 7);

                    E = ((b1 & 0x7f) << 1) + ((b2 & 0x80) >> 7);

                    F = (uint) (((b2 & 0x7f) << 16) + (b3 << 8) + b4);

                    break;
            }
        }

        internal static void DoubleByte2SEF(FloatType FloatType, byte[] bytes, ref byte S, ref int E, ref uint L1,
            ref uint L2)
        {
            byte b1;
            byte b2;
            byte b3;
            byte b4;
            byte b5;
            byte b6;
            byte b7;
            byte b8;

            switch (FloatType)
            {
                case FloatType.IeeeDoubleFloat:
                    if (Common.Endian == Endian.BigEndian)
                    {
                        b1 = bytes[0];
                        b2 = bytes[1];
                        b3 = bytes[2];
                        b4 = bytes[3];
                        b5 = bytes[4];
                        b6 = bytes[5];
                        b7 = bytes[6];
                        b8 = bytes[7];
                    }
                    else
                    {
                        b1 = bytes[7];
                        b2 = bytes[6];
                        b3 = bytes[5];
                        b4 = bytes[4];
                        b5 = bytes[3];
                        b6 = bytes[2];
                        b7 = bytes[1];
                        b8 = bytes[0];
                    }

                    S = (byte) ((b1 & 0x80) >> 7);

                    E = ((b1 & 0x7f) << 4) + ((b2 & 0xf0) >> 4);

                    L1 = (uint) (((b2 & 0x0f) << 16) + (b3 << 8) + b4);

                    L2 = (uint) ((b5 << 24) + (b6 << 16) + (b7 << 8) + b8);

                    break;
                case FloatType.IbmDoubleFloat:
                    if (Common.Endian == Endian.BigEndian)
                    {
                        b1 = bytes[0];
                        b2 = bytes[1];
                        b3 = bytes[2];
                        b4 = bytes[3];
                        b5 = bytes[4];
                        b6 = bytes[5];
                        b7 = bytes[6];
                        b8 = bytes[7];
                    }
                    else
                    {
                        b1 = bytes[7];
                        b2 = bytes[6];
                        b3 = bytes[5];
                        b4 = bytes[4];
                        b5 = bytes[3];
                        b6 = bytes[2];
                        b7 = bytes[1];
                        b8 = bytes[0];
                    }

                    S = (byte) ((b1 & 0x80) >> 7);

                    E = b1 & 0x7f;

                    L1 = (uint) ((b2 << 16) + (b3 << 8) + b4);

                    L2 = (uint) ((b5 << 24) + (b6 << 16) + (b7 << 8) + b8);

                    break;
            }
        }
    }
}