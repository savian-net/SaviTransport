using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;

namespace Savian.SaviTransport
{
    /// <summary>
    /// Main entry point for SaviTransport
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Processes a SAS transport file and converts it to a return object
        /// </summary>
        /// <param name="options">The options to use for processing a SAS transport format file</param>
        /// <returns>A SasXportLib object containing all of the information, and data, for a SAS transport file</returns>
        public SasXportLib Process(Options options)
        {
            if (string.IsNullOrEmpty(options.XptFile))
            {
                throw new Exception("XptFile is not set in options.");
            }
            Common.Initialize(options);
            var fi = new FileInfo(Common.Options.XptFile);
            var lib = new SasXportLib();
            lib.Process(fi);
            if (!string.IsNullOrEmpty(options.OutputFile))
            {
                CreateOutputFile(lib);
            }

            return lib;
        }

        /// <summary>
        /// Determines the type of output file
        /// </summary>
        /// <param name="lib">The parsed SAS XPT file</param>
        private static void CreateOutputFile(SasXportLib lib)
        {
            switch (Common.Options.TypeOfFile)
            {
                case OutputFormat.CSV:
                    CreateDelimitedFile(lib);
                    break;
                case OutputFormat.XML:
                    CreateXmlFile(lib);
                    break;
                case OutputFormat.JSON:
                    CreateJsonFile(lib);
                    break;
                default:
                    CreateDelimitedFile(lib);
                    break;
            }
        }


        /// <summary>
        /// Creates a JSON file
        /// </summary>
        /// <param name="lib">The parsed SAS XPT file</param>
        private static void CreateJsonFile(SasXportLib lib)
        {

            var jsonLib = JsonSerializer.Serialize(lib, new JsonSerializerOptions(){WriteIndented = true});
            File.WriteAllText(Common.Options.OutputFile, jsonLib);
        }


        /// <summary>
        /// Creates an XML file
        /// </summary>
        /// <param name="lib">The parsed SAS XPT file</param>
        private static void CreateXmlFile(SasXportLib lib)
        {
            var xd = new XDocument();
            var xeRoot = new XElement("SasData");

            for (var i = 0; i < lib.DataSets[0].Observations.Count; i++)
            {
                var xeObs = new XElement("Observation");
                var obs = lib.DataSets[0].Observations[i];
                foreach (var cell in obs.Cells)
                {
                    var sv = lib.DataSets[0].Variables[cell.Column];
                    var xeValue = new XElement(sv.Name);
                    xeValue.Value = cell.Value.ToString();
                    xeObs.Add(xeValue);
                }
                xeRoot.Add(xeObs);
            }
            xd.Add(xeRoot);
            xd.Save(Common.Options.OutputFile);
        }

        /// <summary>
        /// Creates a delimited file
        /// </summary>
        /// <param name="lib">The parsed SAS XPT file</param>
        private static void CreateDelimitedFile(SasXportLib lib)
        {
            var sw = new StreamWriter(Common.Options.OutputFile);
            var data = lib.DataSets[0];
            foreach (var sv in data.Variables)
            {
                sw.Write(sv.Name + Common.Options.Delimiter);
            }
            sw.WriteLine();

            foreach (var obs in data.Observations)
            {
                foreach (var cell in obs.Cells)
                {
                    if (cell.Value != null)
                        sw.Write(cell.Value.ToString() + Common.Options.Delimiter);
                    else
                        sw.Write(Common.Options.MissingValue + Common.Options.Delimiter);
                }
                sw.WriteLine();
            }

            sw.Close();
        }
    }
}
