using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class HomeController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult CustomHome()
        {
            var requisitions = db.Requisitions.Include(r => r.BloodGroup).Include(r => r.District).Include(r => r.Thana);
            return View(requisitions.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}