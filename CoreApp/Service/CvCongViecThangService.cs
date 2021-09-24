using System;
using System.Collections.Generic;
using System.Linq;
using CoreApp.Models;

namespace CoreApp.Service
{
    public class CvCongViecThangService : ICvCongViecThangService
    {
        public int ThemCongViecThang(int idThang, int idNhanSu)
        {
            using(var context = new ASC_TASK_PLANNINGContext())
            {
                int save = 0;
                CvCongViecThang cvCongViecThang = new CvCongViecThang(idThang,idNhanSu,0,0,0,"",DateTime.Now,123);
                context.CvCongViecThangs.Add(cvCongViecThang);
                save = context.SaveChanges();
                if (save > 0)
                    return cvCongViecThang.Id;
                return save;
            }
        }

        public List<CvCongViecThang> TimCongViecThang(int idThang)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var cvCongViecThang = context.CvCongViecThangs.Where(CVCongViecThang => CVCongViecThang.Idthang == idThang).ToList();
                return cvCongViecThang;
            }
        }
    }
}
