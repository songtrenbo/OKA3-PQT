using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OKA3_PQT1.Models;

namespace OKA3_PQT1.Controllers
{
    public class DiscountController : Controller
    {
        BanHangDBEntities database = new BanHangDBEntities();
        // GET: Discount
        public ActionResult Index()
        {
            var discount = database.CT_PHIEUQUATANG.Where(s=>s.NgayHetHan>DateTime.Now).ToList();
            return View(discount);
        }
        public ActionResult Detail(int maphieu)
        {
            var phieu = database.CT_PHIEUQUATANG.Where(s => s.MaCTPhieu == maphieu).FirstOrDefault();           
            return View(phieu);
        }
        [HttpPost]
        public ActionResult Detail(CT_PHIEUQUATANG ctphieu)
        {
            int mauser = int.Parse(Session["MaUser"].ToString());
            var user = database.USERS.Where(s => s.MaUser == mauser).FirstOrDefault();
            var ctphieuqt = database.CT_PHIEUQUATANG.Where(s => s.MaCTPhieu == ctphieu.MaCTPhieu).FirstOrDefault();

            if (ctphieu.SoLuongDoi <= 0 || ctphieu.SoLuongDoi > ctphieuqt.SoLuong)
            {
                TempData["msgError"] = "<script>alert('Invalid quantity!');</script>";
                return RedirectToAction("Detail",new { maphieu = ctphieu.MaCTPhieu});
            }
            if (ctphieu.DiemThuongDoi*ctphieu.SoLuongDoi > user.DiemThuong)
            {
                TempData["msgError"] = "<script>alert('You don't have enough points!');</script>";
                return RedirectToAction("Detail", new { maphieu = ctphieu.MaCTPhieu });
            }

            PHIEUQUATANG phieuqt = new PHIEUQUATANG();
            phieuqt.SoLuongPhieu = ctphieu.SoLuongDoi;
            phieuqt.MaCTPhieu = ctphieu.MaCTPhieu;
            phieuqt.MaUser = mauser;
            database.PHIEUQUATANGs.Add(phieuqt);

            ctphieuqt.SoLuong -= ctphieu.SoLuongDoi;
            database.Entry(ctphieuqt).State = EntityState.Modified;

            user.DiemThuong -= ctphieu.DiemThuongDoi*ctphieu.SoLuongDoi;
            var a = user.MatKhau;
            user.ConfirmPass=a;
            database.Entry(user).State = EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}