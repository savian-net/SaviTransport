# Overview

SaviTransport, by Savian, converts a SAS transport file (XPT) to an object. Optionally, it can export to various file formats including tab, csv, json, and xml.

# Usage

By default, SaviTransport will not export a file. If an output file is specified in the options, an output file will be generated. The defaults for an output file, if no type of delimiter is specified, is tab delimited.

Default extensions are:

| Format Type | Extension |
|-----------|---------|
| Tab | txt |
| Delimiter | csv |
| JSON | json |
| XML | xml |



# Sample Code

    using System;
    using System.IO;
    using Savian.SaviTransport;
    using static System.Console;

    namespace Test
    {
        class Program
        {
            private static string _xptFile = @"X:\repos\Utilities\Savian.SaviTransport\sample\shoes.xpt";
            private static string _outDir =  @"z:\scratch\SaviTransportTests";
            private static Engine _engine = new Engine();
            static void Main(string[] args)
            {
                WriteLine("Testing SaviTransport");
                Directory.CreateDirectory(_outDir);
                StandaloneCode();
                CreateTabDelimitedFile();
                CreateDelimitedFile();
                CreateJsonFile();
                CreateXmlFile();
                WriteLine("Press any key to continue...");
                ReadKey();
            }

            private static void StandaloneCode()
            {
                var engine = new Savian.SaviTransport.Engine();
                var options = new Savian.SaviTransport.Options()
                {
                    XptFile = _xptFile
                };
                var xptLib = engine.Process(options);
                foreach (var ds in xptLib.DataSets)
                {
                    WriteLine($"Variables: ");
                    foreach (var v in ds.Variables)
                    {
                        WriteLine($"   - {v.Name}: {v.FormatName}{v.FormatLengthInteger}.{v.FormatLengthDecimal}, ");
                    }
                    WriteLine();
                }
            }


            private static void CreateTabDelimitedFile()
            {
                var options = new Options() { XptFile = _xptFile, OutputFile = Path.Combine(_outDir, "Test.txt") };
                var xportLib = _engine.Process(options);
                WriteLine(($"Tab - Total obs: {xportLib.DataSets[0].Observations.Count}"));
            }

            private static void CreateDelimitedFile()
            {
                var options = new Options() { XptFile = _xptFile, OutputFile = Path.Combine(_outDir, "Test.csv"), TypeOfFile = OutputFormat.CSV, Delimiter = ","};
                var xportLib = _engine.Process(options);
                WriteLine(($"CSV - Total obs: {xportLib.DataSets[0].Observations.Count}"));
            }

            private static void CreateJsonFile()
            {
                var options = new Options() { XptFile = _xptFile, OutputFile = Path.Combine(_outDir, "Test.json"), TypeOfFile = OutputFormat.JSON };
                var xportLib = _engine.Process(options);
                WriteLine(($"JSON - Total obs: {xportLib.DataSets[0].Observations.Count}"));
            }

            private static void CreateXmlFile()
            {
                var options = new Options() { XptFile = _xptFile, OutputFile = Path.Combine(_outDir, "Test.xml"), TypeOfFile = OutputFormat.XML };
                var xportLib = _engine.Process(options);
                WriteLine(($"XML - Total obs: {xportLib.DataSets[0].Observations.Count}"));
            }
        }
    }

# See Also

[Record Layout for a SAS Version 5 or 6 Data Set in SAS Transport Format](https://documentation.sas.com/?docsetId=movefile&docsetTarget=n0167z9rttw8dyn15z1qqe8eiwzf.htm&docsetVersion=9.4&locale=en)
[Record Layout for a SAS Version 8 or 9 Data Set in SAS Transport Format](https://documentation.sas.com/?docsetId=movefile&docsetTarget=p0ld1i106e1xm7n16eefi7qgj8m9.htm&docsetVersion=9.4&locale=en)
[Transform between IEEE, IBM or VAX floating point number formats and bytes expressions](https://www.codeproject.com/Articles/492449/Transform-between-IEEE-IBM-or-VAX-floating-point)
