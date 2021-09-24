using System;
using System.Collections.Generic;
using System.Linq;
using CoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Service
{
    public class CvViecGiaoSerivce : ICvCongViecGiaoService
    {
        private static bool UpdateDatabase = false;

        public IDmModuleService _IDmModuleSerivce;

        public CvViecGiaoSerivce(IDmModuleService IDmModuleSerivce)
        {
            _IDmModuleSerivce = IDmModuleSerivce;
        }

        //public List<eDanhGiaCVThangModel> DanhGiaCongViecThang(int idThang, int idNhanSu, int idTuan)
        //{
        //    using(var context = new ASC_TASK_PLANNINGContext())
        //    {
        //        var danhSachNhanSu = context.NsNhanSus.Where(ns => ns.Id == idNhanSu).ToList();            
        //        var danhSachCongViecThang = context.CvCongViecThangs.Where(cvthang => cvthang.Idthang == idThang).ToList();
        //        var danhSachCongViecTuan = context.CvCongViecTuans.Where(cvTuan => cvTuan.Idtuan == idTuan).ToList();
        //        string tenThang = context.DmThangs.Where(thang => thang.Id == idThang).Select(thang => thang.TenThang).FirstOrDefault();
        //        List <eDanhGiaCVThangModel> listDanhGiaThang = new List<eDanhGiaCVThangModel>();
        //        var query = (from ns in danhSachNhanSu
        //                     join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
        //                     join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
        //                     where ns.Id == idNhanSu && cvthang.Idthang == idThang && cvt.Idtuan == idTuan
        //                     select new eDanhGiaCVThangModel
        //                     {
        //                         idThang = idThang,
        //                         tenThang = tenThang,
        //                         KhoiLuongModel = cvthang.EnumKhoiLuong == 0 ? new KhoiLuongModel(cvthang.EnumKhoiLuong,"Bình tường") : cvthang.EnumKhoiLuong == 1 ? new KhoiLuongModel(cvthang.EnumKhoiLuong,"Nhiều") : new KhoiLuongModel(cvthang.EnumKhoiLuong, "Thấp"),
        //                         TienDoModel = cvthang.EnumTienDo == 0 ? new TienDoModel(cvthang.EnumTienDo, "Kịp tiến độ") : cvthang.EnumTienDo == 1 ? new TienDoModel(cvthang.EnumTienDo, "Sớm hơn KH") : new TienDoModel(cvthang.EnumTienDo, "Trễ tiến độ"),
        //                         ChatLuongThangModel = cvthang.EnumChatLuong == 0 ? new ChatLuongThangModel(cvthang.EnumChatLuong, "<= 2 lỗi nội bộ triển khai test") : cvthang.EnumChatLuong == 1 ? new ChatLuongThangModel(cvthang.EnumChatLuong, "3 -> 4 lỗi nội bộ triển khai test") : cvthang.EnumChatLuong ==2?  new ChatLuongThangModel(cvthang.EnumChatLuong, "> 4 lỗi nội bộ hoặc <= 2 lỗi khách báo cáo") : new ChatLuongThangModel(cvthang.EnumChatLuong, "Lỗi nghiêm trọng phía khách hàng"),
        //                         nhanXetThang = cvthang.NhanXetThang
        //                     }).ToList();
        //        query.ForEach(x =>
        //        {
        //            listDanhGiaThang.Add(x);
        //        });
        //        return listDanhGiaThang;
        //    }
            
        //}

        public List<eDanhGiaCVThangModel> DanhGiaCongViecThang(int idThang, int idNhanSu, int idTuan)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var danhSachNhanSu = context.NsNhanSus.Where(ns => ns.Id == idNhanSu).ToList();
                var danhSachCongViecThang = context.CvCongViecThangs.Where(cvthang => cvthang.Idthang == idThang).ToList();
                //var danhSachCongViecTuan = context.CvCongViecTuans.Where(cvTuan => cvTuan.Idtuan == idTuan).ToList();
                string tenThang = context.DmThangs.Where(thang => thang.Id == idThang).Select(thang => thang.TenThang).FirstOrDefault();
                List<eDanhGiaCVThangModel> listDanhGiaThang = new List<eDanhGiaCVThangModel>();
                var query = (from ns in danhSachNhanSu
                             join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                             where ns.Id == idNhanSu && cvthang.Idthang == idThang 
                             select new eDanhGiaCVThangModel
                             {
                                 idThang = idThang,
                                 tenThang = tenThang,
                                 KhoiLuongModel = cvthang.EnumKhoiLuong == 0 ? new KhoiLuongModel(cvthang.EnumKhoiLuong, "Bình tường") : cvthang.EnumKhoiLuong == 1 ? new KhoiLuongModel(cvthang.EnumKhoiLuong, "Nhiều") : new KhoiLuongModel(cvthang.EnumKhoiLuong, "Thấp"),
                                 TienDoModel = cvthang.EnumTienDo == 0 ? new TienDoModel(cvthang.EnumTienDo, "Kịp tiến độ") : cvthang.EnumTienDo == 1 ? new TienDoModel(cvthang.EnumTienDo, "Sớm hơn KH") : new TienDoModel(cvthang.EnumTienDo, "Trễ tiến độ"),
                                 ChatLuongThangModel = cvthang.EnumChatLuong == 0 ? new ChatLuongThangModel(cvthang.EnumChatLuong, "Tốt, hầu như không lỗi") : cvthang.EnumChatLuong == 1 ? new ChatLuongThangModel(cvthang.EnumChatLuong, "Khá, vài lỗi nhỏ") : cvthang.EnumChatLuong == 2 ? new ChatLuongThangModel(cvthang.EnumChatLuong, "Trung , có vài lỗi lớn") : cvthang.EnumChatLuong == 3 ? new ChatLuongThangModel(cvthang.EnumChatLuong, "Yếu, nhiều lỗi") : new ChatLuongThangModel(4," "),
                                 nhanXetThang = cvthang.NhanXetThang
                             }).ToList();
                query.ForEach(x =>
                {
                    listDanhGiaThang.Add(x);
                    
                });
                for(int i = 0; i< listDanhGiaThang.Count; i++)
                {
                    if (listDanhGiaThang.Count == 1)
                        break;
                    listDanhGiaThang.Remove(listDanhGiaThang[i]);
                }
                return listDanhGiaThang;
            }

        }



        public List<eDanhGiaCVTuanModel> DanhGiaCongViecTuan(int idThang, int idNhanSu)
        {
            using (var context = new ASC_TASK_PLANNINGContext())

            {
                var danhSachNhanSu = context.NsNhanSus.Where(ns => ns.Id == idNhanSu).ToList();
                var danhSachCongViecThang = context.CvCongViecThangs.Where(cvthang => cvthang.Idthang == idThang).ToList();
                var danhSachCongViecTuan = context.CvCongViecTuans.ToList();
                var danhSachTuan = context.DmTuans.Where(tuan => tuan.Idthang == idThang).ToList();
                //var danhSachCongViecTuan = context.CvCongViecTuans.Where(cvTuan => cvTuan.Idtuan == idTuan).ToList();
                string tenThang = context.DmThangs.Where(thang => thang.Id == idThang).Select(thang => thang.TenThang).FirstOrDefault();
                List<eDanhGiaCVTuanModel> listDanhGiaTuan = new List<eDanhGiaCVTuanModel>();
                var query = (from ns in danhSachNhanSu
                             join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                             join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                             where ns.Id == idNhanSu && cvthang.Idthang == idThang
                             select new eDanhGiaCVTuanModel
                             {
                                 idCongViecTuan = cvt.Id,
                                 idTuan = cvt.Idtuan,
                                 tenTuan = "",
                                 KhoiLuongModel = cvt.EnumKhoiLuong == 0 ? new KhoiLuongModel(cvt.EnumKhoiLuong, "Bình tường") : cvt.EnumKhoiLuong == 1 ? new KhoiLuongModel(cvt.EnumKhoiLuong, "Nhiều") : new KhoiLuongModel(cvt.EnumKhoiLuong, "Thấp"),
                                 TienDoModel = cvt.EnumTienDo == 0 ? new TienDoModel(cvt.EnumTienDo, "Kịp tiến độ") : cvt.EnumTienDo == 1 ? new TienDoModel(cvt.EnumTienDo, "Sớm hơn KH") : new TienDoModel(cvt.EnumTienDo, "Trễ tiến độ"),
                                 ChatLuongTuanModel = cvt.EnumChatLuong == 0 ? new ChatLuongTuanModel(cvt.EnumChatLuong, "<= 2 lỗi nội bộ triển khai test") : cvt.EnumChatLuong == 1 ? new ChatLuongTuanModel(cvt.EnumChatLuong, "3 -> 4 lỗi nội bộ triển khai test") : cvt.EnumChatLuong == 2 ? new ChatLuongTuanModel(cvt.EnumChatLuong, "> 4 lỗi nội bộ hoặc <= 2 lỗi khách báo cáo") : cvt.EnumChatLuong == 3 ? new ChatLuongTuanModel(cvt.EnumChatLuong, "Lỗi nghiêm trọng phía khách hàng") : new ChatLuongTuanModel(4, " "),
                                 nhanXetTuan = cvt.NhanXetTuan
                             }).ToList();
                danhSachTuan.OrderBy(x => x.Id);
                
                danhSachTuan.ForEach(x => {
                    if(query.Count > 0)
                    {
                        query.ForEach(danhGiaTuan =>
                        {
                            if(x.Id == danhGiaTuan.idTuan)
                            {
                                danhGiaTuan.tenTuan = x.TenTuan + " ( " + x.TuNgay.ToString("dd/MM/yyyy") + " - " + x.DenNgay.ToString("dd/MM/yyyy") + " )";
                                listDanhGiaTuan.Add(danhGiaTuan);
                            }
                            //else
                            //{
                            //    eDanhGiaCVTuanModel eTuan = new eDanhGiaCVTuanModel();
                            //    eTuan.idTuan = x.Id;
                            //    eTuan.tenTuan = x.TenTuan + " ( " + x.TuNgay + " - " + x.DenNgay + " )";
                            //    KhoiLuongModel khoiLuongModel = new KhoiLuongModel();
                            //    khoiLuongModel.giaTrikhoiLuong = 3;
                            //    khoiLuongModel.tenKhoiLuong = " ";
                            //    eTuan.KhoiLuongModel = khoiLuongModel;
                            //    TienDoModel tienDoModel = new TienDoModel();
                            //    tienDoModel.giaTriTienDo = 3;
                            //    tienDoModel.tenTienDo = " ";
                            //    eTuan.TienDoModel = tienDoModel;
                            //    ChatLuongTuanModel chatLuongTuanModel = new ChatLuongTuanModel();
                            //    chatLuongTuanModel.giaTriChatLuongTuan = 4;
                            //    chatLuongTuanModel.tenChatLuongTuan = "";
                            //    eTuan.ChatLuongTuanModel = chatLuongTuanModel;
                            //    eTuan.nhanXetTuan = "";
                            //    listDanhGiaTuan.Add(eTuan);
                            //}

                        });
                    }

                    

                    //if(query.Count==0)
                    //{
                    //    eDanhGiaCVTuanModel eTuan = new eDanhGiaCVTuanModel();
                    //    eTuan.idTuan = x.Id;
                    //    eTuan.tenTuan = x.TenTuan + " ( " + x.TuNgay + " - " + x.DenNgay + " )";
                    //    KhoiLuongModel khoiLuongModel = new KhoiLuongModel();
                    //    khoiLuongModel.giaTrikhoiLuong = 3;
                    //    khoiLuongModel.tenKhoiLuong = " ";
                    //    eTuan.KhoiLuongModel = khoiLuongModel;
                    //    TienDoModel tienDoModel = new TienDoModel();
                    //    tienDoModel.giaTriTienDo = 3;
                    //    tienDoModel.tenTienDo = " ";
                    //    eTuan.TienDoModel = tienDoModel;
                    //    ChatLuongTuanModel chatLuongTuanModel = new ChatLuongTuanModel();
                    //    chatLuongTuanModel.giaTriChatLuongTuan = 4;
                    //    chatLuongTuanModel.tenChatLuongTuan = "";
                    //    eTuan.ChatLuongTuanModel = chatLuongTuanModel;
                    //    eTuan.nhanXetTuan = "";
                    //    listDanhGiaTuan.Add(eTuan);
                    //}

                    //eDanhGiaCVTuanModel eTuan1 = new eDanhGiaCVTuanModel();
                    //eTuan1.idTuan = x.Id;
                    //eTuan1.tenTuan = x.TenTuan + " ( " + x.TuNgay + " - " + x.DenNgay + " )";
                    //KhoiLuongModel khoiLuongModel1 = new KhoiLuongModel();
                    //khoiLuongModel1.giaTrikhoiLuong = 3;
                    //khoiLuongModel1.tenKhoiLuong = " ";
                    //eTuan1.KhoiLuongModel = khoiLuongModel1;
                    //TienDoModel tienDoModel1 = new TienDoModel();
                    //tienDoModel1.giaTriTienDo = 3;
                    //tienDoModel1.tenTienDo = " ";
                    //eTuan1.TienDoModel = tienDoModel1;
                    //ChatLuongTuanModel chatLuongTuanModel1 = new ChatLuongTuanModel();
                    //chatLuongTuanModel1.giaTriChatLuongTuan = 4;
                    //chatLuongTuanModel1.tenChatLuongTuan = "";
                    //eTuan1.ChatLuongTuanModel = chatLuongTuanModel1;
                    //eTuan1.nhanXetTuan = "";
                });

                for (int i = query.Count; i < danhSachTuan.Count; i++)
                {
                    eDanhGiaCVTuanModel eTuan = new eDanhGiaCVTuanModel();
                    eTuan.idCongViecTuan = -1;
                    eTuan.idTuan = danhSachTuan[i].Id;
                    eTuan.tenTuan = danhSachTuan[i].TenTuan + " ( " + danhSachTuan[i].TuNgay.ToString("dd/MM/yyyy") + " - " + danhSachTuan[i].DenNgay.ToString("dd/MM/yyyy") + " )";
                    KhoiLuongModel khoiLuongModel = new KhoiLuongModel();
                    khoiLuongModel.giaTrikhoiLuong = 3;
                    khoiLuongModel.tenKhoiLuong = " ";
                    eTuan.KhoiLuongModel = khoiLuongModel;
                    TienDoModel tienDoModel = new TienDoModel();
                    tienDoModel.giaTriTienDo = 3;
                    tienDoModel.tenTienDo = " ";
                    eTuan.TienDoModel = tienDoModel;
                    ChatLuongTuanModel chatLuongTuanModel = new ChatLuongTuanModel();
                    chatLuongTuanModel.giaTriChatLuongTuan = 4;
                    chatLuongTuanModel.tenChatLuongTuan = "";
                    eTuan.ChatLuongTuanModel = chatLuongTuanModel;
                    eTuan.nhanXetTuan = "";
                    listDanhGiaTuan.Add(eTuan);
                }

                return listDanhGiaTuan;
            }
        }
    

        public List<CvGiaoViec> DanhSachGiaoViec(int idCongViecTuan)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                var danhSachCvGiaoViec = context.CvGiaoViecs.Where(cvCongViec => cvCongViec.IdcongViecTuan == idCongViecTuan).ToList();
                return danhSachCvGiaoViec;
            }
        }

        //public List<eQuanLyCongViecModel> DanhSachQuanLyTheoThangVaTuan(int idThang,int idTuan)
        //{
        //    using(var context = new ASC_TASK_PLANNINGContext())
        //    {
        //        List<eQuanLyCongViecModel> eQuanLyCongViecModels = new List<eQuanLyCongViecModel>();
        //        List<NsNhanSu> danhSachNhanSu = new List<NsNhanSu>();
        //        danhSachNhanSu = context.NsNhanSus.ToList();
        //        List<CvCongViecThang> danhSachCongViecThang = new List<CvCongViecThang>();
        //        danhSachCongViecThang = context.CvCongViecThangs.Where(cvthang => cvthang.Idthang == idThang).ToList();
        //        var danhSachCongViecTuan = context.CvCongViecTuans.Where(cvtuan => cvtuan.Idtuan == idTuan).ToList();
        //        var danhSachCongViecGiao = context.CvGiaoViecs.ToList();
        //        var tongThoiGian = context.DmTuans.Where(tuan => tuan.Id == idTuan).FirstOrDefault();
        //        for(int i = 0; i < danhSachNhanSu.Count; i++)
        //        {
        //            var query = (from ns in danhSachNhanSu
        //                         join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
        //                         join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
        //                         join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
        //                         where ns.Id == danhSachNhanSu[i].Id && cvt.Idtuan == idTuan
        //                         select new eQuanLyCongViecModel
        //                         {
        //                            idNhanVien = danhSachNhanSu[i].Id,
        //                            tenNhanVien = danhSachNhanSu[i].Ten,
        //                            Dev = danhSachNhanSu[i].Id + " - " + danhSachNhanSu[i].Ten,
        //                            urlIssue = cvgv.UrlIssue,
        //                            tenCongViec = cvgv.TenCongViec,
        //                            thoiGianLam = cvgv.ThoiGianLam,
        //                            tuNgay = cvgv.GiaoTuNgay,
        //                            denNgay = cvgv.GiaoDenNgay,
        //                            idModule = cvgv.Idmodule,
        //                            mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
        //                            giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
        //                            giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
        //                            ghiChu = cvgv.GhiChu
        //                         }).ToList();
        //                query.ForEach(x => {
        //                    Console.WriteLine("Enum muc do hoan thanh : "+x.mucDoHoanThanh);
        //                var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
        //                eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
        //                x.eDmModuleModel = eDmModuleModel;
        //                NguonGocModel nguonGocModel = new NguonGocModel();
        //                TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
        //                if(x.giaTriENumNguonGoc == 0)
        //                {
        //                    nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
        //                    nguonGocModel.tenNguonGoc = "Tạo mới";
        //                }
        //                else if(x.giaTriENumNguonGoc == 1)
        //                {
        //                    nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
        //                    nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
        //                }
        //                else
        //                {
        //                    nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
        //                    nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
        //                }

        //                if(x.giaTriEnumTrangThai == 0)
        //                {
        //                    trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
        //                    trangThaiCongViecModel.tenTrangThai = "Đã xong";
        //                }
        //                else if(x.giaTriEnumTrangThai == 1)
        //                {
        //                    trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
        //                    trangThaiCongViecModel.tenTrangThai = "Chưa làm";
        //                }
        //                else if(x.giaTriEnumTrangThai == 2)
        //                {
        //                    trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
        //                    trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
        //                }
        //                else if(x.giaTriEnumTrangThai == 3)
        //                {
        //                    trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
        //                    trangThaiCongViecModel.tenTrangThai = "Chưa xong";
        //                }
        //                else if(x.giaTriEnumTrangThai == 4)
        //                {
        //                    trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
        //                    trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
        //                }
        //                else if(x.giaTriEnumTrangThai == 5)
        //                {
        //                    trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
        //                    trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
        //                }
        //                else
        //                {
        //                    trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
        //                    trangThaiCongViecModel.tenTrangThai = "Vắng";
        //                }
        //                x.NguonGocModel = nguonGocModel;
        //                x.TrangThaiCongViecModel = trangThaiCongViecModel;
        //                eQuanLyCongViecModels.Add(x);
        //            });
        //            eQuanLyCongViecModels.ForEach(x => Console.WriteLine(x.NguonGocModel.tenNguonGoc));
        //        }
        //        return eQuanLyCongViecModels;
        //    }
        //}

        public List<eQuanLyCongViecModel> DanhSachQuanLyTheoThangVaTuan(int idThang, int idTuan)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                List<eQuanLyCongViecModel> eQuanLyCongViecModels = new List<eQuanLyCongViecModel>();
                List<NsNhanSu> danhSachNhanSu = new List<NsNhanSu>();
                danhSachNhanSu = context.NsNhanSus.ToList();
                List<CvCongViecThang> danhSachCongViecThang = new List<CvCongViecThang>();
                danhSachCongViecThang = context.CvCongViecThangs.Where(cvthang => cvthang.Idthang == idThang).ToList();
                var danhSachCongViecTuan = context.CvCongViecTuans.Where(cvtuan => cvtuan.Idtuan == idTuan).ToList();
                var danhSachCongViecGiao = context.CvGiaoViecs.ToList();
                bool tuanDaKhoa = context.DmTuans.Where(tuan => tuan.Id == idTuan).Select(tuan => tuan.IsDaKhoa).FirstOrDefault();
                Console.WriteLine("Tuan da khoa : " + tuanDaKhoa);
                var tongThoiGian = context.DmTuans.Where(tuan => tuan.Id == idTuan).FirstOrDefault();
                for (int i = 0; i < danhSachNhanSu.Count; i++)
                {
                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                 where ns.Id == danhSachNhanSu[i].Id && cvt.Idtuan == idTuan
                                 select new eQuanLyCongViecModel
                                 {
                                     idNhanVien = danhSachNhanSu[i].Id,
                                     tenNhanVien = danhSachNhanSu[i].Ten,
                                     idGiaoViec = cvgv.Id,
                                     Dev = danhSachNhanSu[i].Id + " - " + danhSachNhanSu[i].Ten,
                                     urlIssue = cvgv.UrlIssue,
                                     tenCongViec = cvgv.TenCongViec,
                                     thoiGianLam = cvgv.ThoiGianLam,
                                     tuNgay = cvgv.GiaoTuNgay,
                                     denNgay = cvgv.GiaoDenNgay,
                                     idModule = cvgv.Idmodule,
                                     mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                     isDaDuyet = cvt.IsDaDuyet,
                                     isDaKhoa = tuanDaKhoa,
                                     giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                     giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                     ghiChu = cvgv.GhiChu
                                 }).ToList();
                    query.ForEach(x => {
                        //Console.WriteLine("Enum muc do hoan thanh : " + x.mucDoHoanThanh +" - Is da duyet :"+x.isDaDuyet+" - " +x.tenNhanVien);
                        var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                        eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                        x.eDmModuleModel = eDmModuleModel;
                        NguonGocModel nguonGocModel = new NguonGocModel();
                        TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                        if (x.giaTriENumNguonGoc == 0)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Tạo mới";
                        }
                        else if (x.giaTriENumNguonGoc == 1)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                        }
                        else
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                        }

                        if (x.giaTriEnumTrangThai == 0)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 1)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                        }
                        else if (x.giaTriEnumTrangThai == 2)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 3)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                        }
                        else if (x.giaTriEnumTrangThai == 4)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                        }
                        else if (x.giaTriEnumTrangThai == 5)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                        }
                        else
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Vắng";
                        }
                        x.NguonGocModel = nguonGocModel;
                        x.TrangThaiCongViecModel = trangThaiCongViecModel;
                        eQuanLyCongViecModels.Add(x);
                    });
                    
                }
                eQuanLyCongViecModels.ForEach(x => Console.WriteLine("Enum muc do hoan thanh 1: " + x.mucDoHoanThanh + " - Is da duyet :" + x.isDaDuyet + " - " + x.tenNhanVien));
                return eQuanLyCongViecModels;
            }
        }

        public List<string> DanhSachTenCongviec()
        {
           using(var context = new ASC_TASK_PLANNINGContext())
           {
                var danhSachTenCongViec = context.CvGiaoViecs.Select(giaoViec => giaoViec.TenCongViec).ToList();
                return danhSachTenCongViec;
           }
        }

        public List<eQuanLyCongViecModel> DanhSachTimKiem(string tenCongViecIndex, int dropdownlistThangTrongNamIndex, int dropdownlistTuanIndex, int dropdownlistModuleIndex, int dropdownlistNhanSuIndex, int dropdownlistLamViecIndex)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                List<eQuanLyCongViecModel> eQuanLyCongViecModels = new List<eQuanLyCongViecModel>();
                List<NsNhanSu> danhSachNhanSu = new List<NsNhanSu>();
                danhSachNhanSu = context.NsNhanSus.ToList();
                List<CvCongViecThang> danhSachCongViecThang = new List<CvCongViecThang>();
                danhSachCongViecThang = context.CvCongViecThangs.Where(cvthang => cvthang.Idthang == dropdownlistThangTrongNamIndex).ToList();
                var danhSachCongViecTuan = context.CvCongViecTuans.Where(cvtuan => cvtuan.Idtuan == dropdownlistTuanIndex).ToList();
                var danhSachCongViecGiao = context.CvGiaoViecs.ToList();
                var tongThoiGian = context.DmTuans.Where(tuan => tuan.Id == dropdownlistTuanIndex).FirstOrDefault();
                bool tuanDaKhoa = context.DmTuans.Where(tuan => tuan.Id == dropdownlistTuanIndex).Select(tuan => tuan.IsDaKhoa).FirstOrDefault();
                if (dropdownlistNhanSuIndex == 0 && tenCongViecIndex == null && dropdownlistModuleIndex == 0 && dropdownlistLamViecIndex == -1)
                {
                    Console.WriteLine("Da vo day 1");
                    Console.WriteLine("Tuan da khoa " + tuanDaKhoa);
                    for (int i = 0; i < danhSachNhanSu.Count; i++)
                    {

                        var query = (from ns in danhSachNhanSu
                                     join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                     join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                     join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                     where ns.Id == danhSachNhanSu[i].Id && cvt.Idtuan == dropdownlistTuanIndex
                                     select new eQuanLyCongViecModel
                                     {
                                         idNhanVien = danhSachNhanSu[i].Id,
                                         tenNhanVien = danhSachNhanSu[i].Ten,
                                         idGiaoViec = cvgv.Id,
                                         Dev = danhSachNhanSu[i].Id + " - " + danhSachNhanSu[i].Ten,
                                         urlIssue = cvgv.UrlIssue,
                                         tenCongViec = cvgv.TenCongViec,
                                         thoiGianLam = cvgv.ThoiGianLam,
                                         tuNgay = cvgv.GiaoTuNgay,
                                         denNgay = cvgv.GiaoDenNgay,
                                         idModule = cvgv.Idmodule,
                                         mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                         isDaDuyet = cvt.IsDaDuyet,
                                         isDaKhoa = tuanDaKhoa,
                                         giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                         giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                         ghiChu = cvgv.GhiChu
                                     }).ToList();
                        query.ForEach(x => {
                            Console.WriteLine("Enum muc do hoan thanh va isDakHoa: " + x.mucDoHoanThanh +" - "+x.isDaKhoa);
                            var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                            eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                            x.eDmModuleModel = eDmModuleModel;
                            NguonGocModel nguonGocModel = new NguonGocModel();
                            TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                            if (x.giaTriENumNguonGoc == 0)
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Tạo mới";
                            }
                            else if (x.giaTriENumNguonGoc == 1)
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                            }
                            else
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                            }

                            if (x.giaTriEnumTrangThai == 0)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Đã xong";
                            }
                            else if (x.giaTriEnumTrangThai == 1)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                            }
                            else if (x.giaTriEnumTrangThai == 2)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                            }
                            else if (x.giaTriEnumTrangThai == 3)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                            }
                            else if (x.giaTriEnumTrangThai == 4)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                            }
                            else if (x.giaTriEnumTrangThai == 5)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                            }
                            else
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Vắng";
                            }
                            x.NguonGocModel = nguonGocModel;
                            x.TrangThaiCongViecModel = trangThaiCongViecModel;
                            eQuanLyCongViecModels.Add(x);
                        });
                   
                        //eQuanLyCongViecModels.ForEach(x => Console.WriteLine(x.NguonGocModel.tenNguonGoc));
                    }
                }
                else if(dropdownlistModuleIndex!=0 && tenCongViecIndex == null && dropdownlistNhanSuIndex ==0 && dropdownlistLamViecIndex == -1)
                {
                    Console.WriteLine("Da vo else if 1");

                    for (int i = 0; i < danhSachNhanSu.Count; i++)
                    {

                        var query = (from ns in danhSachNhanSu
                                     join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                     join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                     join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                     where ns.Id == danhSachNhanSu[i].Id && cvt.Idtuan == dropdownlistTuanIndex
                                     select new eQuanLyCongViecModel
                                     {
                                         idNhanVien = danhSachNhanSu[i].Id,
                                         tenNhanVien = danhSachNhanSu[i].Ten,
                                         idGiaoViec = cvgv.Id,
                                         Dev = danhSachNhanSu[i].Id + " - " + danhSachNhanSu[i].Ten,
                                         urlIssue = cvgv.UrlIssue,
                                         tenCongViec = cvgv.TenCongViec,
                                         thoiGianLam = cvgv.ThoiGianLam,
                                         tuNgay = cvgv.GiaoTuNgay,
                                         denNgay = cvgv.GiaoDenNgay,
                                         idModule = cvgv.Idmodule,
                                         mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                         isDaDuyet = cvt.IsDaDuyet,
                                         isDaKhoa = tuanDaKhoa,
                                         giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                         giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                         ghiChu = cvgv.GhiChu
                                     }).ToList();
                        query.ForEach(x => {
                            Console.WriteLine("Enum muc do hoan thanh : " + x.mucDoHoanThanh);
                            var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                            eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                            x.eDmModuleModel = eDmModuleModel;
                            NguonGocModel nguonGocModel = new NguonGocModel();
                            TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                            if (x.giaTriENumNguonGoc == 0)
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Tạo mới";
                            }
                            else if (x.giaTriENumNguonGoc == 1)
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                            }
                            else
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                            }

                            if (x.giaTriEnumTrangThai == 0)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Đã xong";
                            }
                            else if (x.giaTriEnumTrangThai == 1)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                            }
                            else if (x.giaTriEnumTrangThai == 2)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                            }
                            else if (x.giaTriEnumTrangThai == 3)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                            }
                            else if (x.giaTriEnumTrangThai == 4)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                            }
                            else if (x.giaTriEnumTrangThai == 5)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                            }
                            else
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Vắng";
                            }
                            x.NguonGocModel = nguonGocModel;
                            x.TrangThaiCongViecModel = trangThaiCongViecModel;
                            eQuanLyCongViecModels.Add(x);
                        });
                        
                    }
                    List<eQuanLyCongViecModel> e1 = new List<eQuanLyCongViecModel>();
                    e1 = eQuanLyCongViecModels.Where(e => e.idModule == dropdownlistModuleIndex).Select(x => x).ToList();

                    e1.ForEach(x =>
                    {
                        Console.WriteLine(" id Module : " + x.idModule + " - ten Nhan vien :" + x.tenNhanVien);
                    });
                    return eQuanLyCongViecModels.Where(e => e.idModule == dropdownlistModuleIndex).Select(x => x).ToList(); 
                }
                else if(dropdownlistModuleIndex == 0 && tenCongViecIndex != null && dropdownlistNhanSuIndex == 0 && dropdownlistLamViecIndex == -1)
                {
                    Console.WriteLine("Da vo ten cong viec != null :");
                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                 where cvt.Idtuan == dropdownlistTuanIndex
                                 select new eQuanLyCongViecModel
                                 {
                                     idNhanVien = ns.Id,
                                     tenNhanVien = ns.Ten,
                                     Dev = ns.Id + " - " + ns.Ten,
                                     idGiaoViec = cvgv.Id,
                                     urlIssue = cvgv.UrlIssue,
                                     tenCongViec = cvgv.TenCongViec,
                                     thoiGianLam = cvgv.ThoiGianLam,
                                     tuNgay = cvgv.GiaoTuNgay,
                                     denNgay = cvgv.GiaoDenNgay,
                                     idModule = cvgv.Idmodule,
                                     mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                     isDaDuyet = cvt.IsDaDuyet,
                                     isDaKhoa = tuanDaKhoa,
                                     giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                     giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                     ghiChu = cvgv.GhiChu
                                 }).ToList();
                        query.ForEach(x => {
                        var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                        eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                        x.eDmModuleModel = eDmModuleModel;
                        NguonGocModel nguonGocModel = new NguonGocModel();
                        TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                        if (x.giaTriENumNguonGoc == 0)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Tạo mới";
                        }
                        else if (x.giaTriENumNguonGoc == 1)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                        }
                        else
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                        }

                        if (x.giaTriEnumTrangThai == 0)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 1)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                        }
                        else if (x.giaTriEnumTrangThai == 2)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 3)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                        }
                        else if (x.giaTriEnumTrangThai == 4)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                        }
                        else if (x.giaTriEnumTrangThai == 5)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                        }
                        else
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Vắng";
                        }
                        x.NguonGocModel = nguonGocModel;
                        x.TrangThaiCongViecModel = trangThaiCongViecModel;
                        eQuanLyCongViecModels.Add(x);
                            eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" ten cong viec :" + x.tenCongViec));
                        });
                    List<eQuanLyCongViecModel> eQuanLyCongViecModels1 = new List<eQuanLyCongViecModel>();
                    eQuanLyCongViecModels1 = eQuanLyCongViecModels.Where(x => x.tenCongViec.Equals(tenCongViecIndex)).Select(c => c).ToList();
                    eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" ten cong viec :" + x.tenCongViec));
                    eQuanLyCongViecModels1.ForEach(x => Console.WriteLine(" ten cong viec 1:" + x.tenCongViec));
                    return eQuanLyCongViecModels1;
                }
                else if (dropdownlistModuleIndex == 0 && tenCongViecIndex == null && dropdownlistNhanSuIndex != 0 && dropdownlistLamViecIndex == -1)
                {
                    Console.WriteLine("Da vo dropdownlistNhanSu != 0");
                    

                        var query = (from ns in danhSachNhanSu
                                     join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                     join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                     join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                     where ns.Id == dropdownlistNhanSuIndex && cvt.Idtuan == dropdownlistTuanIndex
                                     select new eQuanLyCongViecModel
                                     {
                                         idNhanVien = dropdownlistNhanSuIndex,
                                         tenNhanVien = ns.Ten,
                                         Dev = dropdownlistNhanSuIndex + " - " + ns.Ten,
                                         idGiaoViec = cvgv.Id,
                                         urlIssue = cvgv.UrlIssue,
                                         tenCongViec = cvgv.TenCongViec,
                                         thoiGianLam = cvgv.ThoiGianLam,
                                         tuNgay = cvgv.GiaoTuNgay,
                                         denNgay = cvgv.GiaoDenNgay,
                                         idModule = cvgv.Idmodule,
                                         mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                         isDaDuyet = cvt.IsDaDuyet,
                                         isDaKhoa = tuanDaKhoa,
                                         giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                         giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                         ghiChu = cvgv.GhiChu
                                     }).ToList();
                        query.ForEach(x => {
                            Console.WriteLine("Enum muc do hoan thanh : " + x.mucDoHoanThanh);
                            var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                            eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                            x.eDmModuleModel = eDmModuleModel;
                            NguonGocModel nguonGocModel = new NguonGocModel();
                            TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                            if (x.giaTriENumNguonGoc == 0)
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Tạo mới";
                            }
                            else if (x.giaTriENumNguonGoc == 1)
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                            }
                            else
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                            }

                            if (x.giaTriEnumTrangThai == 0)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Đã xong";
                            }
                            else if (x.giaTriEnumTrangThai == 1)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                            }
                            else if (x.giaTriEnumTrangThai == 2)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                            }
                            else if (x.giaTriEnumTrangThai == 3)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                            }
                            else if (x.giaTriEnumTrangThai == 4)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                            }
                            else if (x.giaTriEnumTrangThai == 5)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                            }
                            else
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Vắng";
                            }
                            x.NguonGocModel = nguonGocModel;
                            x.TrangThaiCongViecModel = trangThaiCongViecModel;
                            eQuanLyCongViecModels.Add(x);
                        });

                        eQuanLyCongViecModels.ForEach(x => Console.WriteLine("Tim theo nhan su. cong viec : "+x.tenCongViec));
                    
                }
                else if (dropdownlistModuleIndex == 0 && tenCongViecIndex == null && dropdownlistNhanSuIndex == 0 && dropdownlistLamViecIndex != -1)
                {
                    Console.WriteLine(" Da vo dropdownlist Lam Viec !=-1");
                    for (int i = 0; i < danhSachNhanSu.Count; i++)
                    {

                        var query = (from ns in danhSachNhanSu
                                     join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                     join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                     join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                     where ns.Id == danhSachNhanSu[i].Id && cvt.Idtuan == dropdownlistTuanIndex && cvgv.EnumTrangThaiCongViec == dropdownlistLamViecIndex
                                     select new eQuanLyCongViecModel
                                     {
                                         idNhanVien = danhSachNhanSu[i].Id,
                                         tenNhanVien = danhSachNhanSu[i].Ten,
                                         Dev = danhSachNhanSu[i].Id + " - " + danhSachNhanSu[i].Ten,
                                         idGiaoViec = cvgv.Id,
                                         urlIssue = cvgv.UrlIssue,
                                         tenCongViec = cvgv.TenCongViec,
                                         thoiGianLam = cvgv.ThoiGianLam,
                                         tuNgay = cvgv.GiaoTuNgay,
                                         denNgay = cvgv.GiaoDenNgay,
                                         idModule = cvgv.Idmodule,
                                         mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                         isDaDuyet = cvt.IsDaDuyet,
                                         isDaKhoa = tuanDaKhoa,
                                         giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                         giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                         ghiChu = cvgv.GhiChu
                                     }).ToList();
                        query.ForEach(x => {
                            Console.WriteLine("Enum muc do hoan thanh : " + x.mucDoHoanThanh);
                            var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                            eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                            x.eDmModuleModel = eDmModuleModel;
                            NguonGocModel nguonGocModel = new NguonGocModel();
                            TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                            if (x.giaTriENumNguonGoc == 0)
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Tạo mới";
                            }
                            else if (x.giaTriENumNguonGoc == 1)
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                            }
                            else
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                            }

                            if (x.giaTriEnumTrangThai == 0)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Đã xong";
                            }
                            else if (x.giaTriEnumTrangThai == 1)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                            }
                            else if (x.giaTriEnumTrangThai == 2)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                            }
                            else if (x.giaTriEnumTrangThai == 3)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                            }
                            else if (x.giaTriEnumTrangThai == 4)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                            }
                            else if (x.giaTriEnumTrangThai == 5)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                            }
                            else
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Vắng";
                            }
                            x.NguonGocModel = nguonGocModel;
                            x.TrangThaiCongViecModel = trangThaiCongViecModel;
                            eQuanLyCongViecModels.Add(x);
                        });
                        
                        //eQuanLyCongViecModels.ForEach(x => Console.WriteLine(x.NguonGocModel.tenNguonGoc));
                    }
                    Console.WriteLine("Danh sach quan ly : " + eQuanLyCongViecModels.Count());
                    eQuanLyCongViecModels.ForEach(x => Console.WriteLine("Trang thai cong viec. Ten nhan vien : " + x.tenNhanVien + " - ten cv :" + x.tenCongViec + " trang thai : " + x.TrangThaiCongViecModel.tenTrangThai));
                }
                else if (dropdownlistModuleIndex != 0 && tenCongViecIndex != null && dropdownlistNhanSuIndex == 0 && dropdownlistLamViecIndex == -1)
                {
                    Console.WriteLine("Da vo ten cong viec va idmodule != null :");
                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                 where cvt.Idtuan == dropdownlistTuanIndex && cvgv.Idmodule == dropdownlistModuleIndex && cvgv.TenCongViec.Equals(tenCongViecIndex)
                                 select new eQuanLyCongViecModel
                                 {
                                     idNhanVien = ns.Id,
                                     tenNhanVien = ns.Ten,
                                     Dev = ns.Id + " - " + ns.Ten,
                                     idGiaoViec = cvgv.Id,
                                     urlIssue = cvgv.UrlIssue,
                                     tenCongViec = cvgv.TenCongViec,
                                     thoiGianLam = cvgv.ThoiGianLam,
                                     tuNgay = cvgv.GiaoTuNgay,
                                     denNgay = cvgv.GiaoDenNgay,
                                     idModule = cvgv.Idmodule,
                                     mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                     isDaDuyet = cvt.IsDaDuyet,
                                     isDaKhoa = tuanDaKhoa,
                                     giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                     giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                     ghiChu = cvgv.GhiChu
                                 }).ToList();
                    query.ForEach(x => {
                        var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                        eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                        x.eDmModuleModel = eDmModuleModel;
                        NguonGocModel nguonGocModel = new NguonGocModel();
                        TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                        if (x.giaTriENumNguonGoc == 0)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Tạo mới";
                        }
                        else if (x.giaTriENumNguonGoc == 1)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                        }
                        else
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                        }

                        if (x.giaTriEnumTrangThai == 0)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 1)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                        }
                        else if (x.giaTriEnumTrangThai == 2)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 3)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                        }
                        else if (x.giaTriEnumTrangThai == 4)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                        }
                        else if (x.giaTriEnumTrangThai == 5)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                        }
                        else
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Vắng";
                        }
                        x.NguonGocModel = nguonGocModel;
                        x.TrangThaiCongViecModel = trangThaiCongViecModel;
                        eQuanLyCongViecModels.Add(x);
                    });
                    //List<eQuanLyCongViecModel> eQuanLyCongViecModels1 = new List<eQuanLyCongViecModel>();
                    //eQuanLyCongViecModels1 = eQuanLyCongViecModels.Where(x => x.tenCongViec.Equals(tenCongViecIndex)).Select(c => c).ToList();
                    eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" ten cong viec va id module. :" + x.tenCongViec +" - "+x.idModule));
                    //eQuanLyCongViecModels1.ForEach(x => Console.WriteLine(" ten cong viec 1:" + x.tenCongViec));
                    //return eQuanLyCongViecModels1;
                }
                else if(dropdownlistModuleIndex != 0 && tenCongViecIndex == null && dropdownlistNhanSuIndex != 0 && dropdownlistLamViecIndex == -1)
                {
                    Console.WriteLine("Da vo dropdownlistNhanSu va idModule != 0");


                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                 where ns.Id == dropdownlistNhanSuIndex && cvt.Idtuan == dropdownlistTuanIndex && cvgv.Idmodule == dropdownlistModuleIndex
                                 select new eQuanLyCongViecModel
                                 {
                                     idNhanVien = dropdownlistNhanSuIndex,
                                     tenNhanVien = ns.Ten,
                                     Dev = dropdownlistNhanSuIndex + " - " + ns.Ten,
                                     idGiaoViec = cvgv.Id,
                                     urlIssue = cvgv.UrlIssue,
                                     tenCongViec = cvgv.TenCongViec,
                                     thoiGianLam = cvgv.ThoiGianLam,
                                     tuNgay = cvgv.GiaoTuNgay,
                                     denNgay = cvgv.GiaoDenNgay,
                                     idModule = cvgv.Idmodule,
                                     mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                     isDaDuyet = cvt.IsDaDuyet,
                                     isDaKhoa = tuanDaKhoa,
                                     giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                     giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                     ghiChu = cvgv.GhiChu
                                 }).ToList();
                    query.ForEach(x => {
                        Console.WriteLine("Enum muc do hoan thanh : " + x.mucDoHoanThanh);
                        var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                        eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                        x.eDmModuleModel = eDmModuleModel;
                        NguonGocModel nguonGocModel = new NguonGocModel();
                        TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                        if (x.giaTriENumNguonGoc == 0)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Tạo mới";
                        }
                        else if (x.giaTriENumNguonGoc == 1)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                        }
                        else
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                        }

                        if (x.giaTriEnumTrangThai == 0)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 1)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                        }
                        else if (x.giaTriEnumTrangThai == 2)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 3)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                        }
                        else if (x.giaTriEnumTrangThai == 4)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                        }
                        else if (x.giaTriEnumTrangThai == 5)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                        }
                        else
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Vắng";
                        }
                        x.NguonGocModel = nguonGocModel;
                        x.TrangThaiCongViecModel = trangThaiCongViecModel;
                        eQuanLyCongViecModels.Add(x);
                    });

                    eQuanLyCongViecModels.ForEach(x => Console.WriteLine("Tim theo nhan su va idModule. cong viec va idMoudle: " + x.tenCongViec +" - "+x.idModule));
                }
                else if(dropdownlistModuleIndex != 0 && tenCongViecIndex == null && dropdownlistNhanSuIndex == 0 && dropdownlistLamViecIndex != -1)
                {
                    Console.WriteLine(" Da vo dropdownlist Lam Viec !=-1 va dropdownlist !=0");
                    for (int i = 0; i < danhSachNhanSu.Count; i++)
                    {

                        var query = (from ns in danhSachNhanSu
                                     join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                     join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                     join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                     where ns.Id == danhSachNhanSu[i].Id && cvt.Idtuan == dropdownlistTuanIndex && cvgv.EnumTrangThaiCongViec == dropdownlistLamViecIndex && cvgv.Idmodule == dropdownlistModuleIndex
                                     select new eQuanLyCongViecModel
                                     {
                                         idNhanVien = danhSachNhanSu[i].Id,
                                         tenNhanVien = danhSachNhanSu[i].Ten,
                                         Dev = danhSachNhanSu[i].Id + " - " + danhSachNhanSu[i].Ten,
                                         idGiaoViec = cvgv.Id,
                                         urlIssue = cvgv.UrlIssue,
                                         tenCongViec = cvgv.TenCongViec,
                                         thoiGianLam = cvgv.ThoiGianLam,
                                         tuNgay = cvgv.GiaoTuNgay,
                                         denNgay = cvgv.GiaoDenNgay,
                                         idModule = cvgv.Idmodule,
                                         mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                         isDaDuyet = cvt.IsDaDuyet,
                                         isDaKhoa = tuanDaKhoa,
                                         giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                         giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                         ghiChu = cvgv.GhiChu
                                     }).ToList();
                        query.ForEach(x => {
                            Console.WriteLine("Enum muc do hoan thanh : " + x.mucDoHoanThanh);
                            var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                            eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                            x.eDmModuleModel = eDmModuleModel;
                            NguonGocModel nguonGocModel = new NguonGocModel();
                            TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                            if (x.giaTriENumNguonGoc == 0)
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Tạo mới";
                            }
                            else if (x.giaTriENumNguonGoc == 1)
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                            }
                            else
                            {
                                nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                                nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                            }

                            if (x.giaTriEnumTrangThai == 0)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Đã xong";
                            }
                            else if (x.giaTriEnumTrangThai == 1)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                            }
                            else if (x.giaTriEnumTrangThai == 2)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                            }
                            else if (x.giaTriEnumTrangThai == 3)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                            }
                            else if (x.giaTriEnumTrangThai == 4)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                            }
                            else if (x.giaTriEnumTrangThai == 5)
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                            }
                            else
                            {
                                trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                                trangThaiCongViecModel.tenTrangThai = "Vắng";
                            }
                            x.NguonGocModel = nguonGocModel;
                            x.TrangThaiCongViecModel = trangThaiCongViecModel;
                            eQuanLyCongViecModels.Add(x);
                        });

                        //eQuanLyCongViecModels.ForEach(x => Console.WriteLine(x.NguonGocModel.tenNguonGoc));
                    }
                    Console.WriteLine("Danh sach quan ly : " + eQuanLyCongViecModels.Count());
                    eQuanLyCongViecModels.ForEach(x => Console.WriteLine("Trang thai cong viec. Ten nhan vien : " + x.tenNhanVien + " - ten cv :" + x.tenCongViec + " trang thai : " + x.TrangThaiCongViecModel.tenTrangThai +" - IdModule :"+x.idModule));
                }
                else if(dropdownlistModuleIndex == 0 && tenCongViecIndex != null && dropdownlistNhanSuIndex == 0 && dropdownlistLamViecIndex != -1)
                {
                    Console.WriteLine("Da vo ten cong viec != null va dropdownlistlamviec !=-1:");
                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                 where cvt.Idtuan == dropdownlistTuanIndex && cvgv.TenCongViec.Equals(tenCongViecIndex) && cvgv.EnumTrangThaiCongViec == dropdownlistLamViecIndex
                                 select new eQuanLyCongViecModel
                                 {
                                     idNhanVien = ns.Id,
                                     tenNhanVien = ns.Ten,
                                     Dev = ns.Id + " - " + ns.Ten,
                                     idGiaoViec = cvgv.IdcongViecTuan,
                                     urlIssue = cvgv.UrlIssue,
                                     tenCongViec = cvgv.TenCongViec,
                                     thoiGianLam = cvgv.ThoiGianLam,
                                     tuNgay = cvgv.GiaoTuNgay,
                                     denNgay = cvgv.GiaoDenNgay,
                                     idModule = cvgv.Idmodule,
                                     mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                     isDaDuyet = cvt.IsDaDuyet,
                                     isDaKhoa = tuanDaKhoa,
                                     giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                     giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                     ghiChu = cvgv.GhiChu
                                 }).ToList();
                    query.ForEach(x => {
                        var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                        eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                        x.eDmModuleModel = eDmModuleModel;
                        NguonGocModel nguonGocModel = new NguonGocModel();
                        TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                        if (x.giaTriENumNguonGoc == 0)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Tạo mới";
                        }
                        else if (x.giaTriENumNguonGoc == 1)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                        }
                        else
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                        }

                        if (x.giaTriEnumTrangThai == 0)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 1)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                        }
                        else if (x.giaTriEnumTrangThai == 2)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 3)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                        }
                        else if (x.giaTriEnumTrangThai == 4)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                        }
                        else if (x.giaTriEnumTrangThai == 5)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                        }
                        else
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Vắng";
                        }
                        x.NguonGocModel = nguonGocModel;
                        x.TrangThaiCongViecModel = trangThaiCongViecModel;
                        eQuanLyCongViecModels.Add(x);
                        eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" ten cong viec :" + x.tenCongViec));
                    });
                    
                    eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" ten cong viec :" + x.tenCongViec +" - "+x.giaTriEnumTrangThai));
                   
                }
                else if(dropdownlistModuleIndex == 0 && tenCongViecIndex == null && dropdownlistNhanSuIndex != 0 && dropdownlistLamViecIndex != -1)
                {
                    Console.WriteLine("Da vo dropdownlistNhanSu va dropdownlistlamviec != 0");


                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                 where ns.Id == dropdownlistNhanSuIndex && cvt.Idtuan == dropdownlistTuanIndex && cvgv.EnumTrangThaiCongViec == dropdownlistLamViecIndex
                                 select new eQuanLyCongViecModel
                                 {
                                     idNhanVien = dropdownlistNhanSuIndex,
                                     tenNhanVien = ns.Ten,
                                     Dev = dropdownlistNhanSuIndex + " - " + ns.Ten,
                                     idGiaoViec = cvgv.Id,
                                     urlIssue = cvgv.UrlIssue,
                                     tenCongViec = cvgv.TenCongViec,
                                     thoiGianLam = cvgv.ThoiGianLam,
                                     tuNgay = cvgv.GiaoTuNgay,
                                     denNgay = cvgv.GiaoDenNgay,
                                     idModule = cvgv.Idmodule,
                                     mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                     isDaDuyet = cvt.IsDaDuyet,
                                     isDaKhoa = tuanDaKhoa,
                                     giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                     giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                     ghiChu = cvgv.GhiChu
                                 }).ToList();
                    query.ForEach(x => {
                        Console.WriteLine("Enum muc do hoan thanh : " + x.mucDoHoanThanh);
                        var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                        eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                        x.eDmModuleModel = eDmModuleModel;
                        NguonGocModel nguonGocModel = new NguonGocModel();
                        TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                        if (x.giaTriENumNguonGoc == 0)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Tạo mới";
                        }
                        else if (x.giaTriENumNguonGoc == 1)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                        }
                        else
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                        }

                        if (x.giaTriEnumTrangThai == 0)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 1)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                        }
                        else if (x.giaTriEnumTrangThai == 2)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 3)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                        }
                        else if (x.giaTriEnumTrangThai == 4)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                        }
                        else if (x.giaTriEnumTrangThai == 5)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                        }
                        else
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Vắng";
                        }
                        x.NguonGocModel = nguonGocModel;
                        x.TrangThaiCongViecModel = trangThaiCongViecModel;
                        eQuanLyCongViecModels.Add(x);
                    });

                    eQuanLyCongViecModels.ForEach(x => Console.WriteLine("Tim theo nhan su va idModule. cong viec va idMoudle va trang thai: " + x.tenCongViec + " - " + x.idModule + " - " +x.TrangThaiCongViecModel.tenTrangThai));
                }
                else if(dropdownlistModuleIndex != 0 && tenCongViecIndex != null && dropdownlistNhanSuIndex != 0 && dropdownlistLamViecIndex == -1)
                {
                    Console.WriteLine("Da vo ten cong viec != null :");
                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan 
                                 where cvt.Idtuan == dropdownlistTuanIndex
                                 select new eQuanLyCongViecModel
                                 {
                                     idNhanVien = ns.Id,
                                     tenNhanVien = ns.Ten,
                                     Dev = ns.Id + " - " + ns.Ten,
                                     idGiaoViec = cvgv.Id,
                                     urlIssue = cvgv.UrlIssue,
                                     tenCongViec = cvgv.TenCongViec,
                                     thoiGianLam = cvgv.ThoiGianLam,
                                     tuNgay = cvgv.GiaoTuNgay,
                                     denNgay = cvgv.GiaoDenNgay,
                                     idModule = cvgv.Idmodule,
                                     mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                     isDaDuyet = cvt.IsDaDuyet,
                                     isDaKhoa = tuanDaKhoa,
                                     giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                     giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                     ghiChu = cvgv.GhiChu
                                 }).ToList();
                    query.ForEach(x => {
                        var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                        eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                        x.eDmModuleModel = eDmModuleModel;
                        NguonGocModel nguonGocModel = new NguonGocModel();
                        TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                        if (x.giaTriENumNguonGoc == 0)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Tạo mới";
                        }
                        else if (x.giaTriENumNguonGoc == 1)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                        }
                        else
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                        }

                        if (x.giaTriEnumTrangThai == 0)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 1)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                        }
                        else if (x.giaTriEnumTrangThai == 2)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 3)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                        }
                        else if (x.giaTriEnumTrangThai == 4)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                        }
                        else if (x.giaTriEnumTrangThai == 5)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                        }
                        else
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Vắng";
                        }
                        x.NguonGocModel = nguonGocModel;
                        x.TrangThaiCongViecModel = trangThaiCongViecModel;
                        eQuanLyCongViecModels.Add(x);
                        eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" ten cong viec :" + x.tenCongViec));
                    });
                    List<eQuanLyCongViecModel> eQuanLyCongViecModels1 = new List<eQuanLyCongViecModel>();
                    eQuanLyCongViecModels1 = eQuanLyCongViecModels.Where(x => x.tenCongViec.Equals(tenCongViecIndex) && x.idModule == dropdownlistModuleIndex && x.idNhanVien == dropdownlistNhanSuIndex).Select(c => c).ToList();
                    eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" ten cong viec :" + x.tenCongViec));
                    eQuanLyCongViecModels1.ForEach(x => Console.WriteLine(" ten cong viec 1:" + x.tenCongViec));
                    return eQuanLyCongViecModels1;
                }
                else if(dropdownlistModuleIndex == 0 && tenCongViecIndex != null && dropdownlistNhanSuIndex != 0 && dropdownlistLamViecIndex != -1)
                {
                    Console.WriteLine("Da vo ten cong viec != null va dropdownlistlamviec !=-1 va drop downlist nhan su !=0:");
                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                 where cvt.Idtuan == dropdownlistTuanIndex && cvgv.TenCongViec.Equals(tenCongViecIndex) && cvgv.EnumTrangThaiCongViec == dropdownlistLamViecIndex && ns.Id == dropdownlistNhanSuIndex
                                 select new eQuanLyCongViecModel
                                 {
                                     idNhanVien = ns.Id,
                                     tenNhanVien = ns.Ten,
                                     Dev = ns.Id + " - " + ns.Ten,
                                     idGiaoViec = cvgv.Id,
                                     urlIssue = cvgv.UrlIssue,
                                     tenCongViec = cvgv.TenCongViec,
                                     thoiGianLam = cvgv.ThoiGianLam,
                                     tuNgay = cvgv.GiaoTuNgay,
                                     denNgay = cvgv.GiaoDenNgay,
                                     idModule = cvgv.Idmodule,
                                     mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                     isDaDuyet = cvt.IsDaDuyet,
                                     isDaKhoa = tuanDaKhoa,
                                     giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                     giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                     ghiChu = cvgv.GhiChu
                                 }).ToList();
                    query.ForEach(x => {
                        var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                        eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                        x.eDmModuleModel = eDmModuleModel;
                        NguonGocModel nguonGocModel = new NguonGocModel();
                        TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                        if (x.giaTriENumNguonGoc == 0)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Tạo mới";
                        }
                        else if (x.giaTriENumNguonGoc == 1)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                        }
                        else
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                        }

                        if (x.giaTriEnumTrangThai == 0)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 1)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                        }
                        else if (x.giaTriEnumTrangThai == 2)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 3)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                        }
                        else if (x.giaTriEnumTrangThai == 4)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                        }
                        else if (x.giaTriEnumTrangThai == 5)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                        }
                        else
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Vắng";
                        }
                        x.NguonGocModel = nguonGocModel;
                        x.TrangThaiCongViecModel = trangThaiCongViecModel;
                        eQuanLyCongViecModels.Add(x);
                        eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" ten cong viec :" + x.tenCongViec));
                    });

                    eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" ten cong viec :" + x.tenCongViec + " - " + x.giaTriEnumTrangThai));
                }
                else if(dropdownlistModuleIndex != 0 && tenCongViecIndex == null && dropdownlistNhanSuIndex != 0 && dropdownlistLamViecIndex != -1)
                {
                    Console.WriteLine("Da vo dropdownlistindex !=0 va dropdownlistlamviec !=-1 va drop downlist nhan su !=0:");
                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                 where cvt.Idtuan == dropdownlistTuanIndex && cvgv.Idmodule==dropdownlistModuleIndex && cvgv.EnumTrangThaiCongViec == dropdownlistLamViecIndex && ns.Id == dropdownlistNhanSuIndex
                                 select new eQuanLyCongViecModel
                                 {
                                     idNhanVien = ns.Id,
                                     tenNhanVien = ns.Ten,
                                     Dev = ns.Id + " - " + ns.Ten,
                                     idGiaoViec = cvgv.Id,
                                     urlIssue = cvgv.UrlIssue,
                                     tenCongViec = cvgv.TenCongViec,
                                     thoiGianLam = cvgv.ThoiGianLam,
                                     tuNgay = cvgv.GiaoTuNgay,
                                     denNgay = cvgv.GiaoDenNgay,
                                     idModule = cvgv.Idmodule,
                                     mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                     isDaDuyet = cvt.IsDaDuyet,
                                     isDaKhoa = tuanDaKhoa,
                                     giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                     giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                     ghiChu = cvgv.GhiChu
                                 }).ToList();
                    query.ForEach(x => {
                        var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                        eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                        x.eDmModuleModel = eDmModuleModel;
                        NguonGocModel nguonGocModel = new NguonGocModel();
                        TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                        if (x.giaTriENumNguonGoc == 0)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Tạo mới";
                        }
                        else if (x.giaTriENumNguonGoc == 1)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                        }
                        else
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                        }

                        if (x.giaTriEnumTrangThai == 0)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 1)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                        }
                        else if (x.giaTriEnumTrangThai == 2)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 3)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                        }
                        else if (x.giaTriEnumTrangThai == 4)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                        }
                        else if (x.giaTriEnumTrangThai == 5)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                        }
                        else
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Vắng";
                        }
                        x.NguonGocModel = nguonGocModel;
                        x.TrangThaiCongViecModel = trangThaiCongViecModel;
                        eQuanLyCongViecModels.Add(x);
                    });

                    eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" ten cong viec :" + x.tenCongViec + " - " + x.giaTriEnumTrangThai));
                }
                else
                {
                    Console.WriteLine("Da vo truong hop cuoi cung");
                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                 where cvt.Idtuan == dropdownlistTuanIndex && cvgv.Idmodule == dropdownlistModuleIndex && cvgv.EnumTrangThaiCongViec == dropdownlistLamViecIndex && ns.Id == dropdownlistNhanSuIndex && cvgv.TenCongViec.Equals(tenCongViecIndex)
                                 select new eQuanLyCongViecModel
                                 {
                                     idNhanVien = ns.Id,
                                     tenNhanVien = ns.Ten,
                                     Dev = ns.Id + " - " + ns.Ten,
                                     idGiaoViec = cvgv.Id,
                                     urlIssue = cvgv.UrlIssue,
                                     tenCongViec = cvgv.TenCongViec,
                                     thoiGianLam = cvgv.ThoiGianLam,
                                     tuNgay = cvgv.GiaoTuNgay,
                                     denNgay = cvgv.GiaoDenNgay,
                                     idModule = cvgv.Idmodule,
                                     mucDoHoanThanh = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                     isDaDuyet = cvt.IsDaDuyet,
                                     isDaKhoa = tuanDaKhoa,
                                     giaTriENumNguonGoc = cvgv.EnumNguocGocCongViec,
                                     giaTriEnumTrangThai = cvgv.EnumTrangThaiCongViec,
                                     ghiChu = cvgv.GhiChu
                                 }).ToList();
                    query.ForEach(x => {
                        var module = context.DmModules.Where(module => module.Id == x.idModule).FirstOrDefault();
                        eDmModuleModel eDmModuleModel = new eDmModuleModel(module.Id, module.TenModule);
                        x.eDmModuleModel = eDmModuleModel;
                        NguonGocModel nguonGocModel = new NguonGocModel();
                        TrangThaiCongViecModel trangThaiCongViecModel = new TrangThaiCongViecModel();
                        if (x.giaTriENumNguonGoc == 0)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Tạo mới";
                        }
                        else if (x.giaTriENumNguonGoc == 1)
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 2 lần";
                        }
                        else
                        {
                            nguonGocModel.giaTriNguonGoc = x.giaTriENumNguonGoc;
                            nguonGocModel.tenNguonGoc = "Dời do đột xuất 3 lần";
                        }

                        if (x.giaTriEnumTrangThai == 0)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 1)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa làm";
                        }
                        else if (x.giaTriEnumTrangThai == 2)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Task đột xuất đã xong";
                        }
                        else if (x.giaTriEnumTrangThai == 3)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong";
                        }
                        else if (x.giaTriEnumTrangThai == 4)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác chưa duyệt";
                        }
                        else if (x.giaTriEnumTrangThai == 5)
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Chưa xong bận task khác đã duyệt";
                        }
                        else
                        {
                            trangThaiCongViecModel.giaTriTrangThai = x.giaTriEnumTrangThai;
                            trangThaiCongViecModel.tenTrangThai = "Vắng";
                        }
                        x.NguonGocModel = nguonGocModel;
                        x.TrangThaiCongViecModel = trangThaiCongViecModel;
                        eQuanLyCongViecModels.Add(x);
                        eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" ten cong viec :" + x.tenCongViec));
                    });

                    eQuanLyCongViecModels.ForEach(x => Console.WriteLine(" ten cong viec :" + x.tenCongViec + " - " + x.giaTriEnumTrangThai));
                }
                //
                return eQuanLyCongViecModels;
            }
        }

        public bool KiemTraSoLanDoiCongViec(int idGiaoViec)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                var danhSachNhanSu = context.NsNhanSus.ToList();
                var danhSachCongViecThang = context.CvCongViecThangs.ToList();
                var danhSachCongViecTuan = context.CvCongViecTuans.ToList();
                var danhSachCongViecGiao = context.CvGiaoViecs.ToList();
                var query = (from ns in danhSachNhanSu
                             join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                             join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                             join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                             where cvgv.IdgiaoViecCopiedFrom == idGiaoViec
                             select new 
                             {
                                 idCopy = cvgv.IdgiaoViecCopiedFrom
                             }).ToList();
                if (query.Count <= 2)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public bool KiemTraTenCongViec(string tenCongViec)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                var cvGiaoViec = context.CvGiaoViecs.Where(cvGiao => cvGiao.TenCongViec.Equals(tenCongViec)).ToList();
                if (cvGiaoViec.Count == 0)
                    return true;
                else
                    return false;
            }
        }

        public bool ThemCongViecGiao(int idCongViecTuan, int idModule, string tenCongViec,int thoiGianLam, DateTime giaoDenngay, DateTime ngayHoanThanh,string urlIssusse, string tenIssusse)
        {
           using(var context = new ASC_TASK_PLANNINGContext())
           {
                int save = 0;
                DmModule dmModule = new DmModule();
                dmModule = _IDmModuleSerivce.TimModuleTheoId(idModule);
                Console.WriteLine("DmModule : " + dmModule.TenModule);
                CvGiaoViec cvGiaoViec = new CvGiaoViec(idCongViecTuan, idModule, 0, urlIssusse, tenIssusse, tenCongViec, thoiGianLam, 1, giaoDenngay, ngayHoanThanh,DateTime.Now, "", DateTime.Now, 123);
                context.CvGiaoViecs.Add(cvGiaoViec);
                save = context.SaveChanges();
                if (save > 0)
                    return true;
                return false;
            }
        }

        public void Update(eQuanLyCongViecModel GiaoViec)
        {

            using (var context = new ASC_TASK_PLANNINGContext())
            {
                //var giaoViecs = context.CvGiaoViecs.ToList();
                //int idgv = context.CvGiaoViecs.Where(x => x.Id == GiaoViec.idGiaoViec).Select(t => t.Id).FirstOrDefault();
                //int idgiaoviec = context.CvGiaoViecs.Where(x => x.Id == GiaoViec.idGiaoViec).Select(t => t.IdcongViecTuan).FirstOrDefault();
                int idCVTuan = context.CvGiaoViecs.Where(x => x.Id == GiaoViec.idGiaoViec).Select(t => t.IdcongViecTuan).FirstOrDefault();
                string tenURL = context.CvGiaoViecs.Where(x => x.Id == GiaoViec.idGiaoViec).Select(t => t.TenIssue).FirstOrDefault();
                int tgLam = context.CvGiaoViecs.Where(x => x.Id == GiaoViec.idGiaoViec).Select(t => t.ThoiGianLam).FirstOrDefault();
                int idNguoiTao = context.CvGiaoViecs.Where(x => x.Id == GiaoViec.idGiaoViec).Select(t => t.IdnguoiTao).FirstOrDefault();
                //DateTime ngayTao = context.CvGiaoViecs.Where(x => x.Id == GiaoViec.idGiaoViec).Select(t => t.NgayTao).FirstOrDefault();
                var copiform = context.CvGiaoViecs.Where(x => x.Id == GiaoViec.idGiaoViec).Select(t => t.IdgiaoViecCopiedFrom).FirstOrDefault();
                DateTime ngayHoanThanh = DateTime.Now;
                var entity = new CvGiaoViec();

                entity.Id = GiaoViec.idGiaoViec;
                entity.Idmodule = GiaoViec.idModule;
                entity.IdcongViecTuan = idCVTuan;
                entity.EnumNguocGocCongViec = GiaoViec.giaTriENumNguonGoc;
                entity.EnumTrangThaiCongViec = GiaoViec.giaTriEnumTrangThai;
                entity.IdgiaoViecCopiedFrom = (int?)copiform;
                entity.TenIssue = tenURL;
                entity.UrlIssue = GiaoViec.urlIssue;
                entity.TenCongViec = GiaoViec.tenCongViec;
                if (GiaoViec.thoiGianLam <= 0)
                    entity.ThoiGianLam = tgLam;
                else
                    entity.ThoiGianLam = GiaoViec.thoiGianLam;
                entity.GiaoTuNgay = GiaoViec.tuNgay;
                entity.GiaoDenNgay = GiaoViec.denNgay;
                entity.NgayHoanThanh = (DateTime)ngayHoanThanh;
                entity.GhiChu = GiaoViec.ghiChu;
                entity.NgayTao = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                entity.IdnguoiTao = idNguoiTao;
                entity.NgayCapNhat = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                entity.IdnguoiCapNhat = 123;
                context.CvGiaoViecs.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void UpdateMotCongViec(int dropdownlistNhanSu, int dropdownlistThangTrongNam, int dropdownlistTuan, string urlIssusse, string tenIssusse, int dropdownlistModule, string tenCongViec, int thoiGianLam, int dropdownlistLamViec, DateTime tuNgay, DateTime denNgay, string ghiChu, int idCongViecCapNhat)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {           
                CvGiaoViec cvgv = context.CvGiaoViecs.Where(cvgv => cvgv.Id == idCongViecCapNhat).FirstOrDefault();
                cvgv.TenCongViec = tenCongViec;
                cvgv.Idmodule = dropdownlistModule;
                cvgv.GiaoTuNgay = tuNgay;
                cvgv.GiaoDenNgay = denNgay;
                cvgv.UrlIssue = urlIssusse;
                cvgv.GhiChu = ghiChu;
                cvgv.EnumTrangThaiCongViec = dropdownlistLamViec;
                cvgv.ThoiGianLam = thoiGianLam;
                context.CvGiaoViecs.Update(cvgv);
                context.SaveChanges();
            }
        }

        public string XoaCongViecGiao(List<int> listIdGiaoViec, int idTuan)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                string message = "";
                var danhSachNhanSu = context.NsNhanSus.ToList();
                var danhSachCongViecThang = context.CvCongViecThangs.ToList();
                var danhSachCongViecTuan = context.CvCongViecTuans.Where(cvTuan => cvTuan.Idtuan == idTuan).ToList();
                var danhSachCongViecGiao = context.CvGiaoViecs.ToList();
                bool check = true;
                bool isDaKhoa = context.DmTuans.Where(tuan => tuan.Id == idTuan).Select(tuan => tuan.IsDaKhoa).FirstOrDefault();
                if (isDaKhoa == false)
                {

                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                 where cvt.Idtuan == idTuan
                                 select new
                                 {
                                     ten = ns.Ten,
                                     idGiaoViec = cvgv.Id,
                                     daDuyet = cvt.IsDaDuyet
                                 }).ToList();
                    // 1 3
                    listIdGiaoViec.ForEach(x =>
                    {
                        query.ForEach(k =>
                        {
                            if(x == k.idGiaoViec)
                                if(k.daDuyet == true)
                                {
                                    //message += k.ten + " - ";
                                    check = false;
                                }
                        });
                    });

                    if(check == true)
                    {
                        listIdGiaoViec.ForEach(x =>
                        {
                            int save = 0;
                            CvGiaoViec cvGiaoViec = new CvGiaoViec();
                            cvGiaoViec = context.CvGiaoViecs.Where(giaoViec => giaoViec.Id == x).FirstOrDefault();
                            context.Remove(cvGiaoViec);
                            save = context.SaveChanges();
                            if (save > 0)
                            {
                                Console.WriteLine("Xoa thanh cong " + x);
                            }
                            else
                            {
                                Console.WriteLine("Xoa khong thanh cong " + x);
                            }
                        });
                    }
                    else
                    {
                        var query1 = query.Distinct();
                        query.ForEach(x =>
                        {
                            if(x.daDuyet == true)
                                message += x.ten + " - ";
                        });
                        message += "Đã duyệt tuần không thể xoá";
                    }


                    //query.ForEach(x =>
                    //{
                    //    if (x.daDuyet == true)
                    //    {
                    //        message += x.ten + " - ";
                    //        check = true;
                    //    }
                    //});
                    //if (check == false)
                    //{
                    //    listIdGiaoViec.ForEach(x =>
                    //    {
                    //        int save = 0;
                    //        CvGiaoViec cvGiaoViec = new CvGiaoViec();
                    //        cvGiaoViec = context.CvGiaoViecs.Where(giaoViec => giaoViec.Id == x).FirstOrDefault();
                    //        context.Remove(cvGiaoViec);
                    //        save = context.SaveChanges();
                    //        if(save > 0)
                    //        {
                    //            Console.WriteLine("Xoa thanh cong " +x);
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine("Xoa khong thanh cong " +x);
                    //        }
                    //    });
                    //}
                    //else
                    //{
                    //    message += "Đã duyệt tuần không thể xoá";
                    //}

                }
                else
                    message = "Đã khoá tuần thể xoá";
                return message ;
            }
        }
    }
}
