using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalProject.Models;

namespace VideoRentalProject.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> Customers = new List<Customer>()
            {
                new Customer() {id = 1, Name = "Ali Arif"},
                new Customer() {id = 2, Name = "Irfan Ahmed"}
            };
           
            return View(Customers);
        }
    }
}