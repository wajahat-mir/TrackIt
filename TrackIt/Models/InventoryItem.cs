using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackIt.Models
{
    public class InventoryItem
    {
        public long Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, DataType(DataType.Currency)]
        public double Cost { get; set; }
        [Required]
        public Dimension dimensions { get; set; }
        [Required]
        public long Quantity { get; set; }
        [Required]
        public Brand brand { get; set; }
    }
}
