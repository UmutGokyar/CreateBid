using CreateBid.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public double? Price { get; set; }
  
        [MinLength(10)][MaxLength(50)]
        public string Description { get; set; }

        public bool OnSale { get; set; }

    }
}
