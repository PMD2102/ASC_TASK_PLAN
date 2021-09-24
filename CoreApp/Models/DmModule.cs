using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApp.Models
{
    [Table("DM_Module")]
    public partial class DmModule
    {
        public DmModule()
        {
            CvGiaoViecs = new HashSet<CvGiaoViec>();
        }

        public DmModule(int Id, string TenModule)
        {
            this.Id = Id;
            this.TenModule = TenModule;
        }

        public DmModule(int Id, string TenModule, int SoThuTu, string GhiChu, DateTime NgayTao, int IdnguoiTao, DateTime NgayCapNhat, int IdnguoiCapNhat)
        {
            this.Id = Id;
            this.TenModule = TenModule;
            this.SoThuTu = SoThuTu;
            this.GhiChu = GhiChu;
            this.NgayTao = NgayTao;
            this.IdnguoiTao = IdnguoiTao;
            this.NgayCapNhat = NgayCapNhat;
            this.IdnguoiCapNhat = IdnguoiCapNhat;
        }   

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        public string TenModule { get; set; }
        public int SoThuTu { get; set; }
        [Required]
        public string GhiChu { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int IdnguoiCapNhat { get; set; }

        [InverseProperty(nameof(CvGiaoViec.IdmoduleNavigation))]
        public virtual ICollection<CvGiaoViec> CvGiaoViecs { get; set; }
    }
}
