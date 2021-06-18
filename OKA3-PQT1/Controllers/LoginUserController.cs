using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OKA3_PQT1.Models;

namespace OKA3_PQT1.Controllers
{
    public class LoginUserController : Controller
    {
        BanHangDBEntities database = new BanHangDBEntities();
        // GET: LoginUser
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAccount(USER _user)
        {
            var check = database.USERS.Where(s => s.TaiKhoan == _user.TaiKhoan && s.MatKhau == _user.MatKhau).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "SaiInfo";
                return View("Index");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["Username"] = _user.TaiKhoan;
                Session["Password"] = _user.MatKhau;
                Session["TenUser"] = check.TenUser;
                Session["Quyen"] = check.MaQuyen;
                Session["MaUser"] = check.MaUser;
                ViewBag.maUser = check.MaUser;
                ViewBag.username = check.TaiKhoan;
                if (check.MaQuyen == "KH")
                {
                    return RedirectToAction("Index", "Home", new { mauser = check.MaUser });
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(USER _user)
        {
            if (ModelState.IsValid)
            {
                var check_ID = database.USERS.Where(s => s.TaiKhoan == _user.TaiKhoan).FirstOrDefault();
                if (check_ID == null)
                {
                    _user.SoTienTK = 0;
                    _user.DiemThuong = 0;
                    _user.MaQuyen = "KH";
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.USERS.Add(_user);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID is exixst";
                    return View();
                }
            }
            return View();
        }
        public ActionResult LogOutUser()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LoginUser");
        }
        public ActionResult Profile(int mauser)
        {
            var user = database.USERS.Where(s => s.MaUser == mauser).FirstOrDefault();
            return View(user);
        }
        public ActionResult Recharge(int mauser)
        {
            var user = database.USERS.Where(s => s.MaUser == mauser).FirstOrDefault();
            ViewBag.pass = user.MatKhau;
            return View(user);
        }
        [HttpPost]
        public ActionResult Recharge(USER u)
        {         
            try
            {
                u.ConfirmPass = u.MatKhau;
                u.SoTienTK = u.SoTienTK + u.Recharge;
                database.Entry(u).State = EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("Profile", new { mauser = u.MaUser });
            }
            catch
            {
                return View("Recharge");
            }
        }
        public ActionResult ViewCoupons(int mauser)
        {
            var phieuqt = database.PHIEUQUATANGs.Where(s => s.MaUser == mauser).ToList();
            return View(phieuqt);
        }
    }
}