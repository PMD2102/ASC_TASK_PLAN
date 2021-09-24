using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApp.Models
{
    [Table("CV_CongViecTuan")]
    public partial class CvCongViecTuan
    {
        public CvCongViecTuan()
        {
            CvGiaoViecs = new HashSet<CvGiaoViec>();
        }

        public CvCongViecTuan(int id, int idcongViecThang, int idtuan, bool isDaDuyet, int idnhanSu, int enumKhoiLuong, int enumTienDo, int enumChatLuong, string nhanXetTuan, DateTime ngayTao, int idnguoiTao, DateTime ngayCapNhat, int idnguoiCapNhat)
        {
            Id = id;
            IdcongViecThang = idcongViecThang;
            Idtuan = idtuan;
            IsDaDuyet = isDaDuyet;
            IdnhanSu = idnhanSu;
            EnumKhoiLuong = enumKhoiLuong;
            EnumTienDo = enumTienDo;
            EnumChatLuong = enumChatLuong;
            NhanXetTuan = nhanXetTuan;
            NgayTao = ngayTao;
            IdnguoiTao = idnguoiTao;
            NgayCapNhat = ngayCapNhat;
            IdnguoiCapNhat = idnguoiCapNhat;
        }

        public CvCongViecTuan(int idcongViecThang, int idtuan, bool isDaDuyet, int idnhanSu, int enumKhoiLuong, int enumTienDo, int enumChatLuong, string nhanXetTuan, DateTime ngayTao, int idnguoiTao, DateTime ngayCapNhat, int idnguoiCapNhat)
        {
            IdcongViecThang = idcongViecThang;
            Idtuan = idtuan;
            IsDaDuyet = isDaDuyet;
            IdnhanSu = idnhanSu;
            EnumKhoiLuong = enumKhoiLuong;
            EnumTienDo = enumTienDo;
            EnumChatLuong = enumChatLuong;
            NhanXetTuan = nhanXetTuan;
            NgayTao = ngayTao;
            IdnguoiTao = idnguoiTao;
            NgayCapNhat = ngayCapNhat;
            IdnguoiCapNhat = idnguoiCapNhat;
        }

        public CvCongViecTuan(int idcongViecThang, int idtuan, bool isDaDuyet, int idnhanSu, int enumKhoiLuong, int enumTienDo, int enumChatLuong, string nhanXetTuan, DateTime ngayTao, int idnguoiTao)
        {
            IdcongViecThang = idcongViecThang;
            Idtuan = idtuan;
            IsDaDuyet = isDaDuyet;
            IdnhanSu = idnhanSu;
            EnumKhoiLuong = enumKhoiLuong;
            EnumTienDo = enumTienDo;
            EnumChatLuong = enumChatLuong;
            NhanXetTuan = nhanXetTuan;
            NgayTao = ngayTao;
            IdnguoiTao = idnguoiTao;
            
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDCongViecThang")]
        public int IdcongViecThang { get; set; }
        [Column("IDTuan")]
        public int Idtuan { get; set; }
        public bool IsDaDuyet { get; set; }
        [Column("IDNhanSu")]
        public int IdnhanSu { get; set; }
        public int EnumKhoiLuong { get; set; }
        public int EnumTienDo { get; set; }
        public int EnumChatLuong { get; set; }
        public string NhanXetTuan { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int? IdnguoiCapNhat { get; set; }

        [ForeignKey(nameof(IdcongViecThang))]
        [InverseProperty(nameof(CvCongViecThang.CvCongViecTuans))]
        public virtual CvCongViecThang IdcongViecThangNavigation { get; set; }
        [ForeignKey(nameof(Idtuan))]
        [InverseProperty(nameof(DmTuan.CvCongViecTuans))]
        public virtual DmTuan IdtuanNavigation { get; set; }
        [InverseProperty(nameof(CvGiaoViec.IdcongViecTuanNavigation))]
        public virtual ICollection<CvGiaoViec> CvGiaoViecs { get; set; }
    }
}
