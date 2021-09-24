using System;
using System.Collections.Generic;
using System.Linq;
using CoreApp.Models;
using CoreApp.Service;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class ThangController : Controller
    {
        public IDMThangService _IDMThangService;
        public IDMTuanService _IDMTuanService;

        public ThangController(IDMThangService serviceThang,IDMTuanService IDMTuanService)
        {
            _IDMThangService = serviceThang;
            _IDMTuanService = IDMTuanService;
        }

        public ActionResult GetAllThang()
        {
            return Json(_IDMThangService.GetDMThangs().ToList());
        }

        [HttpPost]
        [AcceptVerbs("Post")]
        public ActionResult CapNhatDanhGiaThang([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] List<eDanhGiaCVThangModel> models, int idNhanVien)
        {
            Console.WriteLine("Da vo Cap nhat danh gia thang :" + models.Count + " - "+idNhanVien) ;
            foreach(var thang in models)
            {
                _IDMThangService.UpdateCongViecThang(thang, idNhanVien);
            }
            return Json(models.ToDataSourceResult(request,ModelState));
        }

        [HttpPost]
        public JsonResult ThemThang([DataSourceRequest] DataSourceRequest request, string ngayBatDau, string ngayKetThuc)
        {
            string message = "";
            bool IsSuccess = false;
            DateTime ngayBatDau1 = Convert.ToDateTime(ngayBatDau);
            DateTime ngayKetThuc1 = Convert.ToDateTime(ngayKetThuc);
            List<DmTuan> listDmTuan = new List<DmTuan>();
            listDmTuan = _IDMTuanService.PhatSinhTuanTheoThang(ngayBatDau1,ngayKetThuc1);
            //cap nhat bool check demo 1
            bool check = _IDMThangService.checkCVT(ngayBatDau1, ngayKetThuc1, listDmTuan);
            if(check==false)
            {
                IsSuccess = false;
                message = "Đang có tham chiếu không cập nhật được";
                Console.WriteLine(" da vo day message " + message);
                return Json(new { success = IsSuccess, message });
            }
            bool capNhat = _IDMThangService.CapNhatThangTuan(ngayBatDau1, ngayKetThuc1, listDmTuan);
            
            bool ketQua = _IDMThangService.ThemThang(ngayBatDau1,ngayKetThuc1,listDmTuan);
            if(ketQua && !capNhat)
            {
                IsSuccess = ketQua;
                message = "Thêm Thành Công";    
            }
            else if(!ketQua && !capNhat)
                message = "Đã tồn tại tháng hiện tại xin vui lòng kiểm tra lại";
            else if(capNhat && !ketQua)
            {
                IsSuccess = capNhat;
                message = "Cập nhật thành công !";
            }                
            else
                message = "Cập nhật không thành công !";
            
            return Json(new {success = IsSuccess,message});
            
        }

        [HttpPost]
        public JsonResult XoaThang(List<int> listIdDmThang)
        {
            string message = "";
            bool IsSuccess = true;
            List<string> listIdError = _IDMThangService.XoaThang(listIdDmThang);
            if(listIdError.Count()==0)
            {
                IsSuccess = true;
                message = "Xoá thành công !";
                return Json(new {success = IsSuccess,message});
            }
            else
            {
                IsSuccess = false;
                return Json(new {success = IsSuccess,listIdError});
            }
        }

        public JsonResult DanhSachThangTrongNam(int? dropdownlistNam)
        {

            List<DmThang> danhSachThang = new List<DmThang>();
            if (dropdownlistNam != null)
            {
                Console.WriteLine("Da vo day khi x != 0"+ dropdownlistNam);
                danhSachThang = _IDMThangService.DanhSachThangTrongNam(Convert.ToInt32(dropdownlistNam));
                danhSachThang.ForEach(x => Console.WriteLine("ssss " + x.TenThang));
                    
            }           
            return Json(danhSachThang.ToList());


        }
    }
}