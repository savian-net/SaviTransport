using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;

namespace Savian.SaviTransport
{
    public class SasXportLib
    {
        public FileInfo RawFile { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string HostCreated { get; set; }
        public string ReleaseCreated { get; set; }
        public List<SasXportData> XportDataSets { get; set; }

        private SasXportLib saslib;
        private Stream s;
        private long bytesLeft;
        private IPAddress addr;
        private int obsLength;
        private Converter conv;

        SasXportData sasdata = null;

        public SasXportLib()
        {
            XportDataSets = new List<SasXportData>();
            conv = new Converter();
        }

        /// <summary>
        /// Main method for handling the parsing of the SAS XPT file
        /// </summary>
        /// <param name="fi">The raw file to read and process</param>
        /// <seealso>http://support.sas.com/techsup/technote/ts140.html</seealso>
        public void Process(FileInfo fi)
        {
            s = new FileStream(fi.FullName, FileMode.Open);
            bytesLeft = s.Length;
            addr = new IPAddress(0);

            while (bytesLeft >= 0)
            {
                var rec = new byte[80];
                s.Read(rec, 0, 80);
                ParseRecord(rec, fi);
                bytesLeft -= 80;
            }
            s.Close();

        }

        /// <summary>
        /// Parses the individual records. Depending upon the header for a section, 
        /// the parsing will branch off until that section is handled
        /// </summary>
        /// <param name="c">The 80 byte record to parse</param>
        /// <param name="fi">The raw file being read. this is passed in to get file metadata</param>
        private void ParseRecord(byte[] c, FileInfo fi)
        {
            var rec = c.GetStringValue().Trim();

            if (rec.StartsWith("HEADER RECORD*******LIBRARY HEADER RECORD!!!!!!!"))
            {
                saslib = new SasXportLib();
                saslib.RawFile = fi;
            }

            // Parse the library header
            else if (rec.StartsWith("SAS     SAS     SASLIB  "))
            {
                ParseLibraryHeader(rec);
            }

            // Parse the dataset metadata header
            else if (rec.StartsWith("HEADER RECORD*******DSCRPTR HEADER RECORD!!!!!!!"))
            {
                sasdata = new SasXportData();
                var rec2 = new byte[80];
                s.Read(rec2, 0, 80);
                ParseDataSetHeader(sasdata, rec2.GetStringValue());
            }

            // Parse the variable metadata header
            else if (rec.StartsWith("HEADER RECORD*******NAMESTR HEADER RECORD!!!!!!!"))
            {
                //StreamWriter sw = new StreamWriter(@"x:\temp\Novartis\variables.txt");

                var numberOfVariables = int.Parse(rec.Substring(54, 4));
                for (var i = 0; i < numberOfVariables; i++)
                {
                    var sv = ReadVariableRecord(i);
                    sasdata.Variables.Add(sv);
                    //sw.WriteLine(sv.Name + '\t' + sv.Position + '\t' + sv.Length + '\t' + sv.FormatName);
                }
                //sw.Close();
                s.Position = s.Position + (80 - s.Position%80);
                obsLength = CalculateObsLength();
            }

            // Parse the records (observations)
            else if (rec.StartsWith("HEADER RECORD*******OBS     HEADER RECORD!!!!!!!"))
            {
                var streamLength = s.Length - s.Position;
                while (streamLength > obsLength)
                {
                    var obs = ReadRecord(streamLength);
                    sasdata.Observations.Add(obs);
                    streamLength -= obsLength;
                    bytesLeft -= obsLength;
                }
                XportDataSets.Add(sasdata);
            }
        }

        /// <summary>
        /// Read the actual data records and create an observation object
        /// </summary>
        /// <param name="streamLength">The length of the record</param>
        /// <returns>An observation from a SAS dataset</returns>
        private Observation ReadRecord(long streamLength)
        {
            var rec = new byte[obsLength];
            s.Read(rec, 0, obsLength);
            var obs = new Observation();
            var i = 0;
            foreach (var sv in sasdata.Variables)
            {
                obs.Cells.Add(new Cell() { Column = i, Value = GetObsValue(rec.Subset(sv.Position, sv.Length), sv) });
                i++;
            }
            return obs;
        }

        /// <summary>
        /// Get the value held within the record. For character variables, this is straight-forward.
        /// However, numeric values are very complex. They are stored in IBM mainframe float format
        /// and may be 4-8 bytes in length but may only be partially populated. If they are an 8 byte
        /// double, do a fairly complex conversion and return a .NET double. A single float is padded
        /// up to 4 bytes, then a conversion is done. Big endian is handled prior to the conversions.
        /// Please see the additional links in the notes here for John Hou's original work and Alan Churchill's
        /// variation for C#.
        /// 
        /// This topic is too complex for a simple note. It is best to review the links.
        /// </summary>
        /// <param name="p">Bytes to parse</param>
        /// <param name="sv">The SAS variable that controls the metadata for the value.</param>
        /// <returns>A value for the SAS data cell.</returns>
        /// <seealso>http://www.codeproject.com/Articles/12363/Transform-between-IEEE-IBM-or-VAX-floating-point-n</seealso>
        /// <seealso>http://www.codeproject.com/Articles/492449/Transform-between-IEEE-IBM-or-VAX-floating-point-n</seealso>
        private object GetObsValue(byte[] p, SasVariable sv)
        {
            switch (sv.VariableType)
            {
                case SasVariableType.Numeric:
                    if (p[0] == 46 && BytesAreEmpty(p))
                        return null;
                    if (p.Length == 8)
                    {
                        var x = conv.ConvertBytesToDouble(Platform.IbmFloat, p.Reverse().ToArray());
                        var format = Common.Formats.FirstOrDefault(q => q.Name.StartsWith(sv.FormatName));
                        if (format != null)
                        {
                            if (format.ContentType == ContentType.Date)
                                return Common.ConvertSasToNetDateTime(x, true).ToString(Common.Options.DateFormat);
                            if (format.ContentType == ContentType.DateTime)
                                return Common.ConvertSasToNetDateTime(x, false).ToString(Common.Options.DateTimeFormat);
                        }
                        return x;
                    }
                    else
                    {
                        var bytes = new byte[4];
                        p.CopyTo(bytes,0);
                        var x = conv.ConvertBytesToSingle(Platform.IbmFloat, bytes.Reverse().ToArray());
                        return x;
                    }

                case SasVariableType.Character:
                    return p.GetStringValue();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Check to see if a string of bytes are empty
        /// </summary>
        /// <param name="p">Byte string to check</param>
        /// <returns>Whether the bytes are empty</returns>
        private bool BytesAreEmpty(byte[] p)
        {
            for (var i = 1; i < 7; i++)
            {
                if (p[i] != 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Calculates the length of a SAS observation in the data record
        /// </summary>
        /// <returns>The observation length</returns>
        private int CalculateObsLength()
        {
            var obsLength = 0;
            foreach (var sv in sasdata.Variables)
            {
                obsLength += sv.Length;
            }
            return obsLength;
        }

        /// <summary>
        /// Reads the SAS variable metadaat contained in the header record
        /// </summary>
        /// <param name="i">The variable to read</param>
        /// <returns>A SASVariable object</returns>
        private SasVariable ReadVariableRecord(int i)
        {
            var rec = GetNextVariableRecord();
            var sv = new SasVariable(i);
            sv.VariableType = DetermineType(rec);
            sv.Length = ReverseEndian(rec.Subset(4, 2).GetShortValue());
            sv.Name = rec.Subset(8, 8).GetStringValue();
            sv.Label = rec.Subset(16, 40).GetStringValue();
            sv.FormatName = rec.Subset(56, 8).GetStringValue();
            sv.FormatLengthInteger = ReverseEndian(rec.Subset(64, 2).GetShortValue());
            sv.FormatLengthDecimal = ReverseEndian(rec.Subset(66, 2).GetShortValue());

            sv.InformatName = rec.Subset(72, 8).GetStringValue();
            sv.InformatLengthInteger = ReverseEndian(rec.Subset(80, 2).GetShortValue());
            sv.InformatLengthDecimal = ReverseEndian(rec.Subset(82, 2).GetShortValue());
            sv.Position = ReverseEndian(rec.Subset(84, 4).GetIntValue());
            sv.NetType = DetermineDotNetType(sv.VariableType, sv.FormatName);
            return sv;
        }

        private Type DetermineDotNetType(SasVariableType variableType, string formatName)
        {
            switch (variableType)
            {
                case SasVariableType.Numeric:
                    var format = Common.Formats.FirstOrDefault(q => q.Name.StartsWith(formatName));
                    if (format.ContentType == ContentType.Date || format.ContentType == ContentType.DateTime)
                    {
                        return typeof(DateTime);
                    }
                    return typeof(double);
                case SasVariableType.Character:
                    return typeof(string);
                default:
                    return typeof(double);
            }
        }

        /// <summary>
        /// Reverses the endianness of an array of bytes
        /// </summary>
        /// <param name="p">A short containing 2 bytes</param>
        /// <returns>The reversed array of bytes</returns>
        private int ReverseEndian(short p)
        {
            var x = IPAddress.HostToNetworkOrder(p);
            return x;
        }

        /// <summary>
        /// Reverses the endianness of an array of bytes
        /// </summary>
        /// <param name="p">An int containing 4 bytes</param>
        /// <returns>The reversed array of bytes</returns>
        private int ReverseEndian(int p)
        {
            var x = IPAddress.HostToNetworkOrder(p);
            return x;
        }

        /// <summary>
        /// Reverses the endianness of an array of bytes
        /// </summary>
        /// <param name="p">A short containing 8 bytes</param>
        /// <returns>The reversed array of bytes</returns>
        private double ReverseEndian(double p)
        {
            //var x = IPAddress.HostToNetworkOrder((long)p);
            var x = BitConverter.GetBytes(p);
            var y = x.Reverse().ToArray();
            var z = BitConverter.ToDouble(y, 0);
            return z;
            //return x;
        }

        /// <summary>
        /// Determines whether a SAS variable is character of numeric
        /// </summary>
        /// <param name="bytes">An array of bytes</param>
        /// <returns>The type of SAS variable (num/char)</returns>
        private SasVariableType DetermineType(byte[] bytes)
        {
            var v = SasVariableType.Numeric;
            var value = ReverseEndian(bytes.GetShortValue());
            if (value == 1)
                v = SasVariableType.Numeric;
            else
                v = SasVariableType.Character;
            return v;
        }

        /// <summary>
        /// Parses the header information for the dataset
        /// </summary>
        /// <param name="sasdata">The SAS metadata information</param>
        /// <param name="rec">The record to parse</param>
        private void ParseDataSetHeader(SasXportData sasdata, string rec)
        {
            sasdata.Name = rec.Substring(8, 8).Trim();
            sasdata.SasMemberType = rec.Substring(16, 8).StartsWith("SASDATA") ? SasMemberType.Data : SasMemberType.Unknown;
            sasdata.ReleaseCreated = rec.Substring(24, 8);
            sasdata.HostCreated = rec.Substring(32, 8);
            sasdata.CreationDateTime = DateTime.ParseExact(rec.Substring(40).Trim(), "ddMMMyy:HH:mm:ss",
                                                      CultureInfo.InvariantCulture);
            var rec2 = GetNextRecord();
            sasdata.ModifiedDateTime = DateTime.ParseExact(rec2.Substring(0, 16), "ddMMMyy:HH:mm:ss",
                                                      CultureInfo.InvariantCulture);
            if (rec2.Length >= 40)
                sasdata.Label = rec2.Substring(32, rec2.Length - 32);
            if (rec2.Length >= 48)
                sasdata.DataSetType = rec2.Substring(40, 8);
        }

        /// <summary>
        /// Reads the next record in the stream
        /// </summary>
        /// <returns>The next record</returns>
        private string GetNextRecord()
        {
            var c = new byte[80];
            s.Read(c, 0, c.Length);
            var rec = c.GetStringValue();
            return rec;
        }

        /// <summary>
        /// Reads the next variable record
        /// </summary>
        /// <returns>The byte array that makes up the variable record</returns>
        private byte[] GetNextVariableRecord()
        {
            var c = new byte[140];
            s.Read(c, 0, c.Length);
            return c;
        }

        /// <summary>
        /// Parses the library header record
        /// </summary>
        /// <param name="rec">The record to parse</param>
        private void ParseLibraryHeader(string rec)
        {
            saslib.ReleaseCreated = rec.Substring(24, 8);
            saslib.HostCreated = rec.Substring(32, 8);
            saslib.CreationDateTime = DateTime.ParseExact(rec.Substring(40).Trim(), "ddMMMyy:HH:mm:ss",
                                                      CultureInfo.InvariantCulture);
            var rec2 = GetNextRecord();
            saslib.ModifiedDateTime = DateTime.ParseExact(rec2.Substring(0, 16), "ddMMMyy:HH:mm:ss",
                                                      CultureInfo.InvariantCulture);
        }


        /// <summary>
        /// Creates a dataset
        /// </summary>
        /// <param name="lib">The parsed SAS XPT file</param>
        public DataSet ToDataSet()
        {
            var ds = new DataSet();
            foreach (var xds in this.XportDataSets)
            {
                var dt = new DataTable(xds.Name);
                foreach (var v in xds.Variables)
                {
                    dt.Columns.Add(v.Name, v.NetType);
                }

                foreach (var obs in xds.Observations)
                {
                    var dr = dt.Rows.Add();
                    foreach (var c in obs.Cells)
                    {
                        if (c.Value is not null)
                        {
                            dr[c.Column] = c.Value;
                        }
                    }
                }
                ds.Tables.Add(dt);
            }

            return ds;
        }

    }
}
