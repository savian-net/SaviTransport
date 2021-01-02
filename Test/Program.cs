using System;
using System.IO;
using Savian.SaviTransport;
using static System.Console;

namespace Test
{
    class Program
    {
        private static string _xptFile = @"X:\repos\Utilities\Savian.SaviTransport\sample\pr2.xpt";
        private static string _outDir =  @"z:\scratch\SaviTransportTests";
        private static SasXportLib _xptLib;
        static void Main(string[] args)
        {
            WriteLine("Testing SaviTransport");
            Directory.CreateDirectory(_outDir);
            _xptLib = new SasXportLib();
            _xptLib.Process(_xptFile);
            if (_xptLib.XportDataSets.Count > 0)
            {
                WriteLine(($"Total obs: {_xptLib.XportDataSets[0].Observations.Count}"));

                CreateDataSet();
                StandaloneCode();

                //Tab-delimited
                _xptLib.ToDelimitedFile(Path.Combine(_outDir, "Test.txt"), @"\t");

                //CSV-delimited
                _xptLib.ToDelimitedFile(Path.Combine(_outDir, "Test.csv"), @",");

                //JSON
                _xptLib.ToJsonFile(Path.Combine(_outDir, "Test.json"));

                //XML
                _xptLib.ToXmlFile(Path.Combine(_outDir, "Test.xml"));
            }
            else
            {
                WriteLine("No datasets found");
            }
            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private static void CreateDataSet()
        {
            var ds = _xptLib.ToDataSet();
        }

        private static void StandaloneCode()
        {
            foreach (var ds in _xptLib.XportDataSets)
            {
                WriteLine($"Variables: ");
                foreach (var v in ds.Variables)
                {
                    WriteLine($"   - {v.Name}: {v.FormatName}{v.FormatLengthInteger}.{v.FormatLengthDecimal}, ");
                }
                WriteLine();
            }
        }
    }
}
