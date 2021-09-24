using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApp.Models
{
    [Table("CV_CongViecThang")]
    public partial class CvCongViecThang
    {
        public CvCongViecThang()
        {
            CvCongViecTuans = new HashSet<CvCongViecTuan>();
        }

        public CvCongViecThang(int Id, int Idthang, int IdnhanSu,int EnumKhoiLuong, int EnumTienDo, int EnumChatLuong, string NhanXetThang, DateTime NgayTao, int IdnguoiTao, DateTime NgayCapNhat, int IdnguoiCapNhat)
        {
            this.Id = Id;
            this.Idthang = Idthang;
            this.IdnhanSu = IdnhanSu;
            this.EnumKhoiLuong = EnumKhoiLuong;
            this.EnumTienDo = EnumTienDo;
            this.EnumChatLuong = EnumChatLuong;
            this.NhanXetThang = NhanXetThang;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
            this.NgayCapNhat = NgayCapNhat;
            this.IdnguoiCapNhat = IdnguoiCapNhat;
        }

        public CvCongViecThang(int Idthang, int IdnhanSu, int EnumKhoiLuong, int EnumTienDo, int EnumChatLuong, string NhanXetThang, DateTime NgayTao, int IdnguoiTao, DateTime NgayCapNhat, int IdnguoiCapNhat)
        {            
            this.Idthang = Idthang;
            this.IdnhanSu = IdnhanSu;
            this.EnumKhoiLuong = EnumKhoiLuong;
            this.EnumTienDo = EnumTienDo;
            this.EnumChatLuong = EnumChatLuong;
            this.NhanXetThang = NhanXetThang;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
            this.NgayCapNhat = NgayCapNhat;
            this.IdnguoiCapNhat = IdnguoiCapNhat;
        }

        public CvCongViecThang(int Idthang, int IdnhanSu, int EnumKhoiLuong, int EnumTienDo, int EnumChatLuong, string NhanXetThang, DateTime NgayTao, int IdnguoiTao, DateTime NgayCapNhat)
        {
            this.Idthang = Idthang;
            this.IdnhanSu = IdnhanSu;
            this.EnumKhoiLuong = EnumKhoiLuong;
            this.EnumTienDo = EnumTienDo;
            this.EnumChatLuong = EnumChatLuong;
            this.NhanXetThang = NhanXetThang;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
            this.NgayCapNhat = NgayCapNhat;
        }

        public CvCongViecThang(int Idthang, int IdnhanSu, int EnumKhoiLuong, int EnumTienDo, int EnumChatLuong, string NhanXetThang, DateTime NgayTao, int IdnguoiTao)
        {
            this.Idthang = Idthang;
            this.IdnhanSu = IdnhanSu;
            this.EnumKhoiLuong = EnumKhoiLuong;
            this.EnumTienDo = EnumTienDo;
            this.EnumChatLuong = EnumChatLuong;
            this.NhanXetThang = NhanXetThang;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDThang")]
        public int Idthang { get; set; }
        [Column("IDNhanSu")]
        public int IdnhanSu { get; set; }
        public int EnumKhoiLuong { get; set; }
        public int EnumTienDo { get; set; }
        public int EnumChatLuong { get; set; }
        public string NhanXetThang { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int? IdnguoiCapNhat { get; set; }

        [ForeignKey(nameof(IdnhanSu))]
        [InverseProperty(nameof(NsNhanSu.CvCongViecThangs))]
        public virtual NsNhanSu IdnhanSuNavigation { get; set; }
        [ForeignKey(nameof(Idthang))]
        [InverseProperty(nameof(DmThang.CvCongViecThangs))]
        public virtual DmThang IdthangNavigation { get; set; }
        [InverseProperty(nameof(CvCongViecTuan.IdcongViecThangNavigation))]
        public virtual ICollection<CvCongViecTuan> CvCongViecTuans { get; set; }
    }
}
