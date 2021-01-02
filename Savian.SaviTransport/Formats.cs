using System.Collections.Generic;

namespace Savian.SaviTransport
{
    internal enum FormatType
    {
        Format,
        Informat
    }

    internal enum ContentType
    {
        Char,
        Date,
        DateTime
    }

    internal class Format
    {
        public Format(FormatType fmtType, ContentType contentType, string name)
        {
            FormatType = fmtType;
            ContentType = contentType;
            Name = name;
        }

        public FormatType FormatType { get; set; }

        public ContentType ContentType { get; set; }

        public string Name { get; set; }

        internal static void AddFormats()
        {
            //Formats
            Common.Formats = new List<Format>();
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$ASCIIw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$BIDIw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$BINARYw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$CHARw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$CPTDWw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$CPTWDw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$EBCDICw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$HEXw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$KANJIXw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$KANJIw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$LOGVSRw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$LOGVSw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$MSGCASEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$OCTALw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$QUOTEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$REVERJw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$REVERSw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UCS2BEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UCS2Bw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UCS2LEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UCS2Lw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UCS2XEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UCS2Xw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UCS4BEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UCS4Bw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UCS4LEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UCS4Lw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UCS4XEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UCS4Xw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UESCEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UESCw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UNCREw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UNCRw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UPARENEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UPARENw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UPCASEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$UTF8Xw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$VARYINGw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$VSLOGRw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$VSLOGw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "$w."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "BESTw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "BINARYw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "COMMAXw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "COMMAw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.DateTime, "DATEAMPMw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.DateTime, "DATETIMEw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "DATEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "DAYw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "DDMMYYw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "DDMMYYxw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "DOLLARXw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "DOLLARw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "DOWNAMEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "DTMONYYw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "DTWKDATXw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "DTYEARw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "DTYYQCw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "Dw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURDFDDw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "EURDFDEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "EURDFDNw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "EURDFDTw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "EURDFDWNw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "EURDFMNw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "EURDFMYw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "EURDFWDXw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "EURDFWKXw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRATSw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRBEFw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRCHFw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRCZKw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRDEMw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRDKKw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRESPw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRFIMw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRFRFw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRGBPw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRGRDw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRHUFw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRIEPw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRITLw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRLUFw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRNLGw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRNOKw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRPLZw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRPTEw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRROLw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRRURw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRSEKw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRSITw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRTRLw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURFRYUDw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EUROXw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EUROw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOATSw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOBEFw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOCZKw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTODEMw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTODKKw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOESPw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOFRFw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOGBPw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOGRDw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOHUFw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOITLw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOLUFw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTONLGw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTONOKw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOPTEw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOROLw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTORURw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOSEKw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOTRLw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "EURTOYUDw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "Ew."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "FLOATw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "HDATEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "HEBDATEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "HEXw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.DateTime, "HHMMw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.DateTime, "HOURw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "IBRw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "IBw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "IEEEw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "JULDAYw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "JULIANw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "MINGUOw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "MMDDYYw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "MMDDYYxw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.DateTime, "MMSSw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "MMYYw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "MMYYxw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "MONNAMEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "MONTHw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "MONYYw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "NEGPARENw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "NENGOw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "NLDATEMNw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "NLDATEWNw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "NLDATEWw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "NLDATEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.DateTime, "NLDATMAPw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "NLDATMTMw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "NLDATMWw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "NLDATMw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "NLMNYIw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "NLMNYw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "NLNUMIw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "NLNUMw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "NLPCTIw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "NLPCTw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.DateTime, "NLTIMAPw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.DateTime, "NLTIMEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "NUMXw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "OCTALw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "PDJULGw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "PDJULIw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "PDw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "PERCENTw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "PIBRw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "PIBw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "PKw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "PVALUEw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "QTRRw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "QTRw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "RBw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "ROMANw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "S370FFw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "S370FIBUw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "S370FIBw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "S370FPDUw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "S370FPDw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "S370FPIBw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "S370FRBw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "S370FZDLw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "S370FZDSw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "S370FZDTw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "S370FZDUw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "S370FZDw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "SSNw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.DateTime, "TIMEAMPMw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.DateTime, "TIMEw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.DateTime, "TODw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "VAXRBw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "WEEKDATEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "WEEKDATXw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "WEEKDAYw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "WEEKUw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "WEEKVw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "WEEKWw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "WORDDATEw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "WORDDATXw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "WORDFw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "WORDSw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "YEARw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "YENw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "YYMMDDw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "YYMMDDxw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "YYMMw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "YYMMxw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "YYMONw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "YYQRw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "YYQRxw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "YYQw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Date, "YYQxw."));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "ZDw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "Zw.d"));
            Common.Formats.Add(new Format(FormatType.Format, ContentType.Char, "w.d"));

            //Informats

            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$ASCIIw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$BINARYw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$CBw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$CHARw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$CHARZBw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$CPTDWw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$CPTWDw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$EBCDICw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$HEXw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$KANJIw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$KANJIXw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$LOGVSw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$LOGVSRw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$OCTALw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$PHEXw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$QUOTEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$REVERJw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$REVERSw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UCS2Bw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UCS2Lw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UCS2LEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UCS2Xw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UCS2XEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UCS4Bw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UCS4Lw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UCS4Xw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UCS4XEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "UESCw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UESCEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UNCRw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UNCREw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UPARENw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UPARENEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UPARENPw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UPCASEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$UTF8Xw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$VARYINGw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$VSLOGw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$VSLOGRw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "$w."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "ANYDTDTEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.DateTime, "ANYDTDTMw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.DateTime, "ANYDTTMEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "BINARYw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "BITSw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "BZw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "CBw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "COMMAw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "COMMAXw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "DATEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.DateTime, "DATETIMEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "DDMMYYw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "Ew.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "EURDFDEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "EURDFDTw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "EURDFMYw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "EUROw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "EUROXw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "FLOATw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "HEXw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "IBw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "IBRw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "IEEEw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "JDATEYMDw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "JNENGOw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "JULIANw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "MINGUOw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "MMDDYYw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "MONYYw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.DateTime, "MSECw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "NENGOw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "NLDATEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.DateTime, "NLDATMw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "NLMNYw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "NLMNYIw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "NLNUMw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "NLNUMIw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "NLPCTw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "NLPCTIw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.DateTime, "NLTIMAPw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.DateTime, "NLTIMEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "NUMXw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "OCTALw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "PDw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "PDJULGw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "PDJULIw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.DateTime, "PDTIMEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "PERCENTw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "PIBw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "PIBRw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "PKw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "PUNCH.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "RBw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "RMFDURw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "RMFSTAMPw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "ROWw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "S370FFw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "S370FIBw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "S370FIBUw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "S370FPDw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "S370FPDUw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "S370FPIBw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "S370FRBw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "S370FZDw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "S370FZDLw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "S370FZDSw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "S370FZDTw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "S370FZDUw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "SHRSTAMPw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "SMFSTAMPw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "STIMERw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.DateTime, "TIMEw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.DateTime, "TODSTAMPw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "TRAILSGNw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "TUw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "VAXRBw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "w.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "WEEKUw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "WEEKVw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "WEEKWw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "YENw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "YYMMDDw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "YYMMNw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Date, "YYQw."));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "ZDw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "ZDBw.d"));
            Common.Formats.Add(new Format(FormatType.Informat, ContentType.Char, "ZDVw.d"));
        }
    }
}