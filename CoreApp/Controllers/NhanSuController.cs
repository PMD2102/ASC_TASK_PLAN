using System;
using System.Collections.Generic;
using System.Linq;
using CoreApp.Models;
using CoreApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class NhanSuController : Controller
    {
        public INsNhanSuService _nsNhanSuService;

        public NhanSuController(INsNhanSuService nsNhanSuService)
        {
            _nsNhanSuService = nsNhanSuService;
        }

        public JsonResult GetDanhSachNhanSu()
        {
            List<NsNhanSu> danhSachNhanSu = new List<NsNhanSu>();
            danhSachNhanSu = _nsNhanSuService.DanhSachNhanSu();
            return Json(danhSachNhanSu);
        }

        public List<int> danhSachIdNhanSu(int idThang, int idTuan)
        {
            Console.WriteLine("id thang va id tuan :" + idTuan + " - " + idThang);
            List<int> listIdNhanSu = new List<int>();
            listIdNhanSu = _nsNhanSuService.danhSachIdNhanSu(idThang, idTuan);
            if (listIdNhanSu.Count > 0)
                listIdNhanSu.ForEach(x => Console.WriteLine(" list id nhan su :" + x));
            else
                Console.WriteLine("List null ");
            return listIdNhanSu;
        }

        public string TimTenNhanSu(int idNhanSu)
        {
            string message = "";
            NsNhanSu nsNhanSu = _nsNhanSuService.TimNhanSu(idNhanSu);
            if(nsNhanSu == null)
            {
                Console.WriteLine("Nhan su null ");

            }
            else
            {
                message = nsNhanSu.Ten;
            }
            return message;
        }
    }
}
