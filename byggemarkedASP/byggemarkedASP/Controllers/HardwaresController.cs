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
    public class HardwaresController : Controller
    {
        private HardwareStoreDbContext db = new HardwareStoreDbContext();

        // GET: Hardwares
        public ActionResult Index()
        {
            return View(db.Hardware.ToList());
        }

        // GET: Hardwares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hardware hardware = db.Hardware.Find(id);
            if (hardware == null)
            {
                return HttpNotFound();
            }
            return View(hardware);
        }

        // GET: Hardwares/Create
        public ActionResult Create()
        {
            return View();
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
