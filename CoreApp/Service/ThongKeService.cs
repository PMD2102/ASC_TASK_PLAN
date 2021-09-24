using System;
using System.Collections.Generic;
using CoreApp.Models;
using System.Linq;


namespace CoreApp.Service
{
    public class ThongKeService : IThongKeService
    {
        public List<Nam> DanhSachNamThongKe()
        {
           using(var context = new ASC_TASK_PLANNINGContext())
           {
                List<Nam> dmThangs = new List<Nam>();
                var danhSachNam = context.DmThangs.ToList();
                var ds = from p in danhSachNam
                         group p by p.Nam into gr
                         select gr.FirstOrDefault();
                ds.ToList().ForEach(x=> {
                    Nam dm = new Nam();
                    dm.tenNam ="Năm " +x.Nam;
                    dm.nam = x.Nam;
                    Console.WriteLine("x Nam" + dm.nam);
                    dmThangs.Add(dm);
                });
                return dmThangs;
           }
        }

        public List<eThongKeModel> DanhSachThongKeTheoThang(List<CvCongViecThang> danhSachCongViecThang, List<DmTuan> danhSachTuanTrongThang, List<NsNhanSu> danhSachNhanSu, DmThang dmThang)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                List<eThongKeModel> danhSachThongKeModel = new List<eThongKeModel>();
                var danhSachCongViecTuan = context.CvCongViecTuans.ToList();
                var danhSachCongViecGiao = context.CvGiaoViecs.ToList();
                //var cvThang = context.CvCongViecThangs.Where(thang => thang.Idthang == dmThang.Id).FirstOrDefault();
                //string nhanXetThang = cvThang.NhanXetThang;
                for (int i = 0; i < danhSachTuanTrongThang.Count; i++)
                {
                    danhSachCongViecTuan = context.CvCongViecTuans.Where(cv => cv.Idtuan == danhSachTuanTrongThang[i].Id).ToList();
                    for (int j = 0; j < danhSachNhanSu.Count; j++)
                    {
                        var query = (from ns in danhSachNhanSu
                                     join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                     join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                     join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                     where ns.Id == danhSachNhanSu[j].Id && cvt.Idtuan == danhSachTuanTrongThang[i].Id
                                     select new
                                     {
                                         Id = danhSachTuanTrongThang[i].Id,
                                         idNhanVien = danhSachNhanSu[j].Id,
                                         nhanXetThang = cvthang.NhanXetThang,
                                         soGioLamTrongTuan = cvgv.ThoiGianLam,
                                         ten = ns.Ten,
                                         soGio = (cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXong || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.vang || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.chuaXongBanTaskKhacDaDuyet || cvgv.EnumTrangThaiCongViec == (int)EnumQuanLy.TrangThai.daXongTaskDotXuat) ? cvgv.ThoiGianLam : 0,
                                     }).ToList();
                        if(query.Count!=0)
                        {
                            eThongKeModel eThongKeModel = new eThongKeModel();
                            query.ForEach(x =>
                            {
                                eThongKeModel.idTuan = x.Id;
                                eThongKeModel.tenNhanVien = x.ten;
                                eThongKeModel.idNhanVien = x.idNhanVien;
                                eThongKeModel.nhanXetThang = x.nhanXetThang;
                                eThongKeModel.gioTrongTuan += x.soGioLamTrongTuan;
                                eThongKeModel.soGioLam += x.soGio;
                            });
                            danhSachThongKeModel.Add(eThongKeModel);
                        }
                        else
                        {
                            eThongKeModel eThongKeModel = new eThongKeModel();
                            var cvThang = context.CvCongViecThangs.Where(thang => thang.Idthang == dmThang.Id && thang.IdnhanSu == danhSachNhanSu[j].Id).FirstOrDefault();
                            string nhanXetThang = "";
                            if (cvThang != null)
                                nhanXetThang = cvThang.NhanXetThang;                           
                            eThongKeModel.idTuan = danhSachTuanTrongThang[i].Id;
                            eThongKeModel.tenNhanVien = danhSachNhanSu[j].Ten;
                            eThongKeModel.idNhanVien = danhSachNhanSu[j].Id;
                            eThongKeModel.nhanXetThang = nhanXetThang;
                            eThongKeModel.gioTrongTuan = 0;
                            eThongKeModel.soGioLam = 0;
                            danhSachThongKeModel.Add(eThongKeModel);
                        }
                    }

                }

                danhSachThongKeModel.ForEach(x => Console.WriteLine(x.Print()));
                return danhSachThongKeModel;
            }


        }

        
    }
}
