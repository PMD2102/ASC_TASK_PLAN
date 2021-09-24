using System;
using System.Collections.Generic;
using CoreApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Service
{
    public class ThangService : IDMThangService
    {
        public IDMTuanService _IDMTuanService;

        public ThangService(IDMTuanService IDMTuanService)
        {
            _IDMTuanService = IDMTuanService;
        }

        public bool CapNhatThangTuan(DateTime ngayBatDau, DateTime ngayKetThuc, List<DmTuan> listDmTuan)
        {   
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                List<DmTuan> listDmTuans = new List<DmTuan>();
                int guidIdThang = 0;
                //Dong lan 1
                //Guid guidIdThang = new Guid();
                listDmTuans = listDmTuan;
                bool capNhat = false;
                int thuTuTuan = 1;
                int saved = 0;
                var listThang = context.DmThangs.Where(thang => thang.NgayBatDau.Year == ngayBatDau.Year && thang.NgayBatDau.Month == ngayBatDau.Month).ToList();
                var thang = context.DmThangs.Where(thang => thang.NgayBatDau.Year == ngayBatDau.Year && thang.NgayBatDau.Month == ngayBatDau.Month).FirstOrDefault();
                bool check = true;
                List<DmThang> listThangs = new List<DmThang>();
                
                
                listThang.ForEach(thang => {
                   
                    DmThang thang1 = new DmThang();
                    thang1 = thang;
                    guidIdThang = thang.Id;
                    thang1.NgayBatDau = ngayBatDau;
                    thang1.NgayKetThuc = ngayKetThuc;
                    thang1.NgayCapNhat = DateTime.Now;                   
                    context.DmThangs.Update(thang1);
                    saved += context.SaveChanges();
                    listThangs.Add(thang1);              
                });
                //Kiem tra da ton tai thang do hay chua?
                if(listThangs.Count()>0)
                {
                    capNhat = true;
                }
                //cap nhat du lieu 
                if(capNhat)
                {
                    var listDmTuanCapNhat = context.DmTuans.Where(tuan => tuan.TuNgay.Year == ngayBatDau.Year && tuan.TuNgay.Month == ngayBatDau.Month).OrderBy(tuan => tuan.TenTuan).ToList();
                    //Neu thang da duoc cap nhat thi tiep tuc cap nhat tuan trong thang
                    if(saved > 0)
                    {
                        //truong hop khong them hoac bot tuan
                        if(listDmTuans.Count() == listDmTuanCapNhat.Count())
                        {
                            for(int i=0 ; i<listDmTuans.Count(); i++)
                            {
                                listDmTuanCapNhat[i].TuNgay = listDmTuans[i].TuNgay;
                                listDmTuanCapNhat[i].DenNgay = listDmTuans[i].DenNgay;
                                listDmTuanCapNhat[i].NgayCapNhat = DateTime.Now;
                                listDmTuanCapNhat[i].TenTuan = "Tuần "+thuTuTuan;
                                listDmTuanCapNhat[i].IdnguoiTao = 123;
                                thuTuTuan++;                  
                                context.SaveChanges();
                            }
                        }
                        //truong hop tuan moi cap nhat nhieu hon tuan cu
                        else if(listDmTuans.Count() > listDmTuanCapNhat.Count())
                        {
                            for(int i=0 ; i<listDmTuanCapNhat.Count(); i++)
                            {
                                listDmTuanCapNhat[i].TuNgay = listDmTuans[i].TuNgay;
                                listDmTuanCapNhat[i].DenNgay = listDmTuans[i].DenNgay;
                                listDmTuanCapNhat[i].NgayCapNhat = DateTime.Now;
                                listDmTuanCapNhat[i].TenTuan = "Tuần "+thuTuTuan;
                                listDmTuanCapNhat[i].IdnguoiTao = 123;
                                thuTuTuan++;                                
                                context.SaveChanges();
                                
                            }

                            for(int i = listDmTuanCapNhat.Count(); i < listDmTuans.Count(); i++)
                            {
                                DmTuan dmTuan = new DmTuan();
                                //Sua lan 1
                                //dmTuan.Id = new Guid();
                                dmTuan.Idthang = guidIdThang;
                                dmTuan.NgayTao = DateTime.Now;
                                dmTuan.IdnguoiTao = 123;
                                int tenTuan = i+1;
                                dmTuan.TenTuan = "Tuần "+tenTuan;
                                dmTuan.NgayTao = DateTime.Now;
                                dmTuan.TuNgay = listDmTuans[i].TuNgay;
                                dmTuan.DenNgay = listDmTuans[i].DenNgay;
                                dmTuan.SoGioLam = listDmTuans[i].SoGioLam;
                                dmTuan.SoThuTu = i+1;
                                //context.Database.OpenConnection();
                                //try
                                //{
                                //    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DM_Tuan ON;");
                                    context.DmTuans.Add(dmTuan);
                                    context.SaveChanges();
                                //    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DM_Tuan OFF;");
                                //}
                                //finally
                                //{
                                //    context.Database.CloseConnection();
                                //}
                            }
                        }
                        else
                        {
                            int k = 1;
                            foreach (var tuan in listDmTuanCapNhat)
                            {
                                Console.WriteLine("Gia tri k : "+k);
                                if(k>listDmTuans.Count())
                                {
                                    context.DmTuans.Remove(tuan);
                                    context.SaveChanges();
                                    
                                }
                                k++;
                            }

                            for(int i=0 ; i<listDmTuanCapNhat.Count(); i++)
                            {   
                                listDmTuanCapNhat[i].TuNgay = listDmTuans[i].TuNgay;
                                listDmTuanCapNhat[i].DenNgay = listDmTuans[i].DenNgay;
                                listDmTuanCapNhat[i].NgayCapNhat = DateTime.Now;
                                listDmTuanCapNhat[i].TenTuan = "Tuần "+thuTuTuan;
                                listDmTuanCapNhat[i].IdnguoiTao = 123;
                                listDmTuanCapNhat[i].NgayCapNhat = DateTime.Now;
                                thuTuTuan++;
                                context.SaveChanges();
                            }
                        }
                        capNhat = true;
                    }
                }
                return capNhat;
            }
        }

        public bool checkCVT(DateTime ngayBatDau, DateTime ngayKetThuc, List<DmTuan> listDmTuan)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                //cap nhat lan thu 1 demo
                List<DmTuan> listDmTuans = new List<DmTuan>();
                //Dong lan 1
                //Guid guidIdThang = new Guid();
                listDmTuans = listDmTuan;
                bool check = true;
                var listThang = context.DmThangs.Where(thang => thang.NgayBatDau.Year == ngayBatDau.Year && thang.NgayBatDau.Month == ngayBatDau.Month).ToList();
                var thang = context.DmThangs.Where(thang => thang.NgayBatDau.Year == ngayBatDau.Year && thang.NgayBatDau.Month == ngayBatDau.Month).FirstOrDefault();
                List<CvCongViecTuan> ds = new List<CvCongViecTuan>();
                if (thang != null)
                {
                    var dmTuans = _IDMTuanService.DanhSachTuanTrongThang(thang.Id);
                    if (listDmTuan.Count <= dmTuans.Count)
                    {
                        dmTuans.ForEach(x =>
                        {
                            var dsCVT = context.CvCongViecTuans.Where(cvt => cvt.Idtuan == x.Id).ToList();
                            if (dsCVT.Count > 0)
                                check = false;
                        });
                    }

                }
                if (check == false)
                    return false;
                return true;
            }

        }

        public List<DmThang> DanhSachThangTrongNam(int nam)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var danhSachThang = context.DmThangs.Where(thang => thang.Nam == nam);
                return danhSachThang.ToList();
            }
        }

        public List<DmTuan> DanhSachTuanTrongThang(int nam, int thang1)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var DmThang = context.DmThangs.Where(thang => (thang.GiaTri == thang1 && thang.Nam == nam)).FirstOrDefault();
                var danhSachTuanTrongThang = context.DmTuans.Where(tuan => tuan.Idthang == DmThang.Id).ToList();
                return danhSachTuanTrongThang;
            }
        }

        public List<DmThang> GetDMThangs()
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                List<DmThang> listThang = new List<DmThang>();
                var listThangDb = context.DmThangs.Where(thang => thang.Nam == DateTime.Now.Year);
                listThang = listThangDb.ToList();
                return listThang;
            }
        }

        public bool ThemThang(DateTime ngayBatDau, DateTime ngayKetThuc, List<DmTuan> listDmTuan)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                List<DmTuan> listDmTuans = new List<DmTuan>();
                List<DmThang> listThang = new List<DmThang>();
                int thuTuTuan = 1;
                int guidIdThang = 0;
                //Guid guidIdThang;
                listDmTuans = listDmTuan;
                bool ketQua = true;
                // bool capNhat = false;
                listThang = context.DmThangs.Where(thang => thang.NgayBatDau.Year == ngayBatDau.Year && thang.NgayBatDau.Month == ngayBatDau.Month).ToList();
                List<DmThang> listThangs = new List<DmThang>();
                listThang.ForEach(thang => {
                    DmThang thang1 = new DmThang();
                    thang1 = thang;
                    //dong lan 1
                    //guidIdThang = new Guid(""+thang.Id+"");
                    Console.WriteLine("Ngay bat dau : "+thang.NgayBatDau + " - Ngay ket thuc : " +thang.NgayKetThuc);
                    listThangs.Add(thang1);
                });
                //Kiem tra da ton tai thang do hay chua?
                if(listThangs.Count()>0)
                {
                    ketQua = false;                                  
                }
                              
                int saved = 0;
                //Neu ket qua tra ve la dung thi bat dau them thang va tuan
                if(ketQua)
                {
                    //Luu thang thanh cong
                    DmThang dmThang = new DmThang("Tháng "+ngayBatDau.Month, ngayBatDau.Year, ngayBatDau , ngayKetThuc,ngayBatDau.Month,DateTime.Now,123);
                    context.DmThangs.Add(dmThang);
                    saved += context.SaveChanges();
                    //Neu luu thang thanh cong bat dau luu tuan
                    if(saved>0)
                    {

                        Console.WriteLine("Da vo day");
                        listDmTuans.OrderBy(tuan => tuan.TenTuan).ToList();
                        listDmTuans.ForEach(tuan => {     
                            //Dong lan 1
                            //tuan.Id = new Guid();             
                            tuan.Idthang =dmThang.Id;
                            tuan.NgayTao = DateTime.Now;
                            tuan.IdnguoiTao = 123;
                            tuan.TenTuan = "Tuan "+thuTuTuan;
                            tuan.SoThuTu = thuTuTuan;
                            thuTuTuan++;
                        });
                        //context.Database.OpenConnection();
                        //try
                        //{
                        //    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DM_Tuan ON;");
                            context.DmTuans.AddRange(listDmTuans);
                            context.SaveChanges();
                        //    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DM_Tuan OFF;");
                        //}
                        //finally
                        //{
                        //    context.Database.CloseConnection();
                        //}
                        
                    }
                }        
                return ketQua;
            }
            
        }

        public DmThang TimThang(int nam, int thang1)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var dmThang = context.DmThangs.Where(thang => thang.Nam == nam && thang.GiaTri == thang1).FirstOrDefault();
                return dmThang;
            }
        }

        public void UpdateCongViecThang(eDanhGiaCVThangModel eDanhGiaCVThangModel, int idNhanVien)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                var danhSachCongViecThang = context.CvCongViecThangs.Where(cvthang => cvthang.Idthang == eDanhGiaCVThangModel.idThang && cvthang.IdnhanSu == idNhanVien).ToList();
                danhSachCongViecThang.ForEach(cvthang =>
                {
                    cvthang.NhanXetThang = eDanhGiaCVThangModel.nhanXetThang;
                    cvthang.NgayCapNhat = DateTime.Now;
                    cvthang.EnumChatLuong = eDanhGiaCVThangModel.ChatLuongThangModel.giaTriChatLuongThang;
                    cvthang.EnumKhoiLuong = eDanhGiaCVThangModel.KhoiLuongModel.giaTrikhoiLuong;
                    cvthang.EnumTienDo = eDanhGiaCVThangModel.TienDoModel.giaTriTienDo;
                    context.CvCongViecThangs.Attach(cvthang);
                    context.Entry(cvthang).State = EntityState.Modified;
                    context.SaveChanges();

                });
            }
        }

        public List<string> XoaThang(List<int> listIdDmThang)
        {
            using(var contextDB = new ASC_TASK_PLANNINGContext())
            {
                List<string> listIdErrorThang = new List<string>();
                bool ketQua = true;
                bool checkIdThang = true;
                foreach (var idThang in listIdDmThang)
                {
                    var listDmTuan = contextDB.DmTuans.Where(item => item.Idthang==idThang).ToList();
                    Console.WriteLine("So tuan trong thang = " +listDmTuan.Count());
                    listDmTuan.ForEach( tuan => {
                        if(tuan.IsDaKhoa == true)
                        {
                            Console.WriteLine("Da vo day !!!");
                            checkIdThang = false;
                            ketQua = false;
                            listIdErrorThang.Add(tuan.TenTuan + " - Tháng " + tuan.TuNgay.Month + " - Năm " + tuan.TuNgay.Year + " ");
                        }                    
                    });
                }
                // neu kiem tra dung thi xoa thang va tuan
                if(ketQua && checkIdThang)
                {
                    foreach (var idThang in listIdDmThang)
                    {
                        var danhSachTuanTrongThang = contextDB.DmTuans.Where(tuan => tuan.Idthang == idThang).ToList();
                        List<int> listId = new List<int>();
                        danhSachTuanTrongThang.ForEach(x => listId.Add(x.Id));
                        int saveCVGV = 0;
                        int saveCVT = 0;
                        foreach (var idTuan in listId)
                        {
                            var dmTuan = contextDB.DmTuans.Where(tuan => tuan.Id == idTuan).FirstOrDefault();
                            Console.WriteLine("Dm tuan id : " + dmTuan.Id + " - ten tuan " + dmTuan.TenTuan + " -");
                            var cvCongViecTuan = contextDB.CvCongViecTuans.Where(cvtuan => cvtuan.Idtuan == dmTuan.Id).ToList();
                            cvCongViecTuan.ForEach(cvtuan =>
                            {

                                var cvGiaoViecs = contextDB.CvGiaoViecs.Where(cvgv => cvgv.IdcongViecTuan == cvtuan.Id).ToList();
                                cvGiaoViecs.ForEach(cvgv => {
                                    contextDB.CvGiaoViecs.Remove(cvgv);
                                    saveCVGV = contextDB.SaveChanges();
                                    if (saveCVGV > 0)
                                        Console.WriteLine("Xoa thanh cong cvgv");
                                    else
                                        Console.WriteLine("Xoa khong thanh cong cvgv");
                                });

                            });
                            if (saveCVGV > 0)
                            {
                                cvCongViecTuan.ForEach(x =>
                                {
                                    contextDB.CvCongViecTuans.Remove(x);
                                    saveCVT = contextDB.SaveChanges();
                                    if (saveCVT > 0)
                                        Console.WriteLine("Xoa cong viec tuan thanhf cong");
                                    else
                                        Console.WriteLine("Xoa cvtuan khong thanh cong ");
                                });
                            }

                            var dmThang = contextDB.DmThangs.Where(thang => thang.Id == dmTuan.Idthang).FirstOrDefault();
                            var listDmTuanTrongThang = contextDB.DmTuans.Where(tuan => tuan.Idthang == dmThang.Id).ToList();
                            int xoaTuan1 = 0;
                            int xoaTuan2 = 0;
                            if (listDmTuanTrongThang.Count == 1)
                            {
                                Console.WriteLine("dmThang id : " + dmThang.Id);
                                Console.WriteLine("listdmtuantrongthang == 1");
                                var cvThang = contextDB.CvCongViecThangs.Where(cvthang => cvthang.Idthang == dmThang.Id).FirstOrDefault();

                                if (cvThang != null)
                                {
                                    contextDB.CvCongViecThangs.Remove(cvThang);
                                    xoaTuan1 = contextDB.SaveChanges();
                                    Console.WriteLine("Xoa cv thang thanh cong");
                                }
                                else
                                {
                                    contextDB.DmTuans.Remove(dmTuan);
                                    contextDB.SaveChanges();

                                    contextDB.DmThangs.Remove(dmThang);
                                    xoaTuan2 = contextDB.SaveChanges();
                                }
                                Console.WriteLine("xoa tuan 1 :" + xoaTuan1);
                            }
                            if (xoaTuan2 == 0)
                            {
                                contextDB.DmTuans.Remove(dmTuan);
                                contextDB.SaveChanges();
                            }

                            if (xoaTuan1 > 0)
                            {
                                contextDB.DmThangs.Remove(dmThang);
                                contextDB.SaveChanges();
                            }

                        }
                    }
                }
                return listIdErrorThang;
            }
            
        }
    }
}