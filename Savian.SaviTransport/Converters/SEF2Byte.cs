
namespace Savian.SaviTransport
{
    internal static class GlobalMembersSEF2Byte
    {
        /***************************************************************************
                                  SEF2Byte.c  -  description
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


        internal static int SingleSEF2Byte(FloatType FloatType, byte S, int E, uint F, byte[] bytes)
        {

            switch (FloatType)
            {
                case FloatType.IeeeSingleFloat:
                    if (Common.Endian == Endian.BigEndian)
                    {
                        bytes[0] = (byte) (S + ((E & 0xfe) >> 1));
                        bytes[1] = (byte) (((E & 0x01) << 7) + ((F & 0x007f0000) >> 16));
                        bytes[2] = (byte) ((F & 0x0000ff00) >> 8);
                        bytes[3] = (byte) (F & 0x000000ff);
                    }
                    else // LittleEndian
                    {
                        bytes[3] = (byte) (S + ((E & 0xfe) >> 1));
                        bytes[2] = (byte) (((E & 0x01) << 7) + ((F & 0x007f0000) >> 16));
                        bytes[1] = (byte) ((F & 0x0000ff00) >> 8);
                        bytes[0] = (byte) (F & 0x000000ff);
                    }

                    break;

                case FloatType.IbmSingleFloat:
                    if (Common.Endian == Endian.BigEndian)
                    {
                        bytes[0] = (byte) (S + E);
                        bytes[1] = (byte) ((F & 0x00ff0000) >> 16);
                        bytes[2] = (byte) ((F & 0x0000ff00) >> 8);
                        bytes[3] = (byte) (F & 0x000000ff);
                    }
                    else // LittleEndian
                    {
                        bytes[3] = (byte) (S + E);
                        bytes[2] = (byte) ((F & 0x00ff0000) >> 16);
                        bytes[1] = (byte) ((F & 0x0000ff00) >> 8);
                        bytes[0] = (byte) (F & 0x000000ff);
                    }

                    break;
                case FloatType.VaxSingleFloat:
                    bytes[1] = (byte) (S + ((E & 0xfe) >> 1));
                    bytes[0] = (byte) (((E & 0x01) << 7) + ((F & 0x007f0000) >> 16));
                    bytes[3] = (byte) ((F & 0x0000ff00) >> 8);
                    bytes[2] = (byte) (F & 0x000000ff);

                    break;
            }

            return 0;
        }

        internal static int DoubleSEF2Byte(FloatType FloatType, byte S, int E, uint L1, uint L2, byte[] bytes)
        {

            switch (FloatType)
            {
                case FloatType.IeeeDoubleFloat:
                    if (Common.Endian == Endian.BigEndian)
                    {
                        bytes[0] = (byte) (S + ((E & 0x000007f0) >> 4));
                        bytes[1] = (byte) (((E & 0x0000000f) << 4) + ((L1 & 0x000f0000) >> 16));
                        bytes[2] = (byte) ((L1 & 0x0000ff00) >> 8);
                        bytes[3] = (byte) (L1 & 0x000000ff);
                        bytes[4] = (byte) ((L2 & 0xff000000) >> 24);
                        bytes[5] = (byte) ((L2 & 0x00ff0000) >> 16);
                        bytes[6] = (byte) ((L2 & 0x0000ff00) >> 8);
                        bytes[7] = (byte) ((L2 & 0x000000ff));
                    }
                    else
                    {
                        bytes[7] = (byte) (S + ((E & 0x000007f0) >> 4));
                        bytes[6] = (byte) (((E & 0x0000000f) << 4) + ((L1 & 0x000f0000) >> 16));
                        bytes[5] = (byte) ((L1 & 0x0000ff00) >> 8);
                        bytes[4] = (byte) (L1 & 0x000000ff);
                        bytes[3] = (byte) ((L2 & 0xff000000) >> 24);
                        bytes[2] = (byte) ((L2 & 0x00ff0000) >> 16);
                        bytes[1] = (byte) ((L2 & 0x0000ff00) >> 8);
                        bytes[0] = (byte) ((L2 & 0x000000ff));
                    }

                    break;
                case FloatType.IbmDoubleFloat:
                    if (Common.Endian == Endian.BigEndian)
                    {
                        bytes[0] = (byte) (S + E);
                        bytes[1] = (byte) ((L1 & 0x00ff0000) >> 16);
                        bytes[2] = (byte) ((L1 & 0x0000ff00) >> 8);
                        bytes[3] = (byte) (L1 & 0x000000ff);
                        bytes[4] = (byte) ((L2 & 0xff000000) >> 24);
                        bytes[5] = (byte) ((L2 & 0x00ff0000) >> 16);
                        bytes[6] = (byte) ((L2 & 0x0000ff00) >> 8);
                        bytes[7] = (byte) ((L2 & 0x000000ff));
                    }
                    else // LittleEndian
                    {
                        bytes[7] = (byte) (S + E);
                        bytes[6] = (byte) ((L1 & 0x00ff0000) >> 16);
                        bytes[5] = (byte) ((L1 & 0x0000ff00) >> 8);
                        bytes[4] = (byte) (L1 & 0x000000ff);
                        bytes[3] = (byte) ((L2 & 0xff000000) >> 24);
                        bytes[2] = (byte) ((L2 & 0x00ff0000) >> 16);
                        bytes[1] = (byte) ((L2 & 0x0000ff00) >> 8);
                        bytes[0] = (byte) ((L2 & 0x000000ff));
                    }

                    break;
            }

            return 0;
        }
    }
}
