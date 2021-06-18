using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OKA3_PQT1.Models;

namespace OKA3_PQT1.Controllers
{
    public class AdminController : Controller
    {
        BanHangDBEntities database = new BanHangDBEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CouponsManagement()
        {
            var listcoupon = database.CT_PHIEUQUATANG.ToList();
            return View(listcoupon);
        }
        public ActionResult Edit(int mactp)
        {
            var phieu = database.CT_PHIEUQUATANG.Where(s => s.MaCTPhieu == mactp).FirstOrDefault();
            return View(phieu);
        }
        [HttpPost]
        public ActionResult Edit(CT_PHIEUQUATANG pqt)
        {
            try
            {
                if (pqt.NgayNhan > pqt.NgayHetHan)
                {
                    TempData["msgError"] = "<script>alert('You don't have enough points!');</script>";
                    return View("Edit", pqt);
                }
                database.Entry(pqt).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("CouponsManagement");
            }
            catch
            {
                return View("Edit", pqt);
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CT_PHIEUQUATANG pqt)
        {
            try
            {
                var check_ID = database.CT_PHIEUQUATANG.Where(s => s.MaCTPhieu == pqt.MaCTPhieu).FirstOrDefault();
                if (pqt.NgayNhan > pqt.NgayHetHan)
                {
                    TempData["msgError"] = "<script>alert('You don't have enough points!');</script>";
                    return View("Create", pqt);
                }
                if (check_ID == null)
                {
                    database.CT_PHIEUQUATANG.Add(pqt);
                    database.SaveChanges();
                    return RedirectToAction("CouponsManagement");
                }
                else
                {
                    return View("Create", pqt);
                }
            }
            catch
            {
                return View("Create", pqt);
            }
        }

        public ActionResult ChangeStatusCoupon(int mactphieu)
        {
            var phieu = database.CT_PHIEUQUATANG.Where(s => s.MaCTPhieu == mactphieu).FirstOrDefault();
            if (phieu.TrangThai == true)
            {
                phieu.TrangThai = false;
            }
            else
            {
                phieu.TrangThai = true;
            }
            database.Entry(phieu).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("CouponsManagement");
        }

        public ActionResult ProductsManagement()
        {
            var listgoods = database.HANGs.ToList();
            return View(listgoods);
        }
        public ActionResult ChangeStatusProduct(int mahh)
        {
            var hang = database.HANGs.Where(s => s.MaHH == mahh).FirstOrDefault();
            if (hang.TrangThai == true)
            {
                hang.TrangThai = false;
            }
            else
            {
                hang.TrangThai = true;
            }
            database.Entry(hang).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("ProductsManagement");
        }
        public ActionResult CreateProduct()
        {
            var types = database.LOAIs.ToList();
            ViewBag.Types = new SelectList(types, "MaLoai", "TenLoai");
            var coupon = database.DIEMTHUONGs.ToList();
            ViewBag.Coupons = new SelectList(coupon, "MaDT", "SoDT");
            var size = database.SIZEs.ToList();
            ViewBag.Sizes = new SelectList(size, "MaSize", "Size1");
            HANG hang = new HANG();
            return View(hang);
        }
        [HttpPost]
        public ActionResult CreateProduct(HANG hang)
        {
            try
            {
                if (hang.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(hang.UploadImage.FileName);
                    string extent = Path.GetExtension(hang.UploadImage.FileName);
                    filename = filename + extent;
                    hang.Hinh = "~/Images/" + filename;
                    hang.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Images/"), filename));

                }
                var check_ID = database.HANGs.Where(s => s.MaHH == hang.MaHH).FirstOrDefault();
                if (check_ID == null)
                {
                    var types = database.LOAIs.ToList();
                    ViewBag.Types = new SelectList(types, "MaLoai", "TenLoai");
                    var coupon = database.DIEMTHUONGs.ToList();
                    ViewBag.Coupons = new SelectList(coupon, "MaDT", "SoDT");
                    var size = database.SIZEs.ToList();
                    ViewBag.Sizes = new SelectList(size, "MaSize", "Size1");
                    database.HANGs.Add(hang);
                    database.SaveChanges();
                    return RedirectToAction("ProductsManagement");
                }
                else
                {
                    return View("CreateProduct", hang);
                }
            }
            catch
            {
                return View("CreateProduct", hang);
            }
        }
        public ActionResult EditProduct(int mahang)
        {
            var types = database.LOAIs.ToList();
            ViewBag.Types = new SelectList(types, "MaLoai", "TenLoai");
            var coupon = database.DIEMTHUONGs.ToList();
            ViewBag.Coupons = new SelectList(coupon, "MaDT", "SoDT");
            var size = database.SIZEs.ToList();
            ViewBag.Sizes = new SelectList(size, "MaSize", "Size1");
            var hang = database.HANGs.Where(s => s.MaHH == mahang).FirstOrDefault();
            return View(hang);
        }
        [HttpPost]
        public ActionResult EditProduct(HANG hang)
        {
            
            try
            {
                if (hang.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(hang.UploadImage.FileName);
                    string extent = Path.GetExtension(hang.UploadImage.FileName);
                    filename = filename + extent;
                    var path = "~/Images/" + filename;
                    if (path != "~/Images/product.png")
                    {
                        hang.Hinh = path;
                        hang.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Images/"), filename));
                    }
                }
                hang.SoLuongMua = 0;
                var types = database.LOAIs.ToList();
                ViewBag.Types = new SelectList(types, "MaLoai", "TenLoai");
                var coupon = database.DIEMTHUONGs.ToList();
                ViewBag.Coupons = new SelectList(coupon, "MaDT", "SoDT");
                var size = database.SIZEs.ToList();
                ViewBag.Sizes = new SelectList(size, "MaSize", "Size1");
                database.Entry(hang).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("ProductsManagement");
            }
            catch
            {
                return View("EditProduct", hang);
            }
        }

        public ActionResult CustomerManagement()
        {
            var khachs = database.USERS.Where(s => s.MaQuyen == "KH").ToList();
            return View(khachs);
        }
        public ActionResult ViewHistory(int mauser)
        {
            var hd = database.HOADONs.Where(s => s.MaUser == mauser).ToList();
            List<CT_HOADON> listcthd = new List<CT_HOADON>();
            foreach (var item in hd)
            {
                var cthd = database.CT_HOADON.Where(s => s.MaHD == item.MaHD).ToList();
                foreach(var i in cthd)
                {
                    listcthd.Add(i);
                }
            }
            return View(listcthd);
        }

        public ActionResult Report(string searching)
        {
            ViewBag.ngay = DateTime.Now;
            var dates = from s in database.HOADONs
                        select s;
            dates = dates.Where(s => s.NgayMua.ToString() == searching);
            var datelist = dates.ToList();

            List<HANG> listhang = new List<HANG>();
            var listallhang = database.HANGs.ToList();
            listhang = listallhang;
            foreach(var item in listhang)
            {
                item.SoLuong = 0;
                //item.Gia = 0;
            }

            int totalsoluong = 0;
            double totalgia = 0;
            
            foreach(var item in datelist)
            {
                var cthd = database.CT_HOADON.Where(s => s.MaHD == item.MaHD).ToList();
                foreach (var i in cthd)
                {
                    var hang = database.HANGs.Where(s => s.MaHH == i.MaHH).FirstOrDefault();
                    foreach(var itemhang in listhang)
                    {
                        if (itemhang.MaHH == hang.MaHH && i.SoLuong>0)
                        {
                            itemhang.SoLuong += i.SoLuong;
                            totalgia += hang.Gia*i.SoLuong;
                            totalsoluong += i.SoLuong;
                            //itemhang.Gia += (hang.Gia * i.SoLuong);
                        }
                    }
                }
                ViewBag.ngay = item.NgayMua;
                ViewBag.totalsoluong = totalsoluong;
                ViewBag.totalgia = totalgia;
            }
            ViewBag.listHang = listhang;
            return View(datelist);
        }
    }
}