using System;

namespace Savian.SaviTransport
{

    internal static class GlobalMembersSEF2Float
    {
        /***************************************************************************
                                  SEF2Float.c  -  description
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


        internal static int SingleSEF2Float(FloatType FloatType, byte S, int E, uint F, ref float IeeeSingleFloat)
        {
            var ret = 0F;

            double M;
            double F1;
            double A;
            double B;
            double C;
            double D;
            double D2;
            double e23;
            double e24;

            switch (FloatType)
            {
                case FloatType.IeeeSingleFloat:

                    A = 2.0;
                    B = 127.0;
                    C = 1.0;
                    D2 = -126.0;
                    e23 = 8388608.0; // 2^23

                    M = (double) F/e23;

                    if (S == 0)
                        F1 = 1.0;
                    else
                        F1 = -1.0;

                    if (0 < E && E < 255)
                        ret = (float) (F1*(C + M)*Math.Pow(A, E - B));
                    else if (E == 0 && F != 0)
                        ret = (float) (F1*M*Math.Pow(A, D2));
                    else if (E == 0 && F == 0 && S == 1)
                        ret = -0;
                    else if (E == 0 && F == 0 && S == 0)
                        ret = 0F;
                    else if (E == 255 && F != 0) // Not a number
                        return -1;
                    else if (E == 255 && F == 0 && S == 1) // -Infinity
                        return -2;
                    else if (E == 255 && F == 0 && S == 0) // Infinity
                        return -3;

                    break;

                case FloatType.IbmSingleFloat:

                    A = 16.0;
                    B = 64.0;
                    D = 0.69314718055994529; // log2
                    e24 = 16777216.0; // 2^24

                    M = (double) F/e24;

                    if (S == 0)
                        F1 = 1.0;
                    else
                        F1 = -1.0;

                    if (S == 0 && E == 0 && F == 0)
                        ret = 0F;
                    else
                        ret = (float) (F1*M*Math.Pow(A, E - B));

                    break;

                case FloatType.VaxSingleFloat:

                    A = 2.0;
                    B = 128.0;
                    C = 0.5;
                    e24 = 16777216.0; // 2^24

                    M = (double) F/e24;

                    if (S == 0)
                        F1 = 1.0;
                    else
                        F1 = -1.0;

                    if (0 < E)
                        ret = (float) (F1*(C + M)*Math.Pow(A, E - B));
                    else if (E == 0 && S == 0)
                        ret = 0F;
                    else if (E == 0 && S == 1) // reserved
                        return -1;

                    break;
            }

            IeeeSingleFloat = ret;

            return 0;
        }

        internal static int DoubleSEF2Float(FloatType FloatType, byte S, int E, uint L1, uint L2,
                                          ref double IeeeDoubleFloat)
        {
            double ret = 0;

            double F1 = 0;
            double M = 0;
            double M1 = 0;
            double M2 = 0;
            double A = 0;
            double B = 0;
            double C = 0;
            double D1 = 0;
            double D2 = 0;
            double e20 = 0;
            double e24 = 0;
            double e52 = 0;
            double e56 = 0;

            switch (FloatType)
            {
                case FloatType.IeeeDoubleFloat:

                    e20 = 1048576.0; // 2^20
                    e52 = 4503599627370496.0; // 2^52
                    A = 2.0;
                    B = 1023.0;
                    C = 1.0;
                    D1 = 2047;
                    D2 = 1022.0;

                    M1 = (double) L1/e20;
                    M2 = (double) L2/e52;

                    M = M1 + M2;

                    if (S == 0)
                        F1 = 1.0;
                    else
                        F1 = -1.0;

                    if (0 < E && E < D1)
                        ret = F1*(C + M)*Math.Pow(A, E - B);
                    else if (E == 0 && M != 0)
                        ret = F1*M*Math.Pow(A, D2);
                    else if (E == 0 && M == 1)
                        ret = F1*0;
                    else if (E == D1 && M == 0)
                        return -1;
                    else if (E == D1 && M != 0) // Not a number
                        return -2;

                    break;

                case FloatType.IbmDoubleFloat:


                    A = 16.0;
                    B = 64.0;
                    e24 = 16777216.0; // 2^24
                    e56 = 72057594037927936.0; // 2^56

                    M1 = (double) L1/e24;
                    M2 = (double) L2/e56;

                    M = M1 + M2;

                    if (S == 0)
                        F1 = 1.0;
                    else
                        F1 = -1.0;

                    if (S == 0 && E == 0 && M == 0)
                        ret = 0;
                    else
                        ret = F1*M*Math.Pow(A, E - B);

                    break;
            }

            IeeeDoubleFloat = ret;

            return 0;
        }
    }
}
