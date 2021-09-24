using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApp.Models
{
    [Table("ACL_ManHinh")]
    public partial class AclManHinh
    {
        public AclManHinh()
        {
            AclActions = new HashSet<AclAction>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        public string TenManHinh { get; set; }
        [Required]
        public string TenController { get; set; }
        [Required]
        public string TenAction { get; set; }
        public int SoThuTu { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int? IdnguoiCapNhat { get; set; }

        [InverseProperty(nameof(AclAction.IdmanHinhNavigation))]
        public virtual ICollection<AclAction> AclActions { get; set; }
    }
}
