using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.Entity
{
    public class OfferItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int? OfferId { get; set; }
        public Offer Offer { get; set; }
        public double Price { get; set; }

        public int Quantity { get; set; }
        public int Discount { get; set; }

        public double Total { get; set; }

    }
}
