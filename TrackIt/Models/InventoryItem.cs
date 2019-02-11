using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackIt.Models
{
    public class InventoryItem
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public Dimension dimensions { get; set; }
        public long Quantity { get; set; }
        public Brand brand { get; set; }
    }
}
