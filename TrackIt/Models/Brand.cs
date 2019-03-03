using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackIt.Models
{
    public class Brand
    {
        public long BrandId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContactPhone { get; set; }
        [Required]
        public Address CompanyAddress { get; set; }
    }
}
