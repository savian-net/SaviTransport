using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savian.SaviTransport
{
    /// <summary>
    /// Indicates the type of data contained within the XPT format
    /// </summary>
    public enum SasMemberType
    {
        Data,
        Unknown
    }

    /// <summary>
    /// The SAS variable type. SAS only has 2 variable types: character and numeric but this enum 
    /// could be used to expand that in the future for post-processing
    /// </summary>
    public enum SasVariableType
    {
        Numeric = 1,
        Character = 2,
    }

    /// <summary>
    /// The basic SAS dataset construct
    /// </summary>
    public class SasXportData
    {
        public DateTime CreationDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string HostCreated { get; set; }
        public string ReleaseCreated { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string DataSetType { get; set; }
        public SasMemberType SasMemberType { get; set; }
        public List<SasVariable> Variables { get; set; }
        public List<Observation> Observations { get; set; }

        public SasXportData()
        {
            Variables = new List<SasVariable>();
            Observations = new List<Observation>();
        }
    }
}
