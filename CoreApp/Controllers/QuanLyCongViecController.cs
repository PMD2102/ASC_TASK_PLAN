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
    public class QuanLyCongViecController : Controller
    {
        private ICvCongViecThangService _ICvCongViecThangService;
        private ICvCongViecTuanService _ICvCongViecTuanService;
        private ICvCongViecGiaoService _ICvCongViecGiaoService;
        private IDMThangService _IDMThangService;
        private IDMTuanService _IDMTuanService;

        public QuanLyCongViecController(ICvCongViecThangService ICvCongViecThangService, ICvCongViecTuanService ICvCongViecTuanService, ICvCongViecGiaoService ICvCongViecGiaoService, IDMThangService IDMThangService, IDMTuanService IDMTuanService)
        {
            _ICvCongViecThangService = ICvCongViecThangService;
            _ICvCongViecTuanService = ICvCongViecTuanService;
            _ICvCongViecGiaoService = ICvCongViecGiaoService;
            _IDMThangService = IDMThangService;
            _IDMTuanService = IDMTuanService;
        }

        [HttpPost]
        public ActionResult DoiCongViecTuan(int idCVGiao, int idTuan)
        {
            bool IsSuccess = true;
            string message = "";
            return Json(new { success = IsSuccess, message });
        }

        [HttpPost]
        public JsonResult XoaCongViec(List<int> listIdGiaoViec, int idTuan)
        {
            bool IsSuccess = true;
            string message = "";
            message = _ICvCongViecGiaoService.XoaCongViecGiao(listIdGiaoViec, idTuan);
            if (message.Equals(""))
            {
                //IsSuccess = false;
                message = "Xoá thành công";
                return Json(new { success = IsSuccess, message });
            }
            else
            {
                IsSuccess = false;
                return Json(new { success = IsSuccess, message });
            }

        }

        public ActionResult TrangChu()
        {
            return View();
        }

        //public ActionResult TimKiem([DataSourceRequest] DataSourceRequest request, string tenCongViecIndex, int dropdownlistThangTrongNamIndex, int dropdownlistTuanIndex, int dropdownlistModuleIndex, int dropdownlistNhanSuIndex, int dropdownlistLamViecIndex)
        //{
        //    bool IsSuccess = true;
        //    string message = "";
        //    Console.WriteLine(dropdownlistThangTrongNamIndex + " - " + dropdownlistTuanIndex + " - " + dropdownlistModuleIndex + " - " + dropdownlistNhanSuIndex + " - " + dropdownlistLamViecIndex + "tenCongViecIndex :" + tenCongViecIndex);
        //    List<eQuanLyCongViecModel> eQuanLyCongViecModels = new List<eQuanLyCongViecModel>();
        //    eQuanLyCongViecModels = _ICvCongViecGiaoService.DanhSachTimKiem(tenCongViecIndex, dropdownlistThangTrongNamIndex, dropdownlistTuanIndex, dropdownlistModuleIndex, dropdownlistNhanSuIndex, dropdownlistLamViecIndex);
        //    eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" data : " + x.Dev + " - " + x.idModule +" - "+x.tuNgay));
        //    if (eQuanLyCongViecModels.Count == 0)
        //    {
        //        IsSuccess = false;
        //        message = "Not Found";
        //        return Json(new { success = IsSuccess, message });
        //    }

        //    return Json(eQuanLyCongViecModels.ToDataSourceResult(request));
        //}

        public ActionResult TimKiem([DataSourceRequest] DataSourceRequest request, string tenCongViecIndex, int dropdownlistThangTrongNamIndex, int dropdownlistTuanIndex, int dropdownlistModuleIndex, int dropdownlistNhanSuIndex, int dropdownlistLamViecIndex)
        {
            bool IsSuccess = true;
            string message = "";
            int tuan = dropdownlistTuanIndex;
            int thang = dropdownlistThangTrongNamIndex;
            Console.WriteLine("Tuan : " + tuan + " - " + thang);
            if (tuan == 0 && thang == 0)
            {
                var danhSachThangTrongNam = _IDMThangService.DanhSachThangTrongNam(DateTime.Now.Year).ToList() != null ? _IDMThangService.DanhSachThangTrongNam(DateTime.Now.Year).ToList() : new List<DmThang>();
                if (danhSachThangTrongNam.Count > 0)
                {

                    var dsttt = _IDMTuanService.DanhSachTuanTrongThang(danhSachThangTrongNam[0].GiaTri);
                    //int namThucTe = DateTime.Now.Year;
                    int thangThucTe = danhSachThangTrongNam[0].Id;              
                    var dsttn1 = _IDMTuanService.DanhSachTuanTrongThang(thangThucTe);
                    int tuanThucTe = dsttn1[0].Id;
                    Console.WriteLine("Tuan dau tien trong thang " + dsttn1[0].TenTuan + " - " + dsttn1[0].Id);
                    Console.WriteLine("Thang thuc te : " + thangThucTe);
                    thang = thangThucTe;
                    tuan = tuanThucTe;
                }
                
                //tuan = 1;
                //thang = 2;
                
            }
            if(tuan ==0 && thang ==0)
            {
                List<eQuanLyCongViecModel> eQuanLyCongViecModels1 = new List<eQuanLyCongViecModel>();
                return Json(eQuanLyCongViecModels1.ToDataSourceResult(request));
            }
            Console.WriteLine(dropdownlistThangTrongNamIndex + " - " + dropdownlistTuanIndex + " - " + dropdownlistModuleIndex + " - " + dropdownlistNhanSuIndex + " - " + dropdownlistLamViecIndex + "tenCongViecIndex :" + tenCongViecIndex);
            List<eQuanLyCongViecModel> eQuanLyCongViecModels = new List<eQuanLyCongViecModel>();
            eQuanLyCongViecModels = _ICvCongViecGiaoService.DanhSachTimKiem(tenCongViecIndex, thang, tuan, dropdownlistModuleIndex, dropdownlistNhanSuIndex, dropdownlistLamViecIndex);
            eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" data : " + x.Dev + " - " + x.idModule + " - " + x.tuNgay));
            if (eQuanLyCongViecModels.Count == 0)
            {
                //IsSuccess = false;
                //message = "Not Found";
                //return Json(new { success = IsSuccess, message });
                List<eQuanLyCongViecModel> eQuanLyCongViecModels2 = new List<eQuanLyCongViecModel>();
                return Json(eQuanLyCongViecModels2.ToDataSourceResult(request));
            }

            return Json(eQuanLyCongViecModels.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult DuyetTuan(List<string> chkArray, int idThang, int idTuan)
        {
            bool IsSuccess = true;
            string message = "";

            string listError = _ICvCongViecTuanService.DuyetTuan(chkArray, idThang, idTuan);
            if (listError.Equals(""))
            {

                message = "Duyệt tuần thành công";
                return Json(new { success = IsSuccess, message });
            }
            else
            {
                IsSuccess = false;
                return Json(new { success = IsSuccess, listError });
            }


        }

        //[HttpPost]
        //public ActionResult DoiCongViecTuan(eQuanLyCongViecModel listGiaoViec)
        //{
        //    bool IsSuccess = true;
        //    string message = "";
        //    DateTime ngayGiao = Convert.ToDateTime(tuNgay);
        //    DateTime denNgayNop = Convert.ToDateTime(denNgay);
        //    bool checkTen = true;
        //    checkTen = _ICvCongViecGiaoService.KiemTraTenCongViec(tenCongViec.Trim().ToString());
        //    if (checkTen == true)
        //    {
        //        CvCongViecTuan cv = new CvCongViecTuan();
        //        cv = _ICvCongViecTuanService.KiemTraCongViecTuan(dropdownlistTuan, dropdownlistNhanSu);
        //        if (cv.Id == -1)
        //        {
        //            int idCVThang = _ICvCongViecThangService.ThemCongViecThang(dropdownlistThangTrongNam, dropdownlistNhanSu);
        //            int idCVTuan = _ICvCongViecTuanService.ThemCongViecTuan(idCVThang, dropdownlistTuan);
        //            bool saveCVGiao = _ICvCongViecGiaoService.ThemCongViecGiao(idCVTuan, dropdownlistModule, tenCongViec, thoiGianLam, ngayGiao, denNgayNop);
        //        }
        //        else
        //        {
        //            bool saveCVGiao = _ICvCongViecGiaoService.ThemCongViecGiao(cv.Id, dropdownlistModule, tenCongViec, thoiGianLam, ngayGiao, denNgayNop);
        //        }

        //        IsSuccess = true;//saveCVGiao;
        //        if (IsSuccess == true)
        //            message = "Thêm thành công";
        //        else
        //            message = "Thêm thất bại";
        //        return Json(new { success = IsSuccess, message });
        //    }
        //    else
        //    {
        //        IsSuccess = false;
        //        message = "Trùng tên công việc. Thêm không thành công";
        //        return Json(new { success = IsSuccess, message });
        //    }

        //}


        [HttpPost]
        public ActionResult ThemCongViecGiao(int dropdownlistNhanSu, int dropdownlistThangTrongNam, int dropdownlistTuan, string urlIssusse, string tenIssusse, int dropdownlistModule, string tenCongViec, int thoiGianLam, int dropdownlistLamViec, string tuNgay, string denNgay, string ghiChu)
        {
            bool IsSuccess = true;
            string message = "";
            if (thoiGianLam <= 0 || thoiGianLam >= 10)
            {
                IsSuccess = false;
                message = "Thời gian làm phải >=1 và <=9";
                return Json(new { success = IsSuccess, message });
            }

            if (tuNgay == null || denNgay == null)
            {
                IsSuccess = false;
                message = "Vui lòng nhập đầy đủ từ ngày, đến ngày. Và trong tuần đang chọn";
                return Json(new { success = IsSuccess, message });
            }
            DateTime ngayGiao = Convert.ToDateTime(tuNgay);
            DateTime denNgayNop = Convert.ToDateTime(denNgay);
            bool checkTen = true;
            
            var dmTuan = _IDMTuanService.GetTuan(dropdownlistTuan);
            if(dmTuan !=null)
            {
                if(ngayGiao.Month != dmTuan.TuNgay.Month || ngayGiao.Day < dmTuan.TuNgay.Day)
                {
                    IsSuccess = false;
                    message = "Ngày bắt đầu phải trong khoảng tuần đã chọn";
                    return Json(new { success = IsSuccess, message });
                }

                //if(denNgayNop.Month )

            }

            checkTen = _ICvCongViecGiaoService.KiemTraTenCongViec(tenCongViec.Trim().ToString());
            if (checkTen == true)
            {
                CvCongViecTuan cv = new CvCongViecTuan();
                cv = _ICvCongViecTuanService.KiemTraCongViecTuan(dropdownlistTuan, dropdownlistNhanSu);
                if (cv.Id == -1)
                {
                    int idCVThang = _ICvCongViecThangService.ThemCongViecThang(dropdownlistThangTrongNam, dropdownlistNhanSu);
                    int idCVTuan = _ICvCongViecTuanService.ThemCongViecTuan(idCVThang, dropdownlistTuan);
                    bool saveCVGiao = _ICvCongViecGiaoService.ThemCongViecGiao(idCVTuan, dropdownlistModule, tenCongViec, thoiGianLam, ngayGiao, denNgayNop, urlIssusse, tenIssusse);
                }
                else
                {
                    bool saveCVGiao = _ICvCongViecGiaoService.ThemCongViecGiao(cv.Id, dropdownlistModule, tenCongViec, thoiGianLam, ngayGiao, denNgayNop, urlIssusse,tenIssusse);
                }

                IsSuccess = true;//saveCVGiao;
                if (IsSuccess == true)
                    message = "Thêm thành công";
                else
                    message = "Thêm thất bại";
                return Json(new { success = IsSuccess, message });
            }
            else
            {
                IsSuccess = false;
                message = "Trùng tên công việc. Thêm không thành công";
                return Json(new { success = IsSuccess, message });
            }

        }

        [HttpPost]
        public ActionResult CapNhatCongViecGiao(int dropdownlistNhanSuCapNhat, int dropdownlistThangTrongNamCapNhat, int dropdownlistTuanCapNhat, string urlIssusseCapNhat, string tenIssusseCapNhat, int dropdownlistModuleCapNhat, string tenCongViecCapNhat, int thoiGianLamCapNhat, int dropdownlistLamViecCapNhat, string tuNgayCapNhat, string denNgayCapNhat, string ghiChuCapNhat, int idGiaoViecCapNhat)
        {
            Console.WriteLine("idGiaoViecCapNhat : " + idGiaoViecCapNhat);
            bool IsSuccess = true;
            string message = "";
            DateTime ngayGiao = Convert.ToDateTime(tuNgayCapNhat);
            DateTime denNgayNop = Convert.ToDateTime(denNgayCapNhat);
            //bool checkTen = true;
            //checkTen = _ICvCongViecGiaoService.KiemTraTenCongViec(tenCongViecCapNhat.Trim().ToString());
            //if(checkTen == true)
            //{
            string tenCV = tenCongViecCapNhat.Trim().ToString();
            if(thoiGianLamCapNhat <0 || thoiGianLamCapNhat >10)
            {
                IsSuccess = false;
                message = "Thời gian phải > 0 và < 10";
                return Json(new { success = IsSuccess, message });
            }

            message = "Cập nhật thành công";
            _ICvCongViecGiaoService.UpdateMotCongViec( dropdownlistNhanSuCapNhat,  dropdownlistThangTrongNamCapNhat,  dropdownlistTuanCapNhat,  urlIssusseCapNhat,  tenIssusseCapNhat,  dropdownlistModuleCapNhat,  tenCV,  thoiGianLamCapNhat,  dropdownlistLamViecCapNhat, ngayGiao, denNgayNop,  ghiChuCapNhat, idGiaoViecCapNhat);
            return Json(new { success = IsSuccess, message });
            //}
            //else
            //{
            //    IsSuccess = false;
            //    message = "Trùng tên công việc. Cập nhật không thành công";
            //    return Json(new { success = IsSuccess, message });
            //}
            
        }

        public List<string> DanhSachTenCongViec()
        {
            List<string> danhSachTenCongViec = new List<string>();
            danhSachTenCongViec = _ICvCongViecGiaoService.DanhSachTenCongviec();
            return danhSachTenCongViec;
        }

        public ActionResult EditingCustom_Read([DataSourceRequest] DataSourceRequest request, int idTuan)
        {
            //_ICvCongViecGiaoService.DanhSachQuanLyTheoThangVaTuan(2,1);
            //PopulateCategories();
            //Console.WriteLine("IdTuan = "+idTuan);
            //using (var context = new ASC_TASK_PLANNINGContext())
            //{
            //var con = context.DmModules.Select(module => new eDmModuleModel
            //{
            //    Id = module.Id,
            //    TenModule = module.TenModule
            //}).OrderBy(e => e.TenModule).ToList();
            //ViewBag.modules = con;
            //ViewData["dmModules"] = con.ToList();
            //ViewData["defaultModule"] = con.First();
            //}
            return Json(_ICvCongViecGiaoService.DanhSachQuanLyTheoThangVaTuan(2, idTuan).ToDataSourceResult(request));
            //return Json(.ToDataSourceResult(request));
        }

        [HttpPost]
        [AcceptVerbs("Post")]
        public ActionResult EditingCongViec_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] List<eQuanLyCongViecModel> models)
        {
            Console.WriteLine("model count " + models.Count);

            //if (ModelState.IsValid)
            //{
                Console.WriteLine("da vo day ");
                foreach (eQuanLyCongViecModel eQuanLy in models)
                {
                    Console.WriteLine("model count update" + eQuanLy.idGiaoViec);
                    _ICvCongViecGiaoService.Update(eQuanLy);
                }
            //}
            return Json(models.ToDataSourceResult(request, ModelState));
        }

        public IEnumerable<eQuanLyCongViecModel> Read()
        {
            return GetAll();
        }

        public ActionResult DanhGiaCongViecThang([DataSourceRequest] DataSourceRequest request, int idNhanSu, int idThang, int idTuan)
        {
            Console.WriteLine("Id nhan su va thang " + idNhanSu + " - " + idThang+ " - "+idTuan);

            if (idNhanSu == 0 || idThang == 0 || idTuan == 0)
            {
                List<eDanhGiaCVThangModel> danhGiaThang = new List<eDanhGiaCVThangModel>();
                return Json(danhGiaThang.ToDataSourceResult(request));
            }
            else
            {
                List<eDanhGiaCVThangModel> danhGiaThang = new List<eDanhGiaCVThangModel>();
                danhGiaThang = _ICvCongViecGiaoService.DanhGiaCongViecThang(idThang, idNhanSu, idTuan);
                
                return Json(danhGiaThang.ToDataSourceResult(request));
            }


        }

        [HttpPost]
        public ActionResult DanhGiaCongViecTuan([DataSourceRequest] DataSourceRequest request, int idNhanSu, int idThang)
        {
            Console.WriteLine("danh gia cong viec tuan  " + idNhanSu + " - " + idThang);

            if (idNhanSu == 0 || idThang == 0)
            {
                List<eDanhGiaCVTuanModel> danhGiaTuan = new List<eDanhGiaCVTuanModel>();
                return Json(danhGiaTuan.ToDataSourceResult(request));
            }
            else
            {
                List<eDanhGiaCVTuanModel> danhGiaTuan = new List<eDanhGiaCVTuanModel>();
                danhGiaTuan = _ICvCongViecGiaoService.DanhGiaCongViecTuan(idThang, idNhanSu);

                return Json(danhGiaTuan.ToDataSourceResult(request));
            }


        }


        public IList<KhoiLuongModel> GetAllKhoiLuong()
        {
            List<KhoiLuongModel> listKhoiLuong = new List<KhoiLuongModel>();
            listKhoiLuong.Add(new KhoiLuongModel(-1, ""));
            listKhoiLuong.Add(new KhoiLuongModel(0,"Bình thường"));
            listKhoiLuong.Add(new KhoiLuongModel(1, "Nhiều"));
            listKhoiLuong.Add(new KhoiLuongModel(2, "Thấp"));
            return listKhoiLuong;
        }

        public IList<TienDoModel> GetAllTienDo()
        {
            List<TienDoModel> listTienDo = new List<TienDoModel>();
            listTienDo.Add(new TienDoModel(0, "Kịp tiến độ"));
            listTienDo.Add(new TienDoModel(1, "Sớm hơn KH"));
            listTienDo.Add(new TienDoModel(2, "Trễ tiến độ"));
            return listTienDo;
        }

        public IList<ChatLuongTuanModel> GetAllChatLuongTuan()
        {
            List<ChatLuongTuanModel> listChatLuong = new List<ChatLuongTuanModel>();
            listChatLuong.Add(new ChatLuongTuanModel(0, "<= 2 lỗi nội bộ triển khai test"));
            listChatLuong.Add(new ChatLuongTuanModel(1, "3 -> 4 lỗi nội bộ triển khai test"));
            listChatLuong.Add(new ChatLuongTuanModel(2, "> 4 lỗi nội bộ hoặc <= 2 lỗi khách báo cáo"));
            listChatLuong.Add(new ChatLuongTuanModel(3, "Lỗi nghiêm trọng phía khách hàng"));
            return listChatLuong;
        }

        public IList<ChatLuongThangModel> GetAllChatLuongThang()
        {
            List<ChatLuongThangModel> listChatLuong = new List<ChatLuongThangModel>();
            listChatLuong.Add(new ChatLuongThangModel(0, "Tốt, hầu như không lỗi"));
            listChatLuong.Add(new ChatLuongThangModel(1, "Khá, vài lỗi nhỏ"));
            listChatLuong.Add(new ChatLuongThangModel(2, "Trung , có vài lỗi lớn"));
            listChatLuong.Add(new ChatLuongThangModel(3, "Yếu, nhiều lỗi"));
            return listChatLuong;
        }

        //public ActionResult DanhGiaCongViecTuan([DataSourceRequest] DataSourceRequest request, int idNhanSu, int idThang)
        //{

        //}

        public IList<eQuanLyCongViecModel> GetAll()
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var dmModules = context.DmModules.ToList();
                var result = context.CvGiaoViecs.ToList().Select(giaoviec =>
                {
                    var dmModule = dmModules.First(m => giaoviec.Idmodule == m.Id);
                    return new eQuanLyCongViecModel
                    {
                        idNhanVien = giaoviec.Id,
                        tenNhanVien = "nghia",
                        eDmModuleModel = new eDmModuleModel()
                        {
                            Id = dmModule.Id,
                            TenModule = dmModule.TenModule
                        }
                    };
                    //return new eQuanLyCongViecModel
                    //{
                    //    idNhanVien = giaoviec.Id,
                    //    tenNhanVien = "nghia",
                    //    IdModule = dmModule.Id,
                    //    TenModule = dmModule.TenModule
                    //};
                }).ToList();


                return result;
            }
            
        }

        public IList<eDmModuleModel> GetAllModule()
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var dmModules = context.DmModules.ToList();
                List<eDmModuleModel> list = new List<eDmModuleModel>();
                dmModules.ForEach(x =>
                {
                    eDmModuleModel module = new eDmModuleModel();
                    module.Id = x.Id;
                    module.TenModule = x.TenModule;
                    list.Add(module);
                });
                return list;
            }

        }

        public IList<TrangThaiCongViecModel> GetAllTrangThai()
        {
            List<TrangThaiCongViecModel> listTrangThai = new List<TrangThaiCongViecModel>();
            listTrangThai.Add(new TrangThaiCongViecModel(0, "Đã xong"));
            listTrangThai.Add(new TrangThaiCongViecModel(1, "Chưa làm"));
            listTrangThai.Add(new TrangThaiCongViecModel(2, "Task đột xuất đã xong"));
            listTrangThai.Add(new TrangThaiCongViecModel(3, "Chưa xong"));
            listTrangThai.Add(new TrangThaiCongViecModel(4, "Chưa xong bận task khác chưa duyệt"));
            listTrangThai.Add(new TrangThaiCongViecModel(5, "Chưa xong bận task khác đã duyệt"));
            listTrangThai.Add(new TrangThaiCongViecModel(6, "Vắng"));
            return listTrangThai;
        }

        public IList<NguonGocModel> GetAllNguocGoc()
        {
            List<NguonGocModel> listNguoiGoc = new List<NguonGocModel>();
            listNguoiGoc.Add(new NguonGocModel(0, "Tạo mới"));
            listNguoiGoc.Add(new NguonGocModel(1, "Dời do trễ lần 2"));
            listNguoiGoc.Add(new NguonGocModel(2, "Dời do trễ lần 3"));
            return listNguoiGoc;
        }

        public void PopulateCategories()
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                var con = context.DmModules.Select(module => new eDmModuleModel
                {
                    Id = module.Id,
                    TenModule = module.TenModule
                }).OrderBy(e => e.TenModule).ToList();

                ViewData["dmModules"] = con.ToList();
                ViewData["defaultModule"] = con.First();
            }

            
        }

        

    }
}
