using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public List<Offer> Offers { get; set; }

    }
}
