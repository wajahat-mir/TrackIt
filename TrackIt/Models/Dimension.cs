using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrackIt.Models
{
    public class Dimension
    {
        public long Id { get; set; }
        [Required]
        public long length { get; set; }
        [Required]
        public long width { get; set; }
        [Required]
        public long depth { get; set; }
        [Required]
        public string units { get; set; }

        public InventoryItem InventoryItem { get; set; }
    }
}
