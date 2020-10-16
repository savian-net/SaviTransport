using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savian.SaviTransport
{
    public class Cell
    {
        public int Column { get; set; }
        public object Value { get; set; }
    }

    public class Observation
    {
        public int Row { get; set; }
        public List<Cell> Cells { get; set; }
        internal SasXportData Parent { get; set; }

        public Observation()
        {
            Cells = new List<Cell>();
        }
    }
}
