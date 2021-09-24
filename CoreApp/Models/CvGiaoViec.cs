using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApp.Models
{
    [Table("CV_GiaoViec")]
    public partial class CvGiaoViec
    {
        public CvGiaoViec(int id, int idcongViecTuan, int idmodule, int enumNguocGocCongViec, int? idgiaoViecCopiedFrom, string tenIssue, string urlIssue, string tenCongViec, byte thoiGianLam, int enumTrangThaiCongViec, DateTime giaoTuNgay, DateTime giaoDenNgay, DateTime ngayHoanThanh, string ghiChu, DateTime ngayTao, int idnguoiTao, DateTime? ngayCapNhat, int? idnguoiCapNhat)
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

        public CvGiaoViec(int idcongViecTuan, int idmodule, int enumNguocGocCongViec, int? idgiaoViecCopiedFrom, string tenIssue, string urlIssue, string tenCongViec, int thoiGianLam, int enumTrangThaiCongViec, DateTime giaoTuNgay, DateTime giaoDenNgay, DateTime ngayHoanThanh, string ghiChu, DateTime ngayTao, int idnguoiTao, DateTime? ngayCapNhat, int? idnguoiCapNhat)
        {
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

        public CvGiaoViec(int idcongViecTuan, int idmodule, int enumNguocGocCongViec, string tenIssue, string urlIssue, string tenCongViec, int thoiGianLam, int enumTrangThaiCongViec, DateTime giaoTuNgay, DateTime giaoDenNgay, DateTime ngayHoanThanh, string ghiChu, DateTime ngayTao, int idnguoiTao, DateTime? ngayCapNhat, int? idnguoiCapNhat)
        {
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
            NgayCapNhat = ngayCapNhat;
            IdnguoiCapNhat = idnguoiCapNhat;
        }

        public CvGiaoViec(int idcongViecTuan, int idmodule, int enumNguocGocCongViec,  string tenIssue, string urlIssue, string tenCongViec, int thoiGianLam, int enumTrangThaiCongViec, DateTime giaoTuNgay, DateTime giaoDenNgay, DateTime ngayHoanThanh, string ghiChu, DateTime ngayTao, int idnguoiTao)
        {
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

        public CvGiaoViec(int idcongViecTuan, int idmodule, int enumNguocGocCongViec, string tenCongViec, int thoiGianLam, int enumTrangThaiCongViec, DateTime giaoTuNgay, DateTime giaoDenNgay, DateTime ngayHoanThanh, string ghiChu, DateTime ngayTao, int idnguoiTao)
        {
            IdcongViecTuan = idcongViecTuan;
            Idmodule = idmodule;
            EnumNguocGocCongViec = enumNguocGocCongViec;
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

        public CvGiaoViec()
        {
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDCongViecTuan")]
        public int IdcongViecTuan { get; set; }
        [Column("IDModule")]
        public int Idmodule { get; set; }
        public int EnumNguocGocCongViec { get; set; }
        [Column("IDGiaoViecCopiedFrom")]
        public int? IdgiaoViecCopiedFrom { get; set; }
        public string TenIssue { get; set; }
        public string UrlIssue { get; set; }
        [Required]
        public string TenCongViec { get; set; }
        public int ThoiGianLam { get; set; }
        public int EnumTrangThaiCongViec { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime GiaoTuNgay { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime GiaoDenNgay { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayHoanThanh { get; set; }
        public string GhiChu { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int? IdnguoiCapNhat { get; set; }

        [ForeignKey(nameof(IdcongViecTuan))]
        [InverseProperty(nameof(CvCongViecTuan.CvGiaoViecs))]
        public virtual CvCongViecTuan IdcongViecTuanNavigation { get; set; }
        [ForeignKey(nameof(Idmodule))]
        [InverseProperty(nameof(DmModule.CvGiaoViecs))]
        public virtual DmModule IdmoduleNavigation { get; set; }
    }
}
