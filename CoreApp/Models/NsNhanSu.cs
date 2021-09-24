using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApp.Models
{
    [Table("NS_NhanSu")]
    public partial class NsNhanSu
    {
        public NsNhanSu()
        {
            AclNguoiDungs = new HashSet<AclNguoiDung>();
            CvCongViecThangs = new HashSet<CvCongViecThang>();
        }

        public NsNhanSu(string Ten, int Id)
        {
            this.Ten = Ten;
            this.Id = Id;
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int MaNhanSu { get; set; }
        [Required]
        public string HoDem { get; set; }
        [Required]
        public string Ten { get; set; }
        [Required]
        public string GioiTinh { get; set; }
        public int NamSinh { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int? IdnguoiCapNhat { get; set; }

        [InverseProperty(nameof(AclNguoiDung.IdnhanSuNavigation))]
        public virtual ICollection<AclNguoiDung> AclNguoiDungs { get; set; }
        [InverseProperty(nameof(CvCongViecThang.IdnhanSuNavigation))]
        public virtual ICollection<CvCongViecThang> CvCongViecThangs { get; set; }
    }
}
