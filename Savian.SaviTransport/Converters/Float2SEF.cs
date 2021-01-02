using System;

namespace Savian.SaviTransport
{
    internal static class GlobalMembersFloat2SEF
    {
        /***************************************************************************
                                  Float2SEF.c  -  description
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


        internal static int Float2S(double IeeeDoubleFloat, ref byte S)
        {
            if (IeeeDoubleFloat < 0)
                S = 0x80;
            else
                S = 0;
            return 0;
        }

        internal static int SingleFloat2SEF(MethodNumber MethodNo, FloatType FloatType, double IeeeDoubleFloat,
            ref byte S,
            ref int E, ref uint F)
        {
            Float2S(IeeeDoubleFloat, ref S);

            double fraction = 0;

            switch (MethodNo)
            {
                case MethodNumber.ByMultiple:
                    Float2EF1(FloatType, IeeeDoubleFloat, ref E, ref fraction);
                    break;
                case MethodNumber.ByLog:
                    Float2EF2(FloatType, IeeeDoubleFloat, ref E, ref fraction);
                    break;
            }

            SingleFrac2Long(FloatType, fraction, ref F);

            return 0;
        }

        internal static int DoubleFloat2SEF(MethodNumber MethodNo, FloatType FloatType, double IeeeDoubleFloat,
            ref byte S,
            ref int E, ref uint L1, ref uint L2)
        {
            Float2S(IeeeDoubleFloat, ref S);

            double fraction = 0;

            switch (MethodNo)
            {
                case MethodNumber.ByMultiple:
                    Float2EF1(FloatType, IeeeDoubleFloat, ref E, ref fraction);
                    break;
                case MethodNumber.ByLog:
                    Float2EF2(FloatType, IeeeDoubleFloat, ref E, ref fraction);
                    break;
            }

            DoubleFrac2Long(FloatType, fraction, ref L1, ref L2);

            return 0;
        }

        internal static int SingleFrac2Long(FloatType FloatType, double fraction, ref uint F)
        {
            if (fraction < 0 || fraction > 1.0)
                return -1;

            double F1 = 0;

            switch (FloatType)
            {
                case FloatType.IeeeSingleFloat:
                    F1 = 8388608.0; // 2^23

                    break;
                case FloatType.IbmSingleFloat:
                case FloatType.VaxSingleFloat:
                    F1 = 16777216.0; // 2^24

                    break;
            }

            var M = fraction * F1;

            F = (uint) M;

            return 0;
        }

        internal static int DoubleFrac2Long(FloatType FloatType, double fraction, ref uint L1, ref uint L2)
        {
            if (fraction < 0 || fraction > 1.0)
                return -1;

            double F1 = 0;
            double F2 = 0;

            switch (FloatType)
            {
                case FloatType.IeeeDoubleFloat:
                    F2 = 4294967296.0; // 2^32
                    F1 = 4503599627370496.0; // 2^52

                    break;
                case FloatType.IbmDoubleFloat:
                    F2 = 4294967296.0; // 2^32
                    F1 = 72057594037927936.0; // 2^56

                    break;
            }

            var M = fraction * F1;

            L1 = (uint) (M / F2);
            L2 = (uint) (M - L1 * F2);

            return 0;
        }


        internal static int Float2EF1(FloatType FloatType, double IeeeDoubleFloat, ref int exponent,
            ref double fraction)
        {
            /*
             * C >= 0
             *
             * Formula: V = ( -1 ) ^ S * ( C + F ) * A ^ ( E - B )
             *
             * G is the fraction value when all fraction bits are 1 
             *
             * Formula: 1/2 + 1/4 + ... + 1/2^n = 1.0 - 1/2^n
             *
             * Ieee and Ibm fraction bits start from 1/2, Vax fraction bits start from 1/4
             * 
             * 0 < F < G
             * C < C + F < C + G
             *
             * Ieee: G = 1.0-1/2^(23 or 52)   
             * Ibm: G = 1.0-1/2^(24 or 56), 
             * Vax: G = 0.5 - 1/2^(24)
             *
             * DB = E - B
             *
             * 1. V < C			DB < 0
             * 2. V = C			DB < 0
             * 3. C < V < C + G		DB = 0, F = V - C
             * 4. V = C + G		DB > 0
             * 5. V > C + G		DB > 0
             */

            double A = 0;
            double C = 0;
            double G = 0;
            double V = 0;
            double F = 0;
            var E = 0;
            var B = 0;

            switch (FloatType)
            {
                case FloatType.IeeeSingleFloat:
                    A = 2.0; // base
                    B = 127; // exponent offset
                    C = 1.0; // fraction offset
                    G = 1.0 - Math.Pow(0.5, 23.0);
                    break;
                case FloatType.IeeeDoubleFloat:
                    A = 2.0;
                    B = 1023;
                    C = 1.0;
                    G = 1.0 - Math.Pow(0.5, 52.0);
                    break;
                case FloatType.IbmSingleFloat:
                    A = 16.0;
                    B = 64;
                    C = 0;
                    G = 1.0 - Math.Pow(0.5, 24.0);
                    break;
                case FloatType.IbmDoubleFloat:
                    A = 16.0;
                    B = 64;
                    C = 0;
                    G = 1.0 - Math.Pow(0.5, 56.0);
                    break;
                case FloatType.VaxSingleFloat:
                    A = 2.0;
                    B = 128;
                    C = 0.5;
                    G = 0.5 - Math.Pow(0.5, 24.0);
                    break;
            }

            V = IeeeDoubleFloat;

            if (V == 0)
                return -1;

            if (V < 0)
                V = -1.0 * V;

            int i;

            if (V <= C)
            {
                for (i = 1;; i++)
                {
                    V *= A;
                    if (V >= C)
                        break;
                }

                E = B - i;
                F = V - C;
            }
            else if (V >= C + G)
            {
                for (i = 1;; i++)
                {
                    V /= A;
                    if (V <= C + G)
                        break;
                }

                E = B + i;
                F = V - C;
            }
            else
            {
                E = B;
                F = V - C;
            }

            exponent = E;
            fraction = F;

            return 0;
        }

        internal static int Float2EF2(FloatType FloatType, double IeeeDoubleFloat, ref int exponent,
            ref double fraction)
        {
            /*
             * C >= 0
             *
             * Formula: V = ( -1 ) ^ S * ( C + F ) * A ^ ( E - B )
             *
             * 0 < F < 1.0
             * C < C + F < C + 1.0 
             *
             * DB = E - B
             *
             * 1. V < C			DB < 0
             * 2. V = C			DB < 0
             * 3. C < V < C + 1.0	DB = 0, F = V - C
             * 4. V = C + 1.0		DB > 0
             * 5. V > C + 1.0		DB > 0
             */

            const double D = 0.69314718055994529; // log2

            double A = 0;
            double C = 0;
            double V = 0;
            double F = 0;
            var E = 0;
            var B = 0;
            double exp = 0;

            V = IeeeDoubleFloat;

            if (V == 0)
                return -1;

            if (V < 0)
                V = -1.0 * V;

            switch (FloatType)
            {
                case FloatType.IeeeSingleFloat:
                    A = 2.0; // base
                    B = 127; // exponent offset
                    C = 1.0; // fraction offset
                    exp = Math.Log(V) / D + B; // exponent double expresion

                    break;
                case FloatType.IeeeDoubleFloat:
                    A = 2.0;
                    B = 1023;
                    C = 1.0;
                    exp = Math.Log(V) / D + B;

                    break;
                case FloatType.IbmSingleFloat:
                case FloatType.IbmDoubleFloat:
                    A = 16.0;
                    B = 64;
                    C = 0;
                    exp = Math.Log(V) / D * 0.25 + 1.0 + B;

                    break;
                case FloatType.VaxSingleFloat:
                    A = 2.0;
                    B = 128;
                    C = 0.5;
                    exp = Math.Log(V) / D + 1.0 + B;

                    break;
            }

            E = (int) exp;

            F = V / Math.Pow(A, E - B) - C;

            exponent = E;
            fraction = F;

            return 0;
        }
    }
}