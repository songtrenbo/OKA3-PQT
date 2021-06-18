using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OKA3_PQT1.Models;

namespace OKA3_PQT1.Controllers
{
    public class ProductController : Controller
    {
        BanHangDBEntities database = new BanHangDBEntities();
        // GET: Product
        public ActionResult Index()
        {
            var product = database.HANGs.ToList();
            return View(product);
        }
        public ActionResult Detail(int MaHH)
        {
            var size = database.SIZEs.ToList();
            ViewBag.ListSize = size;
            ViewBag.Sizes = new SelectList(size, "MaSize", "Size1");
            var hang = database.HANGs.Where(s => s.MaHH == MaHH).FirstOrDefault();
            hang.SoLuongMua = 1;
            return View(hang);
        }
    }
}