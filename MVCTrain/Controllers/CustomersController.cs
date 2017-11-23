using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTrain.Models;

namespace MVCTrain.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Index()
        {
            var customers = getCustomers();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = getCustomers().FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }


        private IEnumerable<Customer> getCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "Jhon Doe", Id = 1},
                new Customer {Name = "Clark Kent", Id = 2}
            };

            return customers;
        }
    }
}