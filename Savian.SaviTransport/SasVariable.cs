using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savian.SaviTransport
{
    public class SasVariable
    {
        /// <summary>
        /// The SASVariable constructor
        /// </summary>
        public SasVariable(int id)
        {
            InitializeVariables();
            MiniChunk = new VariableChunkValue();
            Id = id;
        }

        private void InitializeVariables()
        {
            Indexed = false;
            Transcoded = false;
            VariableType = SasVariableType.Numeric;
            Length = 8;
        }

        #region Properties

        internal int MaximumValueSize { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        internal int Position { get; set; }
        public string Label { get; set; }
        public int Length { get; set; }
        public string FormatName { get; set; }
        public int FormatLengthInteger { get; set; }
        public int FormatLengthDecimal { get; set; }
        public string InformatName { get; set; }
        public int InformatLengthInteger { get; set; }
        public int InformatLengthDecimal { get; set; }
        internal bool Indexed { get; set; }
        internal bool Version6Compatible { get; set; }
        internal bool Transcoded { get; set; }
        internal int WriteOrder { get; set; }
        internal int StartByteInObservation { get; set; }
        public SasVariableType VariableType { get; set; }
        public Type NetType { get; set; }
        internal VariableChunkValue MiniChunk { get; set; }

        #endregion

    }

    internal class VariableChunkValue
    {
        #region Properties

        internal int InformatTable { get; set; }
        internal int InformatNameOffset { get; set; }
        internal int InformatNameLength { get; set; }
        internal int FormatTable { get; set; }
        internal int FormatNameOffset { get; set; }
        internal int FormatNameLength { get; set; }
        internal int LabelTable { get; set; }
        internal int LabelOffset { get; set; }
        internal int LabelLength { get; set; }

        #endregion

    }
}
