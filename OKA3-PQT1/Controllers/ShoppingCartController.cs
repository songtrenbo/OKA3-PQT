using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OKA3_PQT1.Models;

namespace OKA3_PQT1.Controllers
{
    public class ShoppingCartController : Controller
    {
        BanHangDBEntities database = new BanHangDBEntities();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
                return View("EmptyCart");
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCard(int id, int soluong)
        {
            var _pro = database.HANGs.SingleOrDefault(s => s.MaHH == id);
            if (_pro != null)
            {
                GetCart().Add_Product_Cart(_pro,soluong);
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["idPro"]);
            int _quantity = int.Parse(form["cartQuantity"]);
            cart.Update_quantity(id_pro, _quantity);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult Purchase(double total, int mauser)
        {


            Cart cart = Session["Cart"] as Cart;
            var user = database.USERS.Where(s => s.MaUser == mauser).FirstOrDefault();
            if (user.SoTienTK > total)
            {
                //tạo hóa đơn
                HOADON hoadon = new HOADON();
                hoadon.NgayMua = DateTime.Now;
                hoadon.MaUser = mauser;
                database.Configuration.ValidateOnSaveEnabled = false;
                database.HOADONs.Add(hoadon);
                database.SaveChanges();

                //tạo chi tiết hóa đơn, thanh toán
                foreach (var item in cart.Items)
                {
                    CT_HOADON cthd = new CT_HOADON();
                    cthd.SoLuong = item._quantity;
                    cthd.MaHH = item._product.MaHH;
                    cthd.MaHD = hoadon.MaHD;
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.CT_HOADON.Add(cthd);


                    var hang = database.HANGs.Where(s => s.MaHH == item._product.MaHH).FirstOrDefault();
                    hang.SoLuong -= item._quantity;
                    if (hang.SoLuong == 0)
                    {
                        hang.TrangThai = false;
                    }
                    database.Entry(hang).State = System.Data.Entity.EntityState.Modified;
                    database.SaveChanges();

                    user.DiemThuong += item._product.DIEMTHUONG.SoDT * item._quantity;
                }
                user.SoTienTK -= total;
                database.Entry(user).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                cart.ClearCart();
            }
            else
            {
                TempData["msgError"] = "<script>alert('You don't have enough money!');</script>";
                return RedirectToAction("ShowCart", "ShoppingCart");
            }
            return RedirectToAction("SuccessPayment");
        }


        public ActionResult PurchaseWithDiscount(double total, int maphieu)
        {

            var phieuqt = database.PHIEUQUATANGs.Where(s => s.MaCTPhieu == maphieu).FirstOrDefault();
            Cart cart = Session["Cart"] as Cart;
            var user = database.USERS.Where(s => s.MaUser == phieuqt.MaUser).FirstOrDefault();

            total -= phieuqt.CT_PHIEUQUATANG.GiamGia;
            if (phieuqt.SoLuongPhieu > 1)
            {
                phieuqt.SoLuongPhieu = phieuqt.SoLuongPhieu - 1;
                database.Entry(phieuqt).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
            }
            else
            {
                database.PHIEUQUATANGs.Remove(phieuqt);
                database.SaveChanges();
            }

            if (user.SoTienTK > total)
            {
                //tạo hóa đơn
                HOADON hoadon = new HOADON();
                hoadon.NgayMua = DateTime.Now;
                hoadon.MaUser = phieuqt.MaUser;
                database.Configuration.ValidateOnSaveEnabled = false;
                database.HOADONs.Add(hoadon);
                database.SaveChanges();

                //tạo chi tiết hóa đơn, thanh toán
                foreach (var item in cart.Items)
                {
                    CT_HOADON cthd = new CT_HOADON();
                    cthd.SoLuong = item._quantity;
                    cthd.MaHH = item._product.MaHH;
                    cthd.MaHD = hoadon.MaHD;
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.CT_HOADON.Add(cthd);


                    var hang = database.HANGs.Where(s => s.MaHH == item._product.MaHH).FirstOrDefault();
                    hang.SoLuong -= item._quantity;
                    if (hang.SoLuong == 0)
                    {
                        hang.TrangThai = false;
                    }
                    database.Entry(hang).State = System.Data.Entity.EntityState.Modified;
                    database.SaveChanges();

                    user.DiemThuong += item._product.DIEMTHUONG.SoDT*item._quantity;
                }
                user.SoTienTK -= total;
                database.Entry(user).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                cart.ClearCart();
            }
            else
            {
                TempData["msgError"] = "<script>alert('You don't have enough money!');</script>";
                return RedirectToAction("ShowCart", "ShoppingCart");
            }
            return RedirectToAction("SuccessPayment");
        }


        public ActionResult Discount(double total, int mauser)
        {
            Cart cart = Session["Cart"] as Cart;
            var phieuqt = database.PHIEUQUATANGs.Where(s => s.MaUser == mauser && s.CT_PHIEUQUATANG.GiamGia<=total && s.CT_PHIEUQUATANG.NgayHetHan>=DateTime.Now).ToList();
            if (phieuqt != null)
            {
                if (total == 0)
                {
                    TempData["msgError"] = "<script>alert('Nothing to purchase!');</script>";
                    return RedirectToAction("ShowCart", "ShoppingCart");
                }
                if (phieuqt.Count <= 0)
                {
                    return RedirectToAction("Purchase", "ShoppingCart", new { total = total, mauser = mauser });
                }
                foreach (var item in cart.Items)
                {
                    var hang = database.HANGs.Where(s => s.MaHH == item._product.MaHH).FirstOrDefault();
                    if (item._quantity > hang.SoLuong)
                    {
                        TempData["msgError"] = "<script>alert('Invalid amount!');</script>";
                        return RedirectToAction("ShowCart", "ShoppingCart");
                    }
                    else if (item._quantity <= 0)
                    {
                        TempData["msgError"] = "<script>alert('Invalid amount!');</script>";
                        return RedirectToAction("ShowCart", "ShoppingCart");
                    }
                }
                ViewBag.total = total;
                return View(phieuqt);
            }
            else
            {
                return RedirectToAction("Purchase", "ShoppingCart", new { total = total, mauser = mauser });
            }
        }

        public ActionResult SuccessPayment()
        {
            return View();
        }

        public ActionResult ViewPaymentHistory(int mauser)
        {
            var hoadon = database.HOADONs.Where(s => s.MaUser == mauser).ToList();
            ViewBag.CTHoaDon = database.CT_HOADON.ToList();
            return View(hoadon);
        }
        public ActionResult DetailHistory(int mahd)
        {
            var cthd = database.CT_HOADON.Where(s => s.MaHD == mahd).ToList();
            return View(cthd);
        }
    }
}