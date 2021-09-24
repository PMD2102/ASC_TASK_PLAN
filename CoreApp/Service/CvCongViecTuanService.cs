using System;
using System.Collections.Generic;
using System.Linq;
using CoreApp.Models;

namespace CoreApp.Service
{
    public class CvCongViecTuanService : ICvCongViecTuanService
    {
        public List<CvCongViecTuan> DanhSachCongViecTuan(int idCongViecThang)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var danhSachCongViecTuan = context.CvCongViecTuans.Where(cvTuan => cvTuan.IdcongViecThang == idCongViecThang).ToList();
                return danhSachCongViecTuan;
            }

        }

        public string DuyetTuan(List<string> chkArray1, int idThang,int idTuan)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                bool check = true;
                string message = "";
                string tenNhanVien1 = "";
                var danhSachNhanSu = context.NsNhanSus.ToList();
                var danhSachCongViecTuan = context.CvCongViecTuans.Where(cvTuan => cvTuan.Idtuan == idTuan).ToList();
                var danhSachCongViecThang = context.CvCongViecThangs.Where(cvThang => cvThang.Idthang == idThang).ToList();
                List<CvCongViecTuan> danhSachCongViecTuan1 = new List<CvCongViecTuan>();
                chkArray1.ForEach(x =>
                {
                    int idNV = Convert.ToInt32(x);
                    var query = (from ns in danhSachNhanSu
                                 join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                                 join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                                 //join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                                 where cvt.Idtuan == idTuan && ns.Id == idNV
                                 select new
                                 {
                                     idCVTuan = cvt.Id,
                                     Ten = ns.Ten
                                 }).ToList();
                    query.ForEach(x =>
                    {
                        CvCongViecTuan cvCongViecTuan = new CvCongViecTuan();
                        string tenNhanVien = x.Ten +" - ";
                        cvCongViecTuan = context.CvCongViecTuans.Where(cvTuan => cvTuan.Id == x.idCVTuan).FirstOrDefault();
                        if (cvCongViecTuan.IsDaDuyet == true)
                            tenNhanVien1 += tenNhanVien;
                        danhSachCongViecTuan1.Add(cvCongViecTuan);
                    });
                    if(danhSachCongViecTuan1.Where(cvTuan => cvTuan.IsDaDuyet == true).ToList().Count == 0)
                    {

                        danhSachCongViecTuan1.ForEach(cvTuan1 =>
                        {
                            int save = 0;
                            cvTuan1.IsDaDuyet = true;
                            context.CvCongViecTuans.Update(cvTuan1);
                            save = context.SaveChanges();
                            if (save > 0)
                                Console.WriteLine("Cap nhat thanh cong ");
                            else
                                Console.WriteLine("Cap nhat that bai");
                        });                          
                    }
                    else
                    {
                        message = tenNhanVien1 + " đã duyệt trong tuần";
                    }

                });
                return message;
            }
        }

        public CvCongViecTuan KiemTraCongViecTuan(int idTuan, int idNhanVien)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                var danhSachNhanSu = context.NsNhanSus.ToList();
                var danhSachCongViecThang = context.CvCongViecThangs.ToList();
                var danhSachCongViecTuan = context.CvCongViecTuans.ToList();

                var query = (from ns in danhSachNhanSu
                             join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                             join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                             where cvt.Idtuan == idTuan && ns.Id == idNhanVien
                             select new 
                             {
                                 Id = cvt.Id
                             }).ToList();
                if(query.Count!=0)
                {
                    CvCongViecTuan cvCongViecTuan = new CvCongViecTuan();
                    cvCongViecTuan = context.CvCongViecTuans.Where(cvtuan => cvtuan.Id == query[0].Id).FirstOrDefault();
                    return cvCongViecTuan;
                }
                else
                {
                    CvCongViecTuan cvCongViecTuan = new CvCongViecTuan();
                    cvCongViecTuan.Id = -1;
                    return cvCongViecTuan;
                }
            }
        }

        public int ThemCongViecTuan(int idCongViecThang, int idTuan)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                int save = 0;
                CvCongViecTuan cvCongViecTuan = new CvCongViecTuan(idCongViecThang, idTuan, false, 123, 0, 0, 0,"", DateTime.Now, 123);
                context.CvCongViecTuans.Add(cvCongViecTuan);
                save = context.SaveChanges();
                if (save > 0)
                    return cvCongViecTuan.Id;
                return save;
            }

        }
    }
}
