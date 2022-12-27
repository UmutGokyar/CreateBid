using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public double? Price { get; set; }

        public string Description { get; set; }

        public List<OfferItem> OfferItems { get; set; }

        public bool OnSale { get; set; }
    }
}
