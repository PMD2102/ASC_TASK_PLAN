using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApp.Models
{
    [Table("ACL_PhanQuyen")]
    public partial class AclPhanQuyen
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDVaiTro")]
        public int IdvaiTro { get; set; }
        [Column("IDAction")]
        public int Idaction { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int? IdnguoiCapNhat { get; set; }

        [ForeignKey(nameof(Idaction))]
        [InverseProperty(nameof(AclAction.AclPhanQuyens))]
        public virtual AclAction IdactionNavigation { get; set; }
        [ForeignKey(nameof(IdvaiTro))]
        [InverseProperty(nameof(AclVaiTro.AclPhanQuyens))]
        public virtual AclVaiTro IdvaiTroNavigation { get; set; }
    }
}
