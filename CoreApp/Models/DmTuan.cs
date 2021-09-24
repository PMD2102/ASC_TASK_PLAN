using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
#nullable disable

namespace CoreApp.Models
{
    [Table("DM_Tuan")]
    public partial class DmTuan
    {
        public DmTuan()
        {
            CvCongViecTuans = new HashSet<CvCongViecTuan>();
        }

        public DmTuan(int Id)
        {
            this.Id = Id;
        }

        public DmTuan(int Id, int Idthang, string TenTuan, int SoThuTu, DateTime TuNgay, DateTime DenNgay, int SoGioLam, bool IsDaKhoa, DateTime NgayTao, int IdnguoiTao)
        {
            this.Id = Id;
            this.Idthang = Idthang;
            this.TenTuan = TenTuan;
            this.SoThuTu = SoThuTu;
            this.TuNgay = TuNgay;
            this.DenNgay = DenNgay;
            this.SoGioLam = SoGioLam;
            this.IsDaKhoa = IsDaKhoa;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
        }

        public DmTuan(int Idthang, string TenTuan, int SoThuTu, DateTime TuNgay, DateTime DenNgay, int SoGioLam, bool IsDaKhoa, DateTime NgayTao, int IdnguoiTao)
        {
            this.Idthang = Idthang;
            this.TenTuan = TenTuan;
            this.SoThuTu = SoThuTu;
            this.TuNgay = TuNgay;
            this.DenNgay = DenNgay;
            this.SoGioLam = SoGioLam;
            this.IsDaKhoa = IsDaKhoa;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
        }

        public DmTuan(int Id, int Idthang, string TenTuan, int SoThuTu, DateTime TuNgay, DateTime DenNgay, int SoGioLam, bool IsDaKhoa, DateTime NgayCapNhat, DateTime NgayTao, int IdnguoiTao)
        {
            this.Id = Id;
            this.Idthang = Idthang;
            this.TenTuan = TenTuan;
            this.SoThuTu = SoThuTu;
            this.TuNgay = TuNgay;
            this.DenNgay = DenNgay;
            this.SoGioLam = SoGioLam;
            this.NgayCapNhat = NgayCapNhat;
            this.IsDaKhoa = IsDaKhoa;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
        }

        

        

        public DmTuan(int Idthang, string TenTuan, int SoThuTu, DateTime TuNgay, DateTime DenNgay, int SoGioLam, bool IsDaKhoa, DateTime NgayCapNhat, DateTime NgayTao, int IdnguoiTao)
        {
            this.Idthang = Idthang;
            this.TenTuan = TenTuan;
            this.SoThuTu = SoThuTu;
            this.TuNgay = TuNgay;
            this.DenNgay = DenNgay;
            this.SoGioLam = SoGioLam;
            this.IsDaKhoa = IsDaKhoa;
            this.NgayCapNhat = NgayCapNhat;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
        }

        public DmTuan(int Idthang, string TenTuan, DateTime TuNgay, DateTime DenNgay, int SoGioLam, bool IsDaKhoa, DateTime NgayCapNhat, DateTime NgayTao, int IdnguoiTao)
        {
            this.Idthang = Idthang;
            this.TenTuan = TenTuan;
            this.TuNgay = TuNgay;
            this.DenNgay = DenNgay;
            this.SoGioLam = SoGioLam;
            this.IsDaKhoa = IsDaKhoa;
            this.NgayCapNhat = NgayCapNhat;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
        }

        public DmTuan(string TenTuan, int SoThuTu, DateTime TuNgay, DateTime DenNgay, int SoGioLam, bool IsDaKhoa)
        {
            this.TenTuan = TenTuan;
            this.SoThuTu = SoThuTu;
            this.TuNgay = TuNgay;
            this.DenNgay = DenNgay;
            this.SoGioLam = SoGioLam;
            this.IsDaKhoa = IsDaKhoa;
        }

        public DmTuan(DateTime TuNgay, DateTime DenNgay)
        {
            this.TuNgay = TuNgay;
            this.DenNgay = DenNgay;
        }

        public string Print()
        {
            return "Id " + Id + " Id Thang :" + " - " + Idthang + "Ten tuan : " + TenTuan + " - " + "So Thu tu : " + SoThuTu + " - " + "TU ngay : " + TuNgay + " - " + "Den Ngay : " + DenNgay + " - " + "So gio lam : " + SoGioLam;
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDThang")]
        public int Idthang { get; set; }
        [Required]
        public string TenTuan { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TuNgay { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DenNgay { get; set; }
        public int SoThuTu { get; set; }
        public int SoGioLam { get; set; }
        public bool IsDaKhoa { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int? IdnguoiCapNhat { get; set; }

        [ForeignKey(nameof(Idthang))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [InverseProperty(nameof(DmThang.DmTuans))]
        public virtual DmThang IdthangNavigation { get; set; }
        [InverseProperty(nameof(CvCongViecTuan.IdtuanNavigation))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual ICollection<CvCongViecTuan> CvCongViecTuans { get; set; }
    }
}
