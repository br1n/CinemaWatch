using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using CinemaWatch.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CinemaWatch.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                HttpNotFound();
            }

            return View(customer);
        }

    }
}