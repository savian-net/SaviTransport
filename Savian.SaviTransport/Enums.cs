using System;
using System.Collections.Generic;
using System.Text;

namespace Savian.SaviTransport
{
    public enum OutputFormat
    {
        CSV,
        TAB,
        JSON,
        XML
    }

    public enum Endian
    {
        BigEndian = 1,
        LittleEndian = 2,
    }

    public enum FloatType
    {
        IeeeSingleFloat,
        IeeeDoubleFloat,
        IbmSingleFloat,
        IbmDoubleFloat,
        VaxSingleFloat
    }

    public enum MethodNumber
    {
        ByMultiple,
        ByLog
    }

    public enum Platform
    {
        IbmFloat,
        IeeeFloat,
        VaxFloat,
    }


}
