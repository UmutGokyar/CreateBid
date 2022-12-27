using CreateBid.WebUI.Entity;
using CreateBid.WebUI.Models;
using CreateBid.WebUI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateBid.WebUI.Controllers
{
    public class CustomerController : Controller
    {
       
        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult List()
        {
           List<Customer> customers = CustomerRepository.GetAll();
            var customerList = new List<CustomerModel>();
            foreach (var customer in customers)
            {
                var customerModel = new CustomerModel();
                customerModel.Id = customer.Id;
                customerModel.Name = customer.Name;

                customerList.Add(customerModel);

            }

            return View(customerList);


        }


        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View(new CustomerModel());
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BidContext())
                {
                    Customer c = new Customer();
                    c.Name = model.Name;
                    db.Customers.Add(c);
                    db.SaveChanges();
                }
                
                    return RedirectToAction("Index","Home");
            }
            else
            {
                return View(model);
            }
                
            
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
