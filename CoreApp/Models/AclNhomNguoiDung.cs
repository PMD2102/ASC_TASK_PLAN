using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApp.Models
{
    [Table("ACL_NhomNguoiDung")]
    public partial class AclNhomNguoiDung
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDVaiTro")]
        public int IdvaiTro { get; set; }
        [Column("IDNguoiDung")]
        public int IdnguoiDung { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int? IdnguoiCapNhat { get; set; }

        [ForeignKey(nameof(IdnguoiDung))]
        [InverseProperty(nameof(AclNguoiDung.AclNhomNguoiDungs))]
        public virtual AclNguoiDung IdnguoiDungNavigation { get; set; }
        [ForeignKey(nameof(IdvaiTro))]
        [InverseProperty(nameof(AclVaiTro.AclNhomNguoiDungs))]
        public virtual AclVaiTro IdvaiTroNavigation { get; set; }
    }
}
