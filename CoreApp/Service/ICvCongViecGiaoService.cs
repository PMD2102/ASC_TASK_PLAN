using System;
using System.Collections.Generic;
using CoreApp.Models;

namespace CoreApp.Service
{
    public interface ICvCongViecGiaoService
    {
        public List<CvGiaoViec> DanhSachGiaoViec(int idCongViecTuan);

        public bool ThemCongViecGiao(int idCongViecTuan, int idModule, string tenCongViec, int thoiGianLam, DateTime giaoDenngay, DateTime ngayHoanThanh, string urlIssusse, string tenIssusse);

        public List<string> DanhSachTenCongviec();

        public List<eQuanLyCongViecModel> DanhSachQuanLyTheoThangVaTuan(int idThang, int idTuan);

        public List<eQuanLyCongViecModel> DanhSachTimKiem(string tenCongViecIndex, int dropdownlistThangTrongNamIndex, int dropdownlistTuanIndex, int dropdownlistModuleIndex, int dropdownlistNhanSuIndex, int dropdownlistLamViecIndex);

        public string XoaCongViecGiao(List<int> idCongViecGiao, int idTuan);

        public bool KiemTraTenCongViec(string tenCongViec);

        public void Update(eQuanLyCongViecModel eQuanLyCongViecModel);

        public List<eDanhGiaCVThangModel> DanhGiaCongViecThang(int idThang, int idNhanSu, int idTuan);

        public void UpdateMotCongViec(int dropdownlistNhanSu, int dropdownlistThangTrongNam, int dropdownlistTuan, string urlIssusse, string tenIssusse, int dropdownlistModule, string tenCongViec, int thoiGianLam, int dropdownlistLamViec, DateTime tuNgay, DateTime denNgay, string ghiChu, int idCongViecCapNhat);

        public List<eDanhGiaCVTuanModel> DanhGiaCongViecTuan(int idThang, int idNhanSu);

        public bool KiemTraSoLanDoiCongViec(int idGiaoViec);
    }
}
