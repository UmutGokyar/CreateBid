using CreateBid.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.ViewModels
{
    public class OfferDetailViewModel
    {
        public int OfferId { get; set; }
        public string OfferName { get; set; }

        public string OfferNumber { get; set; }
        public DateTime OfferDate { get; set; }
        public string CustomerName { get; set; }
        public double Price { get; set; }

        public string Description { get; set; }
        public List<OfferItemDM> OfferItems { get; set; }

        public double TotalAmount() {

            return OfferItems.Sum(i => i.Total);
        }

        public double TaxAmount()
        {
            return OfferItems.Sum(i => i.Total * 0.18);
        }

        public double TaxedTotalAmount()
        {
            return OfferItems.Sum(i => i.Total + (i.Total * 0.18));
        }
    }


    public class OfferItemDM
    {
        public double Total { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public string ProductName { get; set; }
        public double? Price { get; set; }

        public string Description { get; set; }
        

    }

   
}



