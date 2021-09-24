using System;
using System.Collections.Generic;
using System.Linq;
using CoreApp.Models;
using CoreApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class ThongKeController : Controller
    {
        public IDMTuanService _IDMTuanService;
        public IDMThangService _IDMThangService;
        public INsNhanSuService _INsNhanSuService;
        public ICvCongViecTuanService _ICvCongViecTuanService;
        public ICvCongViecThangService _ICvCongViecThangService;
        public ICvCongViecGiaoService _ICvCongViecGiaoService;
        public IThongKeService _IThongKeService;

        public ThongKeController(IDMThangService IDMThangService, INsNhanSuService INsNhanSu, ICvCongViecTuanService ICvCongViecTuanService, ICvCongViecThangService ICvCongViecThangService, ICvCongViecGiaoService ICvCongViecGiaoService, IThongKeService IThongKeService, IDMTuanService IDMTuanService)
        {
            _IDMThangService = IDMThangService;
            _INsNhanSuService = INsNhanSu;
            _ICvCongViecThangService = ICvCongViecThangService;
            _ICvCongViecTuanService = ICvCongViecTuanService;
            _ICvCongViecGiaoService = ICvCongViecGiaoService;
            _IThongKeService = IThongKeService;
            _IDMTuanService = IDMTuanService;
        }

        public ActionResult Trangchu(int nam, int thang)
        {
            if (thang == 0 && nam == 0)
            {
                int namThucTe = DateTime.Now.Year;
                int thangThucTe = 0;
                              
                DmThang dmThang = new DmThang();
                List<CvCongViecThang> danhSachCongViecThang = new List<CvCongViecThang>();
                List<DmTuan> danhSachTuanTrongThang = new List<DmTuan>();
                List<NsNhanSu> danhSachNhanSu = new List<NsNhanSu>();
                List<eThongKeModel> listThongKe = new List<eThongKeModel>();
                danhSachNhanSu = _INsNhanSuService.DanhSachNhanSu();
                
                var danhSachThangTrongNam = _IDMThangService.DanhSachThangTrongNam(DateTime.Now.Year).ToList() != null ? _IDMThangService.DanhSachThangTrongNam(DateTime.Now.Year).ToList() : new List<DmThang>();
                if (danhSachThangTrongNam.Count > 0)
                {

                    var dsttt = _IDMTuanService.DanhSachTuanTrongThang(danhSachThangTrongNam[0].GiaTri);                       
                    thangThucTe = danhSachThangTrongNam[0].GiaTri;
                    Console.WriteLine("Thang thuc te bieu do: " + thangThucTe);
                    Console.WriteLine("Danh sach tuan :" +danhSachTuanTrongThang.Count);
                    //ViewBag.DanhSachTuan = danhSachTuanTrongThang;
                    //ViewBag.DanhSachThongKe = listThongKe;
                    //ViewBag.SoLuongNhanSu = danhSachNhanSu.Count;
                    //ViewBag.SoTrang = 2;
                    
                }
                else
                {
                    ViewBag.DanhSachTuan = danhSachTuanTrongThang;
                    ViewBag.DanhSachThongKe = listThongKe;
                    ViewBag.SoLuongNhanSu = danhSachNhanSu.Count;
                    //ViewBag.SoTrang = 2;
                    return View();
                }
                danhSachTuanTrongThang = _IDMThangService.DanhSachTuanTrongThang(namThucTe, thangThucTe);          
                dmThang = _IDMThangService.TimThang(namThucTe, thangThucTe);
                danhSachCongViecThang = _ICvCongViecThangService.TimCongViecThang(dmThang.Id);
                //danhSachCongViecTuan = _ICvCongViecTuanService.DanhSachCongViecTuan(danhSachCongViecThang.FirstOrDefault().Id);
                listThongKe = _IThongKeService.DanhSachThongKeTheoThang(danhSachCongViecThang,danhSachTuanTrongThang,danhSachNhanSu, dmThang);
                listThongKe.ForEach(x => Console.WriteLine(x.Print()));
                float soTrang =(float)danhSachNhanSu.Count / 2f;
                ViewBag.SoTrang = Math.Ceiling(soTrang);
                Console.WriteLine("So trang : " + Math.Ceiling(soTrang));
                ViewBag.DanhSachTuan = danhSachTuanTrongThang;
                ViewBag.DanhSachThongKe = listThongKe;
                ViewBag.SoLuongNhanSu = danhSachNhanSu.Count;
                return View();
            }
            else
            {
                int namThucTe = nam;
                int thangThucTe = thang;
                DmThang dmThang = new DmThang();
                List<CvCongViecThang> danhSachCongViecThang = new List<CvCongViecThang>();
                List<CvCongViecTuan> danhSachCongViecTuan = new List<CvCongViecTuan>();
                List<DmTuan> danhSachTuanTrongThang = new List<DmTuan>();
                List<NsNhanSu> danhSachNhanSu = new List<NsNhanSu>();
                danhSachTuanTrongThang = _IDMThangService.DanhSachTuanTrongThang(namThucTe, thangThucTe);
                danhSachNhanSu = _INsNhanSuService.DanhSachNhanSu();
                dmThang = _IDMThangService.TimThang(namThucTe, thangThucTe);
                danhSachCongViecThang = _ICvCongViecThangService.TimCongViecThang(dmThang.Id);
                danhSachCongViecTuan = _ICvCongViecTuanService.DanhSachCongViecTuan(danhSachCongViecThang.FirstOrDefault().Id);
                List<eThongKeModel> listThongKe = _IThongKeService.DanhSachThongKeTheoThang(danhSachCongViecThang, danhSachTuanTrongThang, danhSachNhanSu, dmThang);

                
                ViewBag.DanhSachTuan = danhSachTuanTrongThang;
                ViewBag.DanhSachThongKe = listThongKe;
                ViewBag.SoLuongNhanSu = danhSachNhanSu.Count;
                return View();
    }

}


        public JsonResult ThongKeBieuDo(int nam, int thang)
        {
            int namThucTe = DateTime.Now.Year;
            int thangThucTe = DateTime.Now.Month;
            var danhSachThangTrongNam = _IDMThangService.DanhSachThangTrongNam(DateTime.Now.Year).ToList() == null ? _IDMThangService.DanhSachThangTrongNam(DateTime.Now.Year).ToList() : new List<DmThang>();
            //if(danhSachThangTrongNam.Count > 0)
            //{
            //    danhSachThangTrongNam.OrderByDescending(thang => thang.Id);
            //    namThucTe = DateTime.Now.Year;
            //    thangThucTe = danhSachThangTrongNam[0].GiaTri;
            //    Console.WriteLine("Nam thuc te va thang thuc te ")
            //}
           
            //if (nam != 0 && thang != 0)
            //{
                
            //}
            
            if(nam !=0 && thang !=0)
            {
                namThucTe = nam;
                thangThucTe = thang;
                DmThang dmThang = new DmThang();
                List<CvCongViecThang> danhSachCongViecThang = new List<CvCongViecThang>();
                //List<CvCongViecTuan> danhSachCongViecTuan = new List<CvCongViecTuan>();
                List<DmTuan> danhSachTuanTrongThang = new List<DmTuan>();
                List<NsNhanSu> danhSachNhanSu = new List<NsNhanSu>();
                danhSachTuanTrongThang = _IDMThangService.DanhSachTuanTrongThang(namThucTe, thangThucTe);
                danhSachNhanSu = _INsNhanSuService.DanhSachNhanSu();
                dmThang = _IDMThangService.TimThang(namThucTe, thangThucTe);
                danhSachCongViecThang = _ICvCongViecThangService.TimCongViecThang(dmThang.Id);
                //danhSachCongViecTuan = _ICvCongViecTuanService.DanhSachCongViecTuan(danhSachCongViecThang.FirstOrDefault().Id);
                List<eThongKeModel> listThongKe = _IThongKeService.DanhSachThongKeTheoThang(danhSachCongViecThang, danhSachTuanTrongThang, danhSachNhanSu, dmThang);
                List<eThongKeModel> listThongKeBieuDo = new List<eThongKeModel>();
                for (int i = 0; i < danhSachNhanSu.Count(); i++)
                {
                    int tongGioTrongTuan = 0;
                    int tongSoGioLam = 0;
                    eThongKeModel eThongKeModel = new eThongKeModel();
                    eThongKeModel.tenNhanVien = danhSachNhanSu[i].Ten;
                    List<eThongKeModel> danhSachNhanSuThongKe = new List<eThongKeModel>();
                    danhSachNhanSuThongKe = listThongKe.Where(nhanSu => nhanSu.idNhanVien == danhSachNhanSu[i].Id).ToList();
                    for (int j = 0; j < danhSachNhanSuThongKe.Count(); j++)
                    {
                        tongGioTrongTuan += danhSachNhanSuThongKe[j].gioTrongTuan;
                        tongSoGioLam += danhSachNhanSuThongKe[j].soGioLam;
                    }
                    eThongKeModel.gioTrongTuan = tongGioTrongTuan;
                    eThongKeModel.soGioLam = tongSoGioLam;
                    Decimal hoanThanh = 0m;
                    if (eThongKeModel.gioTrongTuan == 0)
                    {
                        hoanThanh = 0m;
                    }
                    else
                    {
                        hoanThanh = ((decimal)eThongKeModel.soGioLam / (decimal)eThongKeModel.gioTrongTuan) * 100;
                    }
                    Console.WriteLine("Tong so gio : " + tongSoGioLam);
                    Console.WriteLine("Tong so gio  trong tuan: " + tongGioTrongTuan);
                    eThongKeModel.phanTram = hoanThanh;
                    //danhSachNhanSuThongKe.Add(eThongKeModel);
                    listThongKeBieuDo.Add(eThongKeModel);
                }
                listThongKeBieuDo.ForEach(x => Console.WriteLine("Ten : " + x.tenNhanVien + " - Tong so gio lam :" + x.soGioLam + " - % hoan thanh :" + x.phanTram));
                return Json(listThongKeBieuDo);
            }
            else
            {
                var danhSachNhanSu = _INsNhanSuService.DanhSachNhanSu();
                List<eThongKeModel> listThongKeBieuDo = new List<eThongKeModel>();
                danhSachNhanSu.ForEach(x =>
                {
                    eThongKeModel eThongKe = new eThongKeModel();
                    eThongKe.idNhanVien = x.Id;
                    eThongKe.tenNhanVien = x.Ten;
                    eThongKe.gioTrongTuan = 0;
                    eThongKe.phanTram = 0;
                });
                return Json(listThongKeBieuDo);
            }
            //return Json(listThongKeBieuDo.Skip(2 * (idTrang - 1)).Take(2));
            


        }

        public TestObject Test(int nam, int thang)
        {

            int namThucTe = Convert.ToInt32(nam);
            int thangThucTe = Convert.ToInt32(thang);
            DmThang dmThang = new DmThang();
            List<CvCongViecThang> danhSachCongViecThang = new List<CvCongViecThang>();
            List<CvCongViecTuan> danhSachCongViecTuan = new List<CvCongViecTuan>();
            List<DmTuan> danhSachTuanTrongThang = new List<DmTuan>();
            List<NsNhanSu> danhSachNhanSu = new List<NsNhanSu>();
            danhSachTuanTrongThang = _IDMThangService.DanhSachTuanTrongThang(namThucTe, thangThucTe);
            danhSachNhanSu = _INsNhanSuService.DanhSachNhanSu();
            dmThang = _IDMThangService.TimThang(namThucTe, thangThucTe);
            danhSachCongViecThang = _ICvCongViecThangService.TimCongViecThang(dmThang.Id);
            //danhSachCongViecTuan = _ICvCongViecTuanService.DanhSachCongViecTuan(danhSachCongViecThang.FirstOrDefault().Id);
            List<eThongKeModel> listThongKe = _IThongKeService.DanhSachThongKeTheoThang(danhSachCongViecThang, danhSachTuanTrongThang, danhSachNhanSu, dmThang);
            //listThongKe.ForEach(x => Console.WriteLine("Ten : " + x.tenNhanVien + " - Tong so gio lam :" + x.soGioLam + " - % hoan thanh :" + x.phanTram));
            listThongKe.ForEach(x => Console.WriteLine("print test "+x.Print()));
            //listThongKeBieuDo.Skip(2 * (idTrang - 1)).Take(2));
            TestObject testObject = new TestObject
            {
                soLuongNhanSu = danhSachNhanSu.Count()
            };

            danhSachTuanTrongThang.ForEach(x =>
            {
                eDmTuanModel temp = new eDmTuanModel();              
                temp.Id = x.Id;
                temp.SoGioLam = x.SoGioLam;
                temp.SoThuTu = x.SoThuTu;
                temp.TenTuan = x.TenTuan;
                temp.Idthang = x.Idthang;
                temp.TuNgay = x.TuNgay;
                temp.DenNgay = x.DenNgay;

                testObject.danhSachTuan.Add(temp);
            });

            testObject.thongKemOdel = listThongKe;
            testObject.soLuongTuan = danhSachTuanTrongThang.Count;
            return testObject;
        }

        public TestObject PhanTrang(int nam, int thang, int soTrang)
        {

            int namThucTe = Convert.ToInt32(nam);
            int thangThucTe = Convert.ToInt32(thang);
            DmThang dmThang = new DmThang();
            List<CvCongViecThang> danhSachCongViecThang = new List<CvCongViecThang>();
            List<CvCongViecTuan> danhSachCongViecTuan = new List<CvCongViecTuan>();
            List<DmTuan> danhSachTuanTrongThang = new List<DmTuan>();
            List<NsNhanSu> danhSachNhanSu = new List<NsNhanSu>();
            danhSachTuanTrongThang = _IDMThangService.DanhSachTuanTrongThang(namThucTe, thangThucTe);
            danhSachNhanSu = _INsNhanSuService.DanhSachNhanSu().Skip(2 * (soTrang - 1)).Take(2).ToList();
            dmThang = _IDMThangService.TimThang(namThucTe, thangThucTe);
            danhSachCongViecThang = _ICvCongViecThangService.TimCongViecThang(dmThang.Id);
            //danhSachCongViecTuan = _ICvCongViecTuanService.DanhSachCongViecTuan(danhSachCongViecThang.FirstOrDefault().Id);
            List<eThongKeModel> listThongKe = _IThongKeService.DanhSachThongKeTheoThang(danhSachCongViecThang, danhSachTuanTrongThang, danhSachNhanSu, dmThang);
            //listThongKe.ForEach(x => Console.WriteLine("Ten : " + x.tenNhanVien + " - Tong so gio lam :" + x.soGioLam + " - % hoan thanh :" + x.phanTram));
            listThongKe.ForEach(x => Console.WriteLine("print test " + x.Print()));
            //listThongKeBieuDo.Skip(2 * (idTrang - 1)).Take(2));
            TestObject testObject = new TestObject
            {
                soLuongNhanSu = danhSachNhanSu.Count()
            };

            danhSachTuanTrongThang.ForEach(x =>
            {
                eDmTuanModel temp = new eDmTuanModel();
                temp.Id = x.Id;
                temp.SoGioLam = x.SoGioLam;
                temp.SoThuTu = x.SoThuTu;
                temp.TenTuan = x.TenTuan;
                temp.Idthang = x.Idthang;
                temp.TuNgay = x.TuNgay;
                temp.DenNgay = x.DenNgay;

                testObject.danhSachTuan.Add(temp);
            });

            testObject.thongKemOdel = listThongKe;
            testObject.soLuongTuan = danhSachTuanTrongThang.Count;
            return testObject;
        }

        public JsonResult NhanXetTuanToolTip(string id)
        {

            string[] chuoi = id.Split("-");
            int idTuan = Convert.ToInt32(chuoi[1]);
            string nhanXet = _IDMTuanService.NhanXetTuan(idTuan);
            Console.WriteLine(nhanXet);
            return Json(nhanXet);
        }

        //public ActionResult TableThongKe(int nam, int thang)
        //{
        //    int namThucTe = nam;
        //    int thangThucTe = thang;
        //    DmThang dmThang = new DmThang();
        //    List<CvCongViecThang> danhSachCongViecThang = new List<CvCongViecThang>();
        //    List<CvCongViecTuan> danhSachCongViecTuan = new List<CvCongViecTuan>();
        //    List<DmTuan> danhSachTuanTrongThang = new List<DmTuan>();
        //    List<NsNhanSu> danhSachNhanSu = new List<NsNhanSu>();
        //    danhSachTuanTrongThang = _IDMThangService.DanhSachTuanTrongThang(namThucTe, thangThucTe);
        //    danhSachNhanSu = _INsNhanSuService.DanhSachNhanSu();
        //    dmThang = _IDMThangService.TimThang(namThucTe, thangThucTe);
        //    danhSachCongViecThang = _ICvCongViecThangService.TimCongViecThang(dmThang.Id);
        //    danhSachCongViecTuan = _ICvCongViecTuanService.DanhSachCongViecTuan(danhSachCongViecThang.FirstOrDefault().Id);
        //    List<eThongKeModel> listThongKe = _IThongKeService.DanhSachThongKeTheoThang(danhSachCongViecThang, danhSachTuanTrongThang, danhSachNhanSu, dmThang);
        //    danhSachTuanTrongThang.ForEach(x => Console.WriteLine(x.Id));
        //    ViewBag.DanhSachTuan = danhSachTuanTrongThang;
        //    ViewBag.DanhSachThongKe = listThongKe;
        //    ViewBag.SoLuongNhanSu = danhSachNhanSu.Count;
        //    return PartialView();
        //}

        public JsonResult DanhSachNamThongKe()
        {
            List<Nam> danhSachNam = new List<Nam>();
            danhSachNam = _IThongKeService.DanhSachNamThongKe();
            return Json(danhSachNam.ToList());
        }
    }
}
