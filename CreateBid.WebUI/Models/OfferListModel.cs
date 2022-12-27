using CreateBid.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.Models
{
    public class OfferListModel
    {
        public int OfferId { get; set; }
        public string Name { get; set; }
        public string OfferDate { get; set; }

        public string OfferNumber { get; set; }

        public string CustomerName { get; set; }
        public int CustomerId { get; set; }

        public List<OfferItemModel> OfferItems { get; set; }

        public double TotalPrice { get; set; }

        public double TaxedTotalAmount() {

            return (TotalPrice * 0.18 + TotalPrice);
        }


    }


    public class OfferItemModel
    {
        public int OfferItemId { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public double Total { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }

    }

}