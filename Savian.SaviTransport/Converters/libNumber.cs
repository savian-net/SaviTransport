using System.Runtime.InteropServices;

namespace Savian.SaviTransport
{

    public static class GlobalMembersLibNumber
    {

        //int MemoryByteOrder();

        // General method
        //int Float2S(double IeeeDoubleFloat, ref byte S);

        //int Float2EF1(int FloatType, double IeeeDoubleFloat, ref int exponent, ref double fraction);
        //int Float2EF2(int FloatType, double IeeeDoubleFloat, ref int exponent, ref double fraction);

        //int SingleFrac2Long(int FloatType, double fraction, ref uint F);
        //int DoubleFrac2Long(int FloatType, double fraction, ref uint L1, ref uint L2);

        //int SingleFloat2SEF(int MethodNo, int FloatType, double IeeeDoubleFloat, ref byte S, ref int E, ref uint F);
        //int DoubleFloat2SEF(int MethodNo, int FloatType, double IeeeDoubleFloat, ref byte S, ref int E, ref uint L1, ref uint L2);
        //int SingleSEF2Byte(int FloatType, byte S, int E, uint F, byte[] bytes);
        //int DoubleSEF2Byte(int FloatType, byte S, int E, uint L1, uint L2, byte[] bytes);

        //int SingleSEF2Float(int FloatType, byte S, int E, uint F, ref float IeeeSingleFloat);
        //int DoubleSEF2Float(int FloatType, byte S, int E, uint L1, uint L2, ref double IeeeDoubleFloat);
        //int SingleByte2SEF(int FloatType, byte[] bytes, ref byte S, ref int E, ref uint F);
        //int DoubleByte2SEF(int FloatType, byte[] bytes, ref byte S, ref int E, ref uint L1, ref uint L2);

        // Ieee Float
        //int IeeeSingleFloat2ByteUnion(float IeeeSingleFloat, byte[] bytes);
        //int Byte2IeeeSingleFloatUnion(byte[] bytes, ref float IeeeSingleFloat);
        //int IeeeDoubleFloat2ByteUnion(double IeeeDoubleFloat, byte[] bytes);
        //int Byte2IeeeDoubleFloatUnion(byte[] bytes, ref double IeeeDoubleFloat);

        //int IeeeSingleFloat2ByteL(float IeeeSingleFloat, byte[] bytes);
        //int Byte2IeeeSingleFloat(byte[] bytes, ref float IeeeSingleFloat);
        //int IeeeDoubleFloat2ByteL(double IeeeDoubleFloat, byte[] bytes);
        //int Byte2IeeeDoubleFloat(byte[] bytes, ref double IeeeDoubleFloat);

        //int IeeeSingleFloat2ByteM(float IeeeSingleFloat, byte[] bytes);
        //int IeeeDoubleFloat2ByteM(double IeeeDoubleFloat, byte[] bytes);

        // Ibm Float
        //int IbmSingleFloat2ByteL(float IbmSingleFloat, byte[] bytes);
        //int Byte2IbmSingleFloat(byte[] bytes, ref float IbmSingleFloat);
        //int IbmDoubleFloat2ByteL(double IbmDoubleFloat, byte[] bytes);
        //int Byte2IbmDoubleFloat(byte[] bytes, ref double IbmDoubleFloat);

        //int IbmSingleFloat2ByteM(float IbmSingleFloat, byte[] bytes);
        //int IbmDoubleFloat2ByteM(double IbmDoubleFloat, byte[] bytes);

        // Vax Float
        //int VaxSingleFloat2ByteL(float VaxSingleFloat, byte[] bytes);
        //int Byte2VaxSingleFloat(byte[] bytes, ref float VaxSingleFloat);

        //int VaxSingleFloat2ByteM(float VaxSingleFloat, byte[] bytes);

        // Test
        //void TestlibNumber(int FloatType, float f, double df);
        //void IeeeFloatTest(float f, double df);
        //void IbmFloatTest(float f, double df);
        //void VaxFloatTest(float f, double df);
    }

    /***************************************************************************
                              libNumber.h  -  description
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



    //C++ TO C# CONVERTER TODO TASK: Unions are not supported in C#, but the following union can be simulated with the StructLayout and FieldOffset attributes.
    //ORIGINAL LINE: union Ieee4Bytes
    [StructLayout(LayoutKind.Explicit)]
    public struct Ieee4Bytes
    {
        [FieldOffset(0)] public byte[] b; //= new byte[4];
        [FieldOffset(0)] public uint l;
        [FieldOffset(0)] public float f;
    }

    //C++ TO C# CONVERTER TODO TASK: Unions are not supported in C#, but the following union can be simulated with the StructLayout and FieldOffset attributes.
    //ORIGINAL LINE: union Ieee8Bytes
    [StructLayout(LayoutKind.Explicit)]
    public struct Ieee8Bytes
    {
        [FieldOffset(0)] public byte[] b; //= new byte[8];
        [FieldOffset(0)] public ulong l;
        [FieldOffset(0)] public double f;
    }
}

