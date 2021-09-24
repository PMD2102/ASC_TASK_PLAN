using System;
using System.Collections.Generic;
using CoreApp.Models;

namespace CoreApp.Service
{
    public interface IDMTuanService
    {
        public List<DmTuan> PhatSinhTuanTheoThang(DateTime ngayBatDau, DateTime ngayKetThuc);

        public List<string> XoaTuan(List<int> listIdDmTuan);

        public void KhoaKeHoachTuan(List<int> listIdDmTuan);

        public List<DmTuan> DanhSachTuanTrongThang(int idThang);

        public string NhanXetTuan(int idTuan);

        public void MoKhoaTuan(int idTuan);

        public void CapNhatDanhGiaTuan(eDanhGiaCVTuanModel eDanhGiaCVTuanModel, int idNhanVien);

        public DmTuan GetTuan(int idTuan);
    }
}