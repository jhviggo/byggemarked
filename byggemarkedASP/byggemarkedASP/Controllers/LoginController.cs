using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using byggemarked.Model;

namespace byggemarkedASP.Controllers
{
    public class LoginController : Controller
    {
        private HardwareStoreDbContext db = new HardwareStoreDbContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Rentals/Login
        [HttpPost]
        public ActionResult Index([Bind(Include = "Username,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var tempCustomer = db.Customers
                    .FirstOrDefault(c => c.Username == customer.Username && c.Password == customer.Password);

                if (tempCustomer != null)
                {
                    this.Session["userId"] = tempCustomer.Id;
                    Response.Redirect("/Rentals");
                    return View();
                }
            }
            ViewBag.LoginError = "Invalid username or password";
            return View();
        }
    }
}