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

        public long DimensionId { get; set; }
        public Dimension Dimension { get; set; }
        
        public long BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
