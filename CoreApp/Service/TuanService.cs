using System;
using System.Collections.Generic;
using CoreApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Service
{
    public class TuanService : IDMTuanService
    {
        public void CapNhatDanhGiaTuan(eDanhGiaCVTuanModel eDanhGiaCVTuanModel, int idNhanVien)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                //var danhSachNhanSu = context.NsNhanSus.Where(x => x.Id == idNhanVien).ToList();
                //var danhSachCongViecThang = context.CvCongViecThangs.ToList();
                //var danhSachCongViecTuan = context.CvCongViecTuans.Where(x => x.Idtuan == eDanhGiaCVTuanModel.idTuan).AsNoTracking().ToList();
                //var query = (from ns in danhSachNhanSu
                //             join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                //             join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                //             where ns.Id == idNhanVien && cvt.Idtuan == eDanhGiaCVTuanModel.idTuan
                //             select new CvCongViecTuan
                //             {
                //                 Id = cvt.Id,
                //                 IdcongViecThang = cvthang.Idthang,
                //                 Idtuan = eDanhGiaCVTuanModel.idTuan,
                //                 EnumKhoiLuong = eDanhGiaCVTuanModel.KhoiLuongModel.giaTrikhoiLuong,
                //                 EnumChatLuong = eDanhGiaCVTuanModel.ChatLuongTuanModel.giaTriChatLuongTuan,
                //                 EnumTienDo = eDanhGiaCVTuanModel.TienDoModel.giaTriTienDo,
                //                 IdnhanSu = cvt.IdnhanSu,
                //                 NhanXetTuan = eDanhGiaCVTuanModel.nhanXetTuan,
                //                 NgayTao = DateTime.Now,
                //                 IdnguoiTao = 123,
                //                 IsDaDuyet = cvt.IsDaDuyet,
                //                 NgayCapNhat = DateTime.Now,
                //                 IdnguoiCapNhat = 123
                //             }).FirstOrDefault();
                var cvt = context.CvCongViecTuans.Where(cvTuan => cvTuan.Id == eDanhGiaCVTuanModel.idCongViecTuan).FirstOrDefault();
                if(cvt !=null)
                {
                    cvt.EnumKhoiLuong = eDanhGiaCVTuanModel.KhoiLuongModel.giaTrikhoiLuong;
                    cvt.EnumChatLuong = eDanhGiaCVTuanModel.ChatLuongTuanModel.giaTriChatLuongTuan;
                    cvt.EnumTienDo = eDanhGiaCVTuanModel.TienDoModel.giaTriTienDo;
                    cvt.NhanXetTuan = eDanhGiaCVTuanModel.nhanXetTuan;
                    context.CvCongViecTuans.Attach(cvt);
                    context.Entry(cvt).State = EntityState.Modified;
                    context.SaveChanges();
                }
                
            }
        }

        public List<DmTuan> DanhSachTuanTrongThang(int idThang)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                var danhSachTuan = context.DmTuans.Where(tuan => tuan.Idthang == idThang).ToList();
                return danhSachTuan;
            }
        }

        public DmTuan GetTuan(int idTuan)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var dmTuan = context.DmTuans.Where(tuan => tuan.Id == idTuan).FirstOrDefault();
                return dmTuan;
            }
        }

        public void KhoaKeHoachTuan(List<int> listIdDmTuan)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                foreach (var idTuan in listIdDmTuan)
                {                    
                    DmTuan DmTuan = context.DmTuans.Find(idTuan);
                    DmTuan.IsDaKhoa = true;
                    context.DmTuans.Update(DmTuan).Property(x => x.SoThuTu).IsModified = false;
                    context.SaveChanges();
                    
                }
            }
            
        }

        public void MoKhoaTuan(int idTuan)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                DmTuan dmTuan = new DmTuan();
                dmTuan = context.DmTuans.Where(tuan => tuan.Id == idTuan).FirstOrDefault();
                if(dmTuan.IsDaKhoa == true)
                {
                    Console.WriteLine("da vo is da khoa == true");
                    int save = 0;
                    dmTuan.IsDaKhoa = false;
                    context.DmTuans.Update(dmTuan);
                    save = context.SaveChanges();
                    if (save > 0)
                        Console.WriteLine("Cap nhat thanh cong");
                    else
                        Console.WriteLine("cap nhatk kh thanh cong");
                }
                else
                {
                    Console.WriteLine("da vo is da khoa == false");
                    int save = 0;
                    dmTuan.IsDaKhoa = true;
                    context.DmTuans.Update(dmTuan);
                    save = context.SaveChanges();
                    if (save > 0)
                        Console.WriteLine("Cap nhat thanh cong");
                    else
                        Console.WriteLine("cap nhatk kh thanh cong");
                }
            }
        }

        public string NhanXetTuan(int idTuan)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                string nhanXet = "";
                var danhSachNhanSu = context.NsNhanSus.ToList();
                var danhSachCongViecThang = context.CvCongViecThangs.ToList();
                var danhSachCongViecTuan = context.CvCongViecTuans.ToList();
                danhSachNhanSu.ForEach(nhanSu =>
                {
                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 where ns.Id == nhanSu.Id && cvt.Idtuan == idTuan
                                 select new
                                 {
                                     nhanXetTuan = cvt.NhanXetTuan,
                                     ten = nhanSu.Ten,
                                 }).ToList();
                    if (query.Count != 0)
                    {
                        query.ForEach(x =>
                        {
                            nhanXet += x.ten + " - " + x.nhanXetTuan + "<br/>";
                        });
                    }
                    else
                        nhanXet += nhanSu.Ten + " - " + " Chưa có nhận xét <br/>";
                });
                return nhanXet;
            }
            
        }

        public List<DmTuan> PhatSinhTuanTheoThang(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                Console.WriteLine("Da vo phat sinh tuan lai ne");
                List<DmTuan> listTuan = new List<DmTuan>();
                int idThang = context.DmThangs.Where(x => x.Nam == ngayBatDau.Year && x.GiaTri == ngayBatDau.Month).Select(x => x.Id).FirstOrDefault();
                List<DmTuan> dsTuan = new List<DmTuan>();
                //cap nhat lan thu 1 
                if (idThang != 0)
                {
                    Console.WriteLine("da vo Count > 0");

                    dsTuan = DanhSachTuanTrongThang(idThang);
                    listTuan.ForEach(x =>
                    {
                        Console.WriteLine(" X tuan : " + x.Print() + " - " + x.IsDaKhoa);
                    });
                }
                DateTime ngayBatDau1 = ngayBatDau;
                DateTime ngayKetThuc1 = ngayKetThuc;
                DateTime ngayKetThucTam = ngayBatDau1;
                int tongSoNgay = 0;
                //Tìm ngày cuối cùng trong tháng
                DateTime dtResult = ngayBatDau1;
                dtResult = dtResult.AddMonths(1);
                dtResult=dtResult.AddDays(-(dtResult.Day));
                Console.WriteLine("Ngay cuoi cung torng thang : " +dtResult);

                //Tim tong so ngay de phat sinh tuan
                if(ngayBatDau1.Month == ngayKetThuc1.Month)
                {
                    tongSoNgay = ngayKetThuc1.Day - ngayBatDau1.Day + 1;
                }
                else
                {
                    tongSoNgay = dtResult.Day - ngayBatDau1.Day + 1 + ngayKetThuc1.Day;
                }
                Console.WriteLine("Tong So Ngay : "+tongSoNgay);
                //Tinh ra so tuan
                int thuTuTuan = 0;
                float tuan = tongSoNgay/7f;
                Console.WriteLine("So Ngay");
                int soLanLap = (int)Math.Round(tuan,0);
                Console.WriteLine("So lan lap : "+soLanLap);
                if(ngayBatDau1.Month == ngayKetThuc1.Month)
                {
                    for(int i= 0; i<soLanLap; i++)
                    {
                        if(i%2==0)
                        {
                            Console.WriteLine("Tuan thu : "+i);
                            Console.WriteLine("Ngay Bat Dau : "+ngayBatDau1);
                            if(!(ngayKetThucTam.Day>=ngayKetThuc1.Day))
                            {
                                ngayKetThucTam = new DateTime(ngayBatDau1.Year,ngayBatDau1.Month,ngayBatDau1.Day+4);
                                if(ngayKetThucTam.Day>=ngayKetThuc1.Day)
                                    ngayKetThucTam = ngayKetThuc1;
                            }
                            else
                                ngayKetThucTam = ngayKetThuc1;
                            thuTuTuan++;
                            listTuan.Add(new DmTuan("Tuần "+thuTuTuan,i+1,ngayBatDau1,ngayKetThucTam,ngayKetThucTam.DayOfWeek==DayOfWeek.Saturday?44:40,false));
                            Console.WriteLine("Day of week "+ngayKetThucTam.DayOfWeek);
                            Console.WriteLine("Ngay Ket Thuc : "+ngayKetThucTam);
                            if(!(ngayKetThucTam.Day>=ngayKetThuc1.Day))
                            {
                                ngayBatDau1 = new DateTime(ngayBatDau1.Year,ngayBatDau1.Month,ngayKetThucTam.Day+3);
                                ngayKetThucTam = ngayBatDau1;                
                            }
                        }
                        else{
                            
                            Console.WriteLine("Tuan thu : "+i);
                            Console.WriteLine("Ngay Bat Dau : "+ngayBatDau1);
                            if(!(ngayKetThucTam.Day>=ngayKetThuc1.Day))
                                {
                                    // ngayBatDau = new DateTime(2021,7,ngayBatDau.Day+5);
                                    ngayKetThucTam = new DateTime(ngayBatDau1.Year,ngayBatDau1.Month,ngayBatDau1.Day+5);
                                    if(ngayKetThucTam.Day>=ngayKetThuc1.Day)
                                        ngayKetThucTam = ngayKetThuc1;
                                }
                            else
                                {
                                    // ngayBatDau = ngayKeThuc;
                                    ngayKetThucTam = ngayKetThuc1;
                                }
                            thuTuTuan++;
                            listTuan.Add(new DmTuan("Tuần "+thuTuTuan,i+1,ngayBatDau1,ngayKetThucTam,ngayKetThucTam.DayOfWeek==DayOfWeek.Saturday?44:40,false));
                            Console.WriteLine("Day of week "+ngayKetThucTam.DayOfWeek);
                            // ngayBatDau = new DateTime(ngayBatDau.Year,ngayBatDau.Month,ngayBatDau.Day+5);
                            Console.WriteLine("Ngay Ket Thuc : "+ngayKetThucTam);
                            if(!(ngayKetThucTam.Day>=ngayKetThuc1.Day))
                                {
                                    ngayBatDau1 = new DateTime(ngayBatDau1.Year,ngayBatDau1.Month,ngayKetThucTam.Day+2);
                                    ngayKetThucTam = ngayBatDau1;
                                }
                            // else
                            //     {
                            //         // ngayBatDau = ngayKeThuc;
                            //         ngayKeThucTam = ngayBatDau;
                            //     }
                            
                        }
                    }
                }
                else
                {
                    for(int i= 0; i<soLanLap; i++)
                    {
                        if(i%2==0)
                        {
                            Console.WriteLine("Tuan thu : "+i);
                            Console.WriteLine("Ngay Bat Dau : "+ngayBatDau1);
                            try{
                                ngayKetThucTam = new DateTime(ngayBatDau1.Year,ngayBatDau1.Month,ngayBatDau1.Day+4); 
                            }catch{
                                ngayKetThucTam = new DateTime(ngayBatDau1.Year,ngayBatDau1.Month,ngayBatDau1.Day);
                                ngayKetThucTam = ngayKetThuc1;
                            }   
                            // ngayKeThucTam = new DateTime(2021,8,ngayBatDau.Day+4); 
                            listTuan.Add(new DmTuan("Tuần "+thuTuTuan,i+1,ngayBatDau1,ngayKetThucTam,ngayKetThucTam.DayOfWeek==DayOfWeek.Saturday?44:40,false));
                            Console.WriteLine("Ngay Ket Thuc : "+ngayKetThucTam);
                            ngayBatDau1 = new DateTime(ngayBatDau1.Year,ngayBatDau1.Month,ngayKetThucTam.Day+3);
                            ngayKetThucTam = ngayBatDau1;                
                        }
                        else
                        {
                            Console.WriteLine("Tuan thu : "+i);
                            Console.WriteLine("Ngay Bat Dau : "+ngayBatDau1);
                            try{
                                ngayKetThucTam = new DateTime(ngayBatDau1.Year,ngayBatDau1.Month,ngayBatDau1.Day+5);
                            }catch{
                                ngayKetThucTam = new DateTime(ngayBatDau1.Year,ngayBatDau1.Month,ngayBatDau1.Day);
                                ngayKetThucTam = ngayKetThuc1;
                            }
                            // ngayKeThucTam = new DateTime(2021,8,ngayBatDau.Day+5);        
                            listTuan.Add(new DmTuan("Tuần "+thuTuTuan,i+1,ngayBatDau1,ngayKetThucTam,ngayKetThucTam.DayOfWeek==DayOfWeek.Saturday?44:40,false));
                            // ngayBatDau = new DateTime(ngayBatDau.Year,ngayBatDau.Month,ngayBatDau.Day+5);
                            Console.WriteLine("Ngay Ket Thuc : "+ngayKetThucTam);
                            ngayBatDau1 = new DateTime(ngayBatDau1.Year,ngayBatDau1.Month,ngayKetThucTam.Day+2);
                            ngayKetThucTam = ngayBatDau1;
                        }
                        thuTuTuan++;
                    }
                }
                //Cap nhat lan thu 1 demo
                for (int i = 0; i < dsTuan.Count; i++)
                {
                    listTuan[i].IsDaKhoa = dsTuan[i].IsDaKhoa;
                    if (i == listTuan.Count - 1)
                        break;
                }

                //cap nhat lan thu 1 demo
                for (int i = 0; i < listTuan.Count; i++)
                {
                    int k = 1;
                    k += i;
                    
                    Console.WriteLine("Console i :" + i +" - "+k);
                    listTuan[i].TenTuan = "Tuần " + k;
                    Console.WriteLine("Ten tuan ne : " + listTuan[i].TenTuan);
                   
                } 

                listTuan.ForEach(x => Console.WriteLine("Ngay bat dau : "+x.TuNgay +"-" +"Ngay ket thuc : "+x.DenNgay));

                return listTuan;
            }
        }

        //public List<string> XoaTuan(List<int> listIdDmTuan)
        //{
        //    using(var context = new ASC_TASK_PLANNINGContext())
        //    {
        //        List<string> listIdString = new List<string>();                
        //        foreach (var idTuan in listIdDmTuan)
        //        {
        //            var dmTuan = context.DmTuans.Find(idTuan);
        //            Console.WriteLine("Dm tuan : "+dmTuan.Print());
        //            var CVCongViecTuan = context.CvCongViecTuans.Where(cvTuan => cvTuan.Idtuan==dmTuan.Id).ToList();
        //            if(CVCongViecTuan.ToList().Count()>0)
        //            {
        //                listIdString.Add(dmTuan.TenTuan + " - " +dmTuan.TuNgay.Month);
        //                Console.WriteLine(dmTuan.TenTuan + " - " +dmTuan.TuNgay.Month);
        //            }          
        //        }
        //        if(listIdString.Count()==0)
        //        {
        //            foreach (var idTuan in listIdDmTuan)
        //            {
        //                try{
        //                    var dmTuan = context.DmTuans.Find(idTuan);
        //                    context.DmTuans.Remove(dmTuan);
        //                    context.SaveChanges();   
        //                }catch{

        //                }                            
        //            }
        //        }
        //        return listIdString;
        //    }    
        //}

        public List<string> XoaTuan(List<int> listIdDmTuan)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                List<string> listIdString = new List<string>();
                bool checkTuan = false;
                foreach (var idTuan in listIdDmTuan)
                {
                    var dmTuan = context.DmTuans.Where(tuan => tuan.Id == idTuan).FirstOrDefault();
                    
                    //var CVCongViecTuan = context.CvCongViecTuans.Where(cvTuan => cvTuan.Idtuan == dmTuan.Id).ToList();
                    if (dmTuan.IsDaKhoa == true)
                    {
                        checkTuan = true;
                        listIdString.Add(dmTuan.TenTuan + " - " + dmTuan.TuNgay.Month);
                        Console.WriteLine(dmTuan.TenTuan + " - " + dmTuan.TuNgay.Month);
                    }
                }
                if (checkTuan == false)
                {
                    int saveCVGV = 0;
                    int saveCVT = 0;
                    foreach (var idTuan in listIdDmTuan)
                    {
                        var dmTuan = context.DmTuans.Where(tuan => tuan.Id == idTuan).FirstOrDefault();
                        Console.WriteLine("Dm tuan id : " + dmTuan.Id + " - ten tuan " + dmTuan.TenTuan + " -");
                        var cvCongViecTuan = context.CvCongViecTuans.Where(cvtuan => cvtuan.Idtuan == dmTuan.Id).ToList();
                        cvCongViecTuan.ForEach(cvtuan =>
                        {

                                var cvGiaoViecs = context.CvGiaoViecs.Where(cvgv => cvgv.IdcongViecTuan == cvtuan.Id).ToList();
                                cvGiaoViecs.ForEach(cvgv =>{
                                    context.CvGiaoViecs.Remove(cvgv);
                                    saveCVGV = context.SaveChanges();
                                    if (saveCVGV > 0)
                                        Console.WriteLine("Xoa thanh cong cvgv");
                                    else
                                        Console.WriteLine("Xoa khong thanh cong cvgv");
                                });
                               
                            });
                            if(saveCVGV > 0)
                            {
                                cvCongViecTuan.ForEach(x =>
                                {
                                    context.CvCongViecTuans.Remove(x);
                                    saveCVT = context.SaveChanges();
                                    if (saveCVT > 0)
                                        Console.WriteLine("Xoa cong viec tuan thanhf cong");
                                    else
                                        Console.WriteLine("Xoa cvtuan khong thanh cong ");
                                });
                            }

                        var dmThang = context.DmThangs.Where(thang => thang.Id == dmTuan.Idthang).FirstOrDefault();
                        var listDmTuanTrongThang = context.DmTuans.Where(tuan => tuan.Idthang == dmThang.Id).ToList();
                        int xoaTuan1 = 0;
                        int xoaTuan2 = 0;
                        if (listDmTuanTrongThang.Count == 1)
                        {
                            Console.WriteLine("dmThang id : " + dmThang.Id);
                            Console.WriteLine("listdmtuantrongthang == 1");   
                            var cvThang = context.CvCongViecThangs.Where(cvthang => cvthang.Idthang == dmThang.Id).FirstOrDefault();
                            
                            if(cvThang!=null)
                            {
                                context.CvCongViecThangs.Remove(cvThang);
                                xoaTuan1 = context.SaveChanges();
                                Console.WriteLine("Xoa cv thang thanh cong");
                            }
                            else
                            {
                                context.DmTuans.Remove(dmTuan);
                                context.SaveChanges();

                                context.DmThangs.Remove(dmThang);
                                xoaTuan2 = context.SaveChanges();
                            }
                            Console.WriteLine("xoa tuan 1 :" + xoaTuan1);
                        }
                        if(xoaTuan2 == 0)
                        {
                            context.DmTuans.Remove(dmTuan);
                            context.SaveChanges();
                        }
                        
                        if(xoaTuan1 > 0)
                        {
                            context.DmThangs.Remove(dmThang);
                            context.SaveChanges();
                        }
                            
                    }
                }
                return listIdString;
            }
        }

    }
}