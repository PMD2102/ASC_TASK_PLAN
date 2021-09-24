using System;
namespace CoreApp.Models
{
    public class EnumQuanLy
    {
        public enum TrangThai
        {
            daXong = 0,
            chuaLam = 1,
            daXongTaskDotXuat = 2,
            chuaXong = 3,
            chuaXongBanTaskKhacChuaDuyet = 4,
            chuaXongBanTaskKhacDaDuyet = 5,
            vang = 6
        }

        public enum KhoiLuong
        {
            binhThuong = 0,
            nhieu = 1,
            thap = 2,
        }

        public enum TienDo
        {
            kipTienDo = 0,
            somHon = 1,
            treTienDo = 2,

        }

        public enum ChatLuongNhanSu
        {
            loiNoiBo2 = 0,
            loiNoiBo34 = 1,
            loiNoiBoKH = 2,
            loiNghiemTrongKH = 3
        }

        public enum ChatLuongKhachHang
        {
            totKhongLoi = 0,
            khaVaiLoi = 1,
            trungBinhVaiLoi = 2,
            yeuNhieuLoi = 3
        }

        public enum NguonGoc
        {
            taoMoi = 0,
            doiDoTre2Lan = 1,
            doiDoTre3Lan = 2
        }
    }
}
