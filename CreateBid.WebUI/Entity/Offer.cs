using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreateBid.WebUI.Entity
{
    public class Offer
    {
        public int Id { get; set; }

        public DateTime OfferDate { get; set; }

        public string OfferNumber { get; set; }
        
        public string Name { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public double TotalPrice { get; set; }

        public double TaxAmount { get; set; }
            
        public double TaxedTotalAmount { get; set; }
    
        public List<OfferItem> OfferItems { get; set; }
    }
}
