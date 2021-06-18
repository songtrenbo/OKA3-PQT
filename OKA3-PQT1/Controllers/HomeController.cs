using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OKA3_PQT1.Models;

namespace OKA3_PQT1.Controllers
{
    public class HomeController : Controller
    {
        BanHangDBEntities database = new BanHangDBEntities();
        public ActionResult Index()
        {
            var hang = database.HANGs.Where(s => s.TrangThai == true).ToList();
            return View(hang);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
    }
}