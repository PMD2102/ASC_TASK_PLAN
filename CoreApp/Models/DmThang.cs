using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApp.Models
{
    [Table("DM_Thang")]
    public partial class DmThang
    {
        public DmThang()
        {
            CvCongViecThangs = new HashSet<CvCongViecThang>();
            DmTuans = new HashSet<DmTuan>();
        }

        public DmThang(int Id, string TenThang, int Nam, DateTime NgayBatDau, DateTime NgayKetThuc, int GiaTri, DateTime NgayTao, int IdnguoiTao, DateTime NgayCapNhat, int IdnguoiCapNhat)
        {
            this.Id = Id;
            this.TenThang = TenThang;
            this.Nam = Nam;
            this.NgayBatDau = NgayBatDau;
            this.NgayKetThuc = NgayKetThuc;
            this.GiaTri = GiaTri;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
            this.NgayCapNhat = NgayCapNhat;
            this.IdnguoiCapNhat = IdnguoiCapNhat;
        }

        public DmThang(string TenThang, int Nam, DateTime NgayBatDau, DateTime NgayKetThuc, int GiaTri, DateTime NgayTao, int IdnguoiTao, DateTime NgayCapNhat, int IdnguoiCapNhat)
        {
            this.TenThang = TenThang;
            this.Nam = Nam;
            this.NgayBatDau = NgayBatDau;
            this.NgayKetThuc = NgayKetThuc;
            this.GiaTri = GiaTri;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
            this.NgayCapNhat = NgayCapNhat;
            this.IdnguoiCapNhat = IdnguoiCapNhat;
        }

        public DmThang(string TenThang, int GiaTri)
        {
            this.TenThang = TenThang;
            this.GiaTri = GiaTri;
        }

        public DmThang(int Nam, int GiaTri)
        {
            this.Nam = Nam;
            this.GiaTri = GiaTri;
        }

        public DmThang(int Nam)
        {
            this.Nam = Nam;
        }

        public DmThang(int Id, string TenThang, int Nam, DateTime NgayBatDau, DateTime NgayKetThuc, int GiaTri, DateTime NgayTao, int IdnguoiTao)
        {
            this.Id = Id;
            this.TenThang = TenThang;
            this.Nam = Nam;
            this.NgayBatDau = NgayBatDau;
            this.NgayKetThuc = NgayKetThuc;
            this.GiaTri = GiaTri;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
            
        }

        public DmThang(string TenThang, int Nam, DateTime NgayBatDau, DateTime NgayKetThuc, int GiaTri, DateTime NgayTao, int IdnguoiTao)
        {
            this.TenThang = TenThang;
            this.Nam = Nam;
            this.NgayBatDau = NgayBatDau;
            this.NgayKetThuc = NgayKetThuc;
            this.GiaTri = GiaTri;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;

        }

        

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        public string TenThang { get; set; }
        public int Nam { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayBatDau { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayKetThuc { get; set; }
        public int GiaTri { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int? IdnguoiCapNhat { get; set; }

        [InverseProperty(nameof(CvCongViecThang.IdthangNavigation))]
        public virtual ICollection<CvCongViecThang> CvCongViecThangs { get; set; }
        [InverseProperty(nameof(DmTuan.IdthangNavigation))]
        public virtual ICollection<DmTuan> DmTuans { get; set; }
    }
}
