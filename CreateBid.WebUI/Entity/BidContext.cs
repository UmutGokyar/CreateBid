using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.Entity
{
    public class BidContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OfferItem> OfferItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BidDb;Trusted_Connection=True;");


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().Property(a => a.Name).HasMaxLength(500);
        }
    }
}
