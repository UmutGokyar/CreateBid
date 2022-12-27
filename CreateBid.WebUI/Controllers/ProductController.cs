using CreateBid.WebUI.Entity;
using CreateBid.WebUI.Models;
using CreateBid.WebUI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: HomeController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult List()
        {
            List<Product> products = ProductRepository.GetAll();
            var productList = new List<ProductModel>();
            foreach (var product in products)
            {
                var productModel = new ProductModel();
                productModel.Id = product.Id;
                productModel.Name = product.Name;
                productModel.Price = product.Price;
                productModel.Description = product.Description;
                productModel.OnSale = product.OnSale;
                productList.Add(productModel);
            }

            return View(productList);


        }

        
        public ActionResult Create()
        {

            return View(new ProductModel());
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BidContext())
                {
                    Product p = new Product();
                    p.Name = model.Name;
                    p.Price = model.Price;
                    p.Description = model.Description;
                    p.OnSale = true;
                    db.Products.Add(p);
                    db.SaveChanges();
                }
                return RedirectToAction("List", "Product");
            }
            else
            {
                return View(model);
            }

        }

      
        public IActionResult Delete(int id) {
            if (ModelState.IsValid)
            {
                using (var db = new BidContext())
                {
                    Product product=db.Products.Include(i => i.OfferItems).FirstOrDefault(i => i.Id == id);
                 
                  var hasRecord=product.OfferItems.Any();

                  if (!hasRecord) {
                     var cmd = @"delete from Products where Id=@p0";
                     db.Database.ExecuteSqlRaw(cmd, id);
                    }
                    else
                    {
                        if (product.OnSale) {
                            product.OnSale = false;
                            db.SaveChanges();
                        }
                    }
                       
                }
                return RedirectToAction("List", "Product");
            }
            else
            {
                //buraya bak!!!
                return RedirectToAction("Create","Offer");
            }


        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            Product editProduct = ProductRepository.GetById(id);
            ProductModel productModel = new ProductModel() {
                Id = editProduct.Id,
                Name = editProduct.Name,
                Price = editProduct.Price,
                Description = editProduct.Description,
                OnSale = editProduct.OnSale
            };
            return View(productModel);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid) {
                    Product product = ProductRepository.GetById(model.Id);
                    if (product != null) {
                        product.Name = model.Name;
                        product.Price = model.Price;
                        product.Description = model.Description;
                        product.OnSale = model.OnSale;
                        ProductRepository.Update(product);
                        return RedirectToAction("List", "Product");
                        
                    }      
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

      
     

        // POST: HomeController1/Delete/5
        [HttpPost]
    
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}


