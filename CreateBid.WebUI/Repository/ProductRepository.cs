using CreateBid.WebUI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.Repository
{
    public static class ProductRepository
    {
        public static List<Product> GetAll()
        {

            using (var db = new BidContext())
            {
                var products = db.Products.ToList();
                return products;
            }
        }

            public static List<Product> GetOnSale()
            {

                using (var db = new BidContext())
                {
                    var products = db.Products.Where(i => i.OnSale == true).ToList();
                    return products;
                }

            }

            public static Product GetByIdWithOfferItems(int id)
            {
                using (var db = new BidContext())
                {
                    Product product = db.Products.Include(i => i.OfferItems).FirstOrDefault(i => i.Id == id);
                    return product;
                }
                
            }

            public static Product GetById(int id)
            {
                using (var db = new BidContext())
                {
                    Product product = db.Products.FirstOrDefault(i => i.Id == id);
                    return product;
                }
            }

            public static void Update(Product product)
            {
                using (var context = new BidContext())
                {
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                }

            }

        
    }
}

