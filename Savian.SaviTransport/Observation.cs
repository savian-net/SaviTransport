using System.Collections.Generic;

namespace Savian.SaviTransport
{
    public class Cell
    {
        public int Column { get; set; }
        public object Value { get; set; }
    }

    public class Observation
    {
        public Observation()
        {
            Cells = new List<Cell>();
        }

        public int Row { get; set; }
        public List<Cell> Cells { get; set; }
        internal SasXportData Parent { get; set; }
    }
}