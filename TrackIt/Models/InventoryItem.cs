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

        [Required(AllowEmptyStrings = false)]
        public string ItemName { get; set; }

        [Required, DataType(DataType.Currency)]
        public double Cost { get; set; }

        [Required]
        public long Quantity { get; set; }

        [Required]
        public long DimensionId { get; set; }
        [Required]
        public Dimension Dimension { get; set; }

        [Required]
        public long BrandId { get; set; }
        [Required]
        public Brand Brand { get; set; }
    }
}
