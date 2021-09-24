using System;
namespace CoreApp.Models
{
    public class eCvGiaoViec
    {
        public eCvGiaoViec()
        {
        }

        public eCvGiaoViec(int id, int idcongViecTuan, int idmodule, int enumNguocGocCongViec, int? idgiaoViecCopiedFrom, string tenIssue, string urlIssue, string tenCongViec, int thoiGianLam, int enumTrangThaiCongViec, DateTime giaoTuNgay, DateTime giaoDenNgay, DateTime ngayHoanThanh, string ghiChu, DateTime ngayTao, int idnguoiTao)
        {
            Id = id;
            IdcongViecTuan = idcongViecTuan;
            Idmodule = idmodule;
            EnumNguocGocCongViec = enumNguocGocCongViec;
            IdgiaoViecCopiedFrom = idgiaoViecCopiedFrom;
            TenIssue = tenIssue;
            UrlIssue = urlIssue;
            TenCongViec = tenCongViec;
            ThoiGianLam = thoiGianLam;
            EnumTrangThaiCongViec = enumTrangThaiCongViec;
            GiaoTuNgay = giaoTuNgay;
            GiaoDenNgay = giaoDenNgay;
            NgayHoanThanh = ngayHoanThanh;
            GhiChu = ghiChu;
            NgayTao = ngayTao;
            IdnguoiTao = idnguoiTao;
        }

        public eCvGiaoViec(int id, int idmodule, int enumNguocGocCongViec, int? idgiaoViecCopiedFrom, string tenIssue, string urlIssue, string tenCongViec, int thoiGianLam, int enumTrangThaiCongViec, DateTime giaoTuNgay, DateTime giaoDenNgay, DateTime ngayHoanThanh, string ghiChu, DateTime ngayTao, int idnguoiTao)
        {
            Id = id;
            Idmodule = idmodule;
            EnumNguocGocCongViec = enumNguocGocCongViec;
            IdgiaoViecCopiedFrom = idgiaoViecCopiedFrom;
            TenIssue = tenIssue;
            UrlIssue = urlIssue;
            TenCongViec = tenCongViec;
            ThoiGianLam = thoiGianLam;
            EnumTrangThaiCongViec = enumTrangThaiCongViec;
            GiaoTuNgay = giaoTuNgay;
            GiaoDenNgay = giaoDenNgay;
            NgayHoanThanh = ngayHoanThanh;
            GhiChu = ghiChu;
            NgayTao = ngayTao;
            IdnguoiTao = idnguoiTao;
        }

        public eCvGiaoViec(int id, int idcongViecTuan, int idmodule, int enumNguocGocCongViec, string tenIssue, string urlIssue, string tenCongViec, int thoiGianLam, int enumTrangThaiCongViec, DateTime giaoTuNgay, DateTime giaoDenNgay, DateTime ngayHoanThanh, string ghiChu, DateTime ngayTao, int idnguoiTao)
        {
            Id = id;
            IdcongViecTuan = idcongViecTuan;
            Idmodule = idmodule;
            EnumNguocGocCongViec = enumNguocGocCongViec;
            TenIssue = tenIssue;
            UrlIssue = urlIssue;
            TenCongViec = tenCongViec;
            ThoiGianLam = thoiGianLam;
            EnumTrangThaiCongViec = enumTrangThaiCongViec;
            GiaoTuNgay = giaoTuNgay;
            GiaoDenNgay = giaoDenNgay;
            NgayHoanThanh = ngayHoanThanh;
            GhiChu = ghiChu;
            NgayTao = ngayTao;
            IdnguoiTao = idnguoiTao;
        }

        public eCvGiaoViec(int id, int idcongViecTuan, int idmodule, int enumNguocGocCongViec, int? idgiaoViecCopiedFrom, string tenIssue, string urlIssue, string tenCongViec, int thoiGianLam, int enumTrangThaiCongViec, DateTime giaoTuNgay, DateTime giaoDenNgay, DateTime ngayHoanThanh, string ghiChu, DateTime ngayTao, int idnguoiTao, DateTime? ngayCapNhat, int? idnguoiCapNhat)
        {
            Id = id;
            IdcongViecTuan = idcongViecTuan;
            Idmodule = idmodule;
            EnumNguocGocCongViec = enumNguocGocCongViec;
            IdgiaoViecCopiedFrom = idgiaoViecCopiedFrom;
            TenIssue = tenIssue;
            UrlIssue = urlIssue;
            TenCongViec = tenCongViec;
            ThoiGianLam = thoiGianLam;
            EnumTrangThaiCongViec = enumTrangThaiCongViec;
            GiaoTuNgay = giaoTuNgay;
            GiaoDenNgay = giaoDenNgay;
            NgayHoanThanh = ngayHoanThanh;
            GhiChu = ghiChu;
            NgayTao = ngayTao;
            IdnguoiTao = idnguoiTao;
            NgayCapNhat = ngayCapNhat;
            IdnguoiCapNhat = idnguoiCapNhat;
        }

        public int Id { get; set; }

        public int IdcongViecTuan { get; set; }

        public int Idmodule { get; set; }

        public int EnumNguocGocCongViec { get; set; }

        public int? IdgiaoViecCopiedFrom { get; set; }

        public string TenIssue { get; set; }

        public string UrlIssue { get; set; }

        public string TenCongViec { get; set; }

        public int ThoiGianLam { get; set; }

        public int EnumTrangThaiCongViec { get; set; }

        public DateTime GiaoTuNgay { get; set; }

        public DateTime GiaoDenNgay { get; set; }

        public DateTime NgayHoanThanh { get; set; }

        public string GhiChu { get; set; }

        public DateTime NgayTao { get; set; }

        public int IdnguoiTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        public int? IdnguoiCapNhat { get; set; }


    }
}
