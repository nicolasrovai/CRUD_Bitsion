using FicticiaSA.Data;
using FicticiaSA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FicticiaSA.Controllers
{
    public class CustomerController : Controller
    {

        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }
        // GET: CustomerController
        public IActionResult Index()
        {
            IEnumerable<Customer> customersList = _context.Customers;
            return View(customersList);
        }

   
        // GET: CustomerController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
                {
                    _context.Customers.Add(customer);
                    _context.SaveChanges();

                    TempData["CreateSucces"] = "El registro fue agregado con exito";

                    return RedirectToAction("Index");
               }

            return View();
        }

        // GET: CustomerController/Edit/5
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();

                TempData["EditSucces"] = "El registro fue modificado con exito";

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: CustomerController/Delete/5
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);

            if (ModelState.IsValid)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();

                TempData["DeleteSucces"] = "El registro fue eliminado con exito";

                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
