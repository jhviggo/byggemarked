using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using byggemarked.Model;

namespace byggemarkedASP.Controllers
{
    public class RentalsController : Controller
    {
        private HardwareStoreDbContext db = new HardwareStoreDbContext();

        // GET: Rentals
        public ActionResult Index()
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("/Login");
                return View(new List<Rental>());
            } else
            {
                int userId = (int)Session["userId"];
                var rentals = db.Rentals
                    .Where(r => r.Customer.Id == userId)
                    .OrderByDescending(r => r.StartDate)
                    .Include(r => r.Customer)
                    .Include(r => r.Hardware);

                return View(rentals.ToList());
            }
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || Session["userId"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int userId = (int)Session["userId"];
            Rental rental = db.Rentals.Where(r => r.Customer.Id == userId && r.Id == id).FirstOrDefault();
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            if (Session["userId"] != null)
            {
                int userId = (int)Session["userId"];
                ViewBag.CustomerId = new SelectList(db.Customers.Where(c => c.Id == userId), "Id", "Name");
                ViewBag.HardwareId = new SelectList(db.Hardware, "Id", "Name");
                return View();
            }
            Response.Redirect("/Login");
            return View();
        }

        // POST: Rentals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HardwareId,CustomerId,StartDate,Days")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                rental.Status = "reserveret";
                rental.StartDate = rental.StartDate.AddHours(10);
                db.Rentals.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", rental.CustomerId);
            ViewBag.HardwareId = new SelectList(db.Hardware, "Id", "Name", rental.HardwareId);
            return View(rental);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
