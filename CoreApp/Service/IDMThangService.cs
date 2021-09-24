using System;
using System.Collections.Generic;
using CoreApp.Models;

namespace CoreApp.Service
{
    public interface IDMThangService
    {
        public List<DmThang> GetDMThangs();

        public bool ThemThang(DateTime ngayBatDau, DateTime ngayKetThuc, List<DmTuan> listDmTuan);

        public bool CapNhatThangTuan(DateTime ngayBatDau, DateTime ngayKetThuc, List<DmTuan> listDmTuan);

        public List<string> XoaThang(List<int> listIdDmThang);

        public List<DmThang> DanhSachThangTrongNam(int nam);

        public List<DmTuan> DanhSachTuanTrongThang(int nam, int thang);

        public DmThang TimThang(int nam, int thang);

        public void UpdateCongViecThang(eDanhGiaCVThangModel eDanhGiaCVThangModel, int idNhanVien);

        public bool checkCVT(DateTime ngayBatDau, DateTime ngayKetThuc, List<DmTuan> listDmTuan);
    }
}