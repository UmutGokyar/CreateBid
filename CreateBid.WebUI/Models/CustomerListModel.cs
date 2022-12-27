using CreateBid.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.Models
{
    public class CustomerListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<OfferModel> Offers { get; set; }
    }
}

public class OfferModel {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Total { get; set; }

    public List<OfferItemModelC> OfferItems { get; set; }

}

public class OfferItemModelC{


    public int Id { get; set; }

    public int ProductId { get; set; }
    public ProductModelC Product { get; set; }

    public int Quantity { get; set; }
    public int Discount { get; set; }

    public double Total { get; set; }

}
public class ProductModelC
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public double? Price { get; set; }

    public string Description { get; set; }

}
