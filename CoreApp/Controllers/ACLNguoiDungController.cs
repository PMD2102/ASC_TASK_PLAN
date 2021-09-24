using System.Linq;
using System;
using CoreApp.Service;
using Microsoft.AspNetCore.Mvc;
using CoreApp.Models;
using System.Collections.Generic;

namespace CoreApp.Controllers
{
    public class ACLNguoiDungController : Controller
    {
        IACL_NguoiDungService _IACLNguoiDung;
        public ACLNguoiDungController(IACL_NguoiDungService IAClNguoiDung)
        {
            _IACLNguoiDung = IAClNguoiDung;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckUserACLNguoiDung()
        {
            string username = Request.Form["username"].ToString();
            string password = Request.Form["password"].ToString();
            Console.WriteLine("User name " + username);
            Console.WriteLine("Password " + password);
            bool ketQua = _IACLNguoiDung.CheckACLNguoiDung(username, password);
            if (ketQua)
            {
                TempData["username"] = username;
                return Redirect("/ACLNguoiDung/TrangChu");
            }
            else
            {
                string message = "Sai ten dang nhap hoac mat khau !!!";
                TempData["message"] = message;
                return Redirect("/ACLNguoiDung/Login");
            }
        }

        public ActionResult TrangChu()
        {
            string username = " ";
            if (TempData.ContainsKey("username"))
                username = TempData["username"].ToString();
            var aclNguoiDung = _IACLNguoiDung.GetAclNguoiDung(username);
            var nhanSu = _IACLNguoiDung.GetNhanSu(aclNguoiDung.IdnhanSu.ToString());
            TempData["TenNhanSu"] = nhanSu.Ten;
            return View();
        }

    }
}