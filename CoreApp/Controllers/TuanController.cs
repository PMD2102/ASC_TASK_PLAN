using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using CoreApp.Models;
using CoreApp.Service;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class TuanController : Controller
    {
        IDMTuanService _IDmTuanService;

        public TuanController(IDMTuanService IDmTuanService)
        {
            _IDmTuanService = IDmTuanService;
        }

        [HttpPost]
        public JsonResult MoKhoaTuan(int idTuan)
        {
            string message = "Cập nhật thành công";
            _IDmTuanService.MoKhoaTuan(idTuan);
            return Json(new { success = true, message});
        }

        [HttpPost]
        [AcceptVerbs("Post")]
        public ActionResult CapNhatDanhGiaTuan([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] List<eDanhGiaCVTuanModel> models, int idNhanVien)
        {
            List<eDanhGiaCVTuanModel> danhSachDanhGiaTuan = new List<eDanhGiaCVTuanModel>();
            Console.WriteLine("Cap nhat danh gia tuan : "+models.Count);
            foreach(var tuan in models)
            {
                if(tuan.idCongViecTuan!=-1)
                    _IDmTuanService.CapNhatDanhGiaTuan(tuan, idNhanVien);
                else
                {
                    danhSachDanhGiaTuan.Add(tuan);
                }
            }
            //if(danhSachDanhGiaTuan.Count > 0)
            //{
            //    bool IsSuccess = false;
            //    string message = "Tuần không có công việc không thể cập nhật";
            //    return Json(new { success = IsSuccess, message });
            //}
            return Json(models.ToDataSourceResult(request, ModelState));
        }

        public string getFormatDate (string dateFormat) {
            DateTime date = DateTime.ParseExact(dateFormat, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return date.ToString("yyyy/MM/dd");
        }

        public ActionResult PhatSinhTuanTheoThang([DataSourceRequest] DataSourceRequest request,string ngayBatDau, string ngayKetThuc)
        {
            string ngayBD = getFormatDate(ngayBatDau);
            string ngayKT = getFormatDate(ngayKetThuc);
            bool IsSuccess = false;
            string message = "";
            if(ngayBD!=null && ngayKetThuc != null)
            {
                DateTime NBD = new DateTime();
                DateTime NKT = new DateTime();
                try{
                    NBD = Convert.ToDateTime(ngayBD);
                    NKT = Convert.ToDateTime(ngayKT);
                }catch{
                    message = "Vui lòng chọn đúng định dạng ngày tháng năm !!!";
                    return Json(new {success = IsSuccess, message});
                }

                //if(NBD.Month < DateTime.Now.Month && NBD.Year == DateTime.Now.Year)
                //{
                //    message = "Tháng phải lớn hơn hoặc bằng tháng hiện tại !!!";
                //    return Json(new {success = IsSuccess,message});
                //}

                //if(NKT.Month < DateTime.Now.Month && NKT.Year == DateTime.Now.Year)
                //{
                //    message = "Tháng phải lớn hơn hoặc bằng tháng hiện tại !!!";
                //    return Json(new {success = IsSuccess,message});
                //}

                if(NBD.Year != DateTime.Now.Year)
                {
                    message = "Vui lòng chọn năm hiện tại !!!";
                    return Json(new {success = IsSuccess,message});
                }
                
                if(NKT.Year != DateTime.Now.Year)
                {
                    message = "Vui lòng chọn năm hiện tại !!!";
                    return Json(new {success = IsSuccess,message});
                }

                int soSanhNgay = DateTime.Compare(NBD,NKT);
                if(soSanhNgay >=0 )
                {
                    message = "Ngày bắt đầu phải sớm hơn và ngày kết thúc phải trễ hơn ngày bắt đầu";
                    return Json(new {success = IsSuccess,message});
                }
                
                if(NBD.DayOfWeek != DayOfWeek.Monday)
                {
                    message = "Ngày bắt đầu vui lòng là ngày thứ 2 trong tháng";
                    return Json(new {success = IsSuccess,message});
                }

                if(NKT.DayOfWeek != DayOfWeek.Friday && NKT.DayOfWeek != DayOfWeek.Saturday)
                {
                    message = "Ngày kết thúc  vui lòng là ngày thứ 6 hoặc 7 trong tháng hoặc đầu tháng kế tiếp";
                    return Json(new {success = IsSuccess, message});
                }

                if(NBD.Month == NKT.Month)
                {
                    if(NKT.Day - NBD.Day <5)
                    {
                        message = "Số tuần ít nhất là 1 tuần ( 5-6 ngày/tuần )";
                        return Json(new {success = IsSuccess,message});
                    }
                }
            }
            else if(ngayBD == null || ngayKT == null)
            {
                message = "Vui lòng nhập đầy đủ thông tin ngày bắt đầu và kết thúc !!!";
                return Json(new {success = IsSuccess, message});
            }
            else
            {
                message = "Vui lòng nhập đầy đủ thông tin ngày bắt đầu và kết thúc !!!";
                return Json(new {success = IsSuccess, message});
            }

            var ngayBatDau1 = Convert.ToDateTime(ngayBD);
            var ngayKetThuc1 = Convert.ToDateTime(ngayKT);      
            IsSuccess = true;      
            Console.WriteLine("checkkked "+IsSuccess);
            
            List<DmTuan> listTuan = new List<DmTuan>();
            listTuan = _IDmTuanService.PhatSinhTuanTheoThang(ngayBatDau1,ngayKetThuc1);
            return Json(listTuan.ToList().ToDataSourceResult(request));
        } 

        [HttpPost]
        public JsonResult XoaTuan(List<int> listIdDmTuan)
        {
            listIdDmTuan.ForEach(x => Console.WriteLine("x : "+x));
            string message = "";
            bool IsSuccess = true;
            List<string> list = new List<string>();
            list = _IDmTuanService.XoaTuan(listIdDmTuan);
            if(list.Count()==0)
            {
                IsSuccess = true;
                message = "Xoá thành công !";
                return Json(new {success = IsSuccess,message});
            }
            else
            {
                IsSuccess = false;
                message = "Dữ liệu đang có tham chiếu không thể xóa";
                return Json(new {success = IsSuccess,message});
            }
                
        }

        [HttpPost]
        public JsonResult KhoaKeHoachTuan(List<int> listIdDmTuan)
        {
            listIdDmTuan.ForEach(x => Console.WriteLine("x : "+x));
            string message = "";
            bool IsSuccess = true;
            List<string> list = new List<string>();
            _IDmTuanService.KhoaKeHoachTuan(listIdDmTuan);
            message = "Khoá kế hoạch tuần thành công !";
            return Json(new {success = IsSuccess,message});             
        }

        public JsonResult DanhSachTuanTrongThang(int dropdownlistThangTrongNam)
        {
            List<DmTuan> danhSachTuan = new List<DmTuan>();
            danhSachTuan = _IDmTuanService.DanhSachTuanTrongThang(dropdownlistThangTrongNam);
            danhSachTuan.ForEach(tuan =>
            {
                tuan.TenTuan = tuan.TenTuan + " (" + +tuan.TuNgay.Day+"/"+tuan.DenNgay.Month +" - " +tuan.DenNgay.Day+"/"+tuan.DenNgay.Month + ")";
            });
            return Json(danhSachTuan);
        }
    }
}