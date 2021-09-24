using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApp.Models
{
    [Table("ACL_VaiTro")]
    public partial class AclVaiTro
    {
        public AclVaiTro()
        {
            AclNhomNguoiDungs = new HashSet<AclNhomNguoiDung>();
            AclPhanQuyens = new HashSet<AclPhanQuyen>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        public string TenVaiTro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int? IdnguoiCapNhat { get; set; }

        [InverseProperty(nameof(AclNhomNguoiDung.IdvaiTroNavigation))]
        public virtual ICollection<AclNhomNguoiDung> AclNhomNguoiDungs { get; set; }
        [InverseProperty(nameof(AclPhanQuyen.IdvaiTroNavigation))]
        public virtual ICollection<AclPhanQuyen> AclPhanQuyens { get; set; }
    }
}
