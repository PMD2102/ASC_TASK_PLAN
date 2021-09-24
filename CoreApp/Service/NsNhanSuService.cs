using System;
using System.Collections.Generic;
using System.Linq;
using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Service
{
    public class NsNhanSuService : INsNhanSuService
    {
        [HttpPost]
        public List<int> danhSachIdNhanSu(int idThang, int idTuan)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                List<int> listId = new List<int>();
                var danhSachNhanSu = context.NsNhanSus.ToList();
                var danhSachCongViecThang = context.CvCongViecThangs.Where(cvthang => cvthang.Idthang == idThang).ToList();
                var danhSachCongViecTuan = context.CvCongViecTuans.Where(cvTuan => cvTuan.Idtuan == idTuan).ToList();
                //listId = context.NsNhanSus.Select(x => x.Id).ToList();
                var query = (from ns in danhSachNhanSu
                             join cvthang in danhSachCongViecThang on ns.Id equals cvthang.IdnhanSu
                             join cvt in danhSachCongViecTuan on cvthang.Id equals cvt.IdcongViecThang
                             //join cvgv in danhSachCongViecGiao on cvt.Id equals cvgv.IdcongViecTuan
                             where cvt.Idtuan == idTuan
                             select new
                             {
                                 idNhanVien = ns.Id                                 
                             }).ToList();
                query.ForEach(x =>
                {
                    Console.WriteLine("Id nhan viec trong tuan : " + x.idNhanVien);

                });

                danhSachNhanSu.ForEach(x =>
                {
                    query.ForEach(k =>
                    {
                        Console.WriteLine("Id nhan viec trong tuan1 : " + k.idNhanVien);
                        if (x.Id == k.idNhanVien)
                            listId.Add(x.Id);
                    });
                });
                
                return listId;
            }
        }

        public List<NsNhanSu> DanhSachNhanSu()
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var danhSachNhanSu = context.NsNhanSus.ToList();
                return danhSachNhanSu;
            }
        }

        public NsNhanSu TimNhanSu(int id)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var nhanSu = context.NsNhanSus.Where(nhanSu => nhanSu.Id==id).FirstOrDefault();
                return nhanSu;
            }
        }
    }
}
