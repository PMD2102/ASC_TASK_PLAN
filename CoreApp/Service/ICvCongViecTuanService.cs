using System;
using System.Collections.Generic;
using CoreApp.Models;

namespace CoreApp.Service
{
    public interface ICvCongViecTuanService
    {
        public List<CvCongViecTuan> DanhSachCongViecTuan(int idCongViecThang);

        public int ThemCongViecTuan(int idCongViecThang, int idTuan);

        public string DuyetTuan(List<string> listId, int idThang, int idTuan);

        public CvCongViecTuan KiemTraCongViecTuan(int idTuan, int idNhanVien);
    }
}
