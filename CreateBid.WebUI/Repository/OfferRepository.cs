using CreateBid.WebUI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.Repository
{
    public static class OfferRepository
    {
        public static List<Offer> List()
        {

            using (var context = new BidContext())
            {

                var offers = context.Offers
                                    .Include(i=>i.Customer)
                                    .Include(i => i.OfferItems)
                                    .ThenInclude(i => i.Product)
                                    .ToList();
                return offers;
            }

        }

        public static Offer GetById(int id)
        {

            using (var context = new BidContext())
            {

                var offer = context.Offers 
                                    .Include(i=>i.Customer)
                                    .Include(i => i.OfferItems)
                                    .ThenInclude(i => i.Product)
                                    .FirstOrDefault(i => i.Id == id);
                return offer;
            }

        }


    }
}
