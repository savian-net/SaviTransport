using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Savian.SaviTransport
{
    public class Options
    {
        [Required, Description("The SAS transport file to translate. Has an extension of xpt")]
        public string XptFile { get; set; }

        [Description("The output file to produce")]
        public string OutputFile { get; set; }

        [Description("The date format (Microsoft standard formatting string)")]
        public string DateFormat { get; set; } = "mm-dd-yyyy";

        [Description("The character to use for missing values")]
        public string MissingValue { get; set; } = ".";

        [Description("The datetime format (Microsoft standard formatting string)")]
        public string DateTimeFormat { get; set; } = "mm-dd-yyyy HH:mm:ss";

        [Description("The delimiter character (Microsoft standard char)")]
        public string Delimiter { get; set; } = "\t";

        [Description("The output format")]
        public OutputFormat TypeOfFile { get; set; } = OutputFormat.TAB;
    }
}
