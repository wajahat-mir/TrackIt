using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackIt.Models
{
    public class Dimension
    {
        public long length { get; set; }
        public long width { get; set; }
        public long depth { get; set; }
        public string units { get; set; }
    }
}
