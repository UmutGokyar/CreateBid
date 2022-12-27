using CreateBid.WebUI.Entity;
using CreateBid.WebUI.Models;
using CreateBid.WebUI.Repository;
using CreateBid.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace CreateBid.WebUI.Controllers
{
    public class OfferController : Controller
    {
        readonly IGeneratePdf _generatePdf;
        public OfferController(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public IActionResult Create()
        {

            ViewBag.Products = new SelectList(ProductRepository.GetOnSale(), "Id", "Name");
            ViewBag.Customers = new SelectList(CustomerRepository.GetAll(), "Id", "Name");

            var offers = OfferRepository.List();

            int count = offers.Count();
            int lastRecordId;
            string offerNumber;
            string firstOfferNumber;
            string yearMounth = DateTime.Now.ToString("yyyyMM");
            if (count != 0)
            {
                lastRecordId = offers.Skip(count - 1).FirstOrDefault().Id;
                offerNumber = yearMounth + "0" + (lastRecordId + 1).ToString();
                firstOfferNumber = null;
            }
            else
            {
                firstOfferNumber = yearMounth + "01";
                offerNumber = null;
            }

            return View(new OfferViewModel() { OfferNumber = count == 0 ? firstOfferNumber : offerNumber });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OfferViewModel model, int[] productId, int[] quantity, int[] discount, double[] price)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BidContext())
                {
                    Offer offer = new Offer();
                    offer.OfferNumber = model.OfferNumber;
                    offer.OfferDate = DateTime.Now;
                    offer.Name = model.Name;
                    offer.CustomerId = model.CustomerId;
                    db.Offers.Add(offer);
                    db.SaveChanges();
                    var offerItemList = new List<OfferItem>();
                    for (int i = 0; i < productId.Length; i++)
                    {
                        OfferItem offerItem = new OfferItem();
                        offerItem.OfferId = offer.Id;
                        offerItem.ProductId = productId[i];
                        offerItem.Quantity = quantity[i];
                        offerItem.Discount = discount[i];
                        offerItem.Price = price[i];
                        offerItem.Total = ((double)((offerItem.Quantity * offerItem.Price) - (offerItem.Quantity * offerItem.Price) * ((double)offerItem.Discount / 100)));
                        offerItemList.Add(offerItem);
                        db.OfferItems.Add(offerItem);
                    }

                    offer.TotalPrice = offerItemList.Sum(i => i.Total);
                    offer.TaxAmount = offer.TotalPrice * 0.18;
                    offer.TaxedTotalAmount = (offer.TotalPrice * 0.18) + offer.TotalPrice;
                    offer.OfferItems = offerItemList;
                    db.SaveChanges();
                }

                return RedirectToAction("List", "Offer");
            }
            else { return View(model); }
        }

        public IActionResult List()
        {
            List<Offer> offers = OfferRepository.List();
            var offerListModel = new List<OfferListModel>();
            OfferListModel offerModel;
            
            foreach (var offer in offers)
            {
                offerModel = new OfferListModel();
                offerModel.OfferId = offer.Id;
                offerModel.Name = offer.Name;
                offerModel.CustomerName = offer.Customer.Name;
                offerModel.CustomerId = offer.CustomerId;
                offerModel.TotalPrice = 0;
                foreach (var item in offer.OfferItems)
                {
                    offerModel.TotalPrice += item.Total;
                }


                offerModel.OfferDate = offer.OfferDate.ToString("dd.MM.yyyy");
                offerModel.OfferNumber = offer.OfferNumber;
                offerListModel.Add(offerModel);
            }
            return View(offerListModel);
        }

        public IActionResult Detail(int id)
        {
            if (id != null)
            {
                using (var db = new BidContext())
                {
                    var offer = db.Offers.Include(i => i.OfferItems).ThenInclude(i => i.Product).Include(i => i.Customer).FirstOrDefault(i => i.Id == id);
                    var offerDetail = new OfferDetailViewModel();
                    var offerItemList = new List<OfferItemDM>();

                    offerDetail.OfferId = offer.Id;
                    offerDetail.OfferName = offer.Name;
                    offerDetail.CustomerName = offer.Customer.Name;
                    offerDetail.OfferNumber = offer.OfferNumber;
                    offerDetail.OfferDate = offer.OfferDate;

                    foreach (var item in offer.OfferItems)
                    {
                        var offerItem = new OfferItemDM();
                        offerItem.Total = item.Total;
                        offerItem.ProductName = item.Product.Name;
                        offerItem.Price = item.Price;
                        offerItem.Description = item.Product.Description;
                        offerItem.Quantity = item.Quantity;
                        offerItem.Discount = item.Discount;
                        offerItemList.Add(offerItem);
                    }
                    offerDetail.OfferItems = offerItemList;
                    return View(offerDetail);
                }

            }
            return RedirectToAction("List", "Offer");
        }


        public IActionResult Edit(int id)
        {
            if (id != null)
            {
                ViewBag.Products = new SelectList(ProductRepository.GetOnSale(), "Id", "Name");
                ViewBag.Customers = new SelectList(CustomerRepository.GetAll(), "Id", "Name");
                using (var db = new BidContext())
                {
                    var offer = db.Offers.Include(i => i.OfferItems).ThenInclude(i => i.Product).Include(i => i.Customer).FirstOrDefault(i => i.Id == id);
                    var offerDetail = new OfferEditViewModel();
                    var offerItemList = new List<OfferItemEditDM>();

                    offerDetail.OfferId = offer.Id;
                    offerDetail.OfferName = offer.Name;
                    offerDetail.CustomerId = offer.CustomerId;
                    offerDetail.OfferNumber = offer.OfferNumber;
                    offerDetail.OfferDate = offer.OfferDate;
                    offerDetail.CustomerId = offer.CustomerId;


                    foreach (var item in offer.OfferItems)
                    {
                        var offerItem = new OfferItemEditDM();
                        offerItem.Total = item.Total;
                        offerItem.ProductName = item.Product.Name;
                        offerItem.Price = item.Product.Price;
                        offerItem.Description = item.Product.Description;
                        offerItem.Quantity = item.Quantity;
                        offerItem.Discount = item.Discount;
                        offerItem.ProductId = item.ProductId;
                        offerItemList.Add(offerItem);
                    }
                    offerDetail.OfferItems = offerItemList;
                    return View(offerDetail);
                }
            }
            return Redirect("/offer/detail/" + id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OfferEditViewModel model, int[] productId, int[] quantity, int[] discount, double[] price) {
            if (ModelState.IsValid) 
            {
                var db = new BidContext();
                var offer = OfferRepository.GetById(model.OfferId);
                db.Database.ExecuteSqlRaw(@"delete from OfferItems where OfferId=@p0",model.OfferId);
                offer.TotalPrice = 0;
                offer.TaxAmount = 0;
                offer.TaxedTotalAmount = 0;
                offer.Name = model.OfferName;
                offer.CustomerId = model.CustomerId;
                db.SaveChanges();
                var offerItemList = new List<OfferItem>();
                for (int i = 0; i < productId.Length; i++)
                {
                    OfferItem offerItem = new OfferItem();
                    offerItem.OfferId = offer.Id;
                    offerItem.ProductId = productId[i];
                    offerItem.Quantity = quantity[i];
                    offerItem.Discount = discount[i];
                    offerItem.Price = price[i];
                    offerItem.Total = ((double)((offerItem.Quantity * offerItem.Price) - (offerItem.Quantity * offerItem.Price) * ((double)offerItem.Discount / 100)));
                    offerItemList.Add(offerItem);
                    db.OfferItems.Add(offerItem);
                }
                offer.OfferItems = offerItemList;
                //db.SaveChanges();
                offer.TotalPrice = offer.OfferItems.Sum(i => i.Total);
                //offer.TotalPrice = offerItemList.Sum(i => i.Total);
                offer.TaxAmount = offer.TotalPrice * 0.18;
                offer.TaxedTotalAmount = offer.TotalPrice + offer.TaxAmount;
                
                db.SaveChanges();


                return RedirectToAction("List", "Offer");
            }
            else
            {
                return View(model);
            }


         
        }
    






        public IActionResult Delete(int id)
        {
            using (var db = new BidContext())
            {
                
                db.Database.ExecuteSqlRaw(@"delete from OfferItems where OfferId=@p0", id);

                var cmd = @"delete from Offers where Id=@p0";
                db.Database.ExecuteSqlRaw(cmd, id);
            }
            return RedirectToAction("List", "Offer");
        }


        public async Task<IActionResult> GeneratePdf(int id)
        {
            var db = new BidContext();
            var offer = db.Offers.Include(i => i.OfferItems).ThenInclude(i => i.Product).Include(i => i.Customer).FirstOrDefault(i => i.Id == id);
            var offerDetail = new OfferDetailViewModel();
            var offerItemList = new List<OfferItemDM>();

            offerDetail.OfferId = offer.Id;
            offerDetail.OfferName = offer.Name;
            offerDetail.CustomerName = offer.Customer.Name;
            offerDetail.OfferNumber = offer.OfferNumber;
            offerDetail.OfferDate = offer.OfferDate;

            foreach (var item in offer.OfferItems)
            {
                var offerItem = new OfferItemDM();
                offerItem.Total = item.Total;
                offerItem.ProductName = item.Product.Name;
                offerItem.Price = item.Product.Price;
                offerItem.Description = item.Product.Description;
                offerItem.Quantity = item.Quantity;
                offerItem.Discount = item.Discount;
                offerItemList.Add(offerItem);
            }
            offerDetail.OfferItems = offerItemList;
            return await _generatePdf.GetPdf<OfferDetailViewModel>("Views/Offer/GeneratePdf.cshtml", offerDetail);
        }

        [HttpPost]
        public double? GetPrice(int id)
        {
            using (var db = new BidContext())
            {

                var price = db.Products.FirstOrDefault(i => i.Id == id).Price;
                return price;
            }
        }


    }
}










