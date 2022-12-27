using CreateBid.WebUI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.ViewModels
{
    public class OfferViewModel
    {
        public string Name { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public string OfferNumber { get; set; }
        public DateTime OfferDate { get; set; }
        public List<OfferItem> OfferItems { get; set; }

        [Required(ErrorMessage = "Product selection cannot be empty!")]
        public int ProductId {get;set;}

        public Product Product { get; set; }
        [Range(0, 1000)]
        public int Quantity { get; set; }
        [Range(0, 100)]
        public int Discount { get; set; }
        [Range(0, Double.PositiveInfinity)]
        public decimal Price { get; set; }
        [Range(0, Double.PositiveInfinity)]
        public double Total { get; set; }

        public double TaxAmount()
        {
            return Total*0.18;
        }

        public double TaxedTotalAmount()
        {
            return Total + (Total * 0.18);
        }


        //public double TotalPrice() {
        //return  ((double)((Quantity * Product.Price) - (Quantity * Product.Price) * (Discount / 100))); } 

    }

    }

