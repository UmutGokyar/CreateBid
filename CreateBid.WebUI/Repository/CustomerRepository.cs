using CreateBid.WebUI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.Repository
{
    public static class CustomerRepository
    {
        public static List<Customer> GetAll()
        {

            using (var context = new BidContext())
            {
                var customers = context.Customers
                    .Include(i=>i.Offers)
                    .ThenInclude(i=>i.OfferItems)
                    .ThenInclude(i=>i.Product)
                    .ToList();


                return customers;
            }

        }
    }
}
