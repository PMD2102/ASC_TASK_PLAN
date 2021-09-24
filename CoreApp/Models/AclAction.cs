using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApp.Models
{
    [Table("ACL_Action")]
    public partial class AclAction
    {
        public AclAction()
        {
            AclPhanQuyens = new HashSet<AclPhanQuyen>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDManHinh")]
        public int IdmanHinh { get; set; }
        [Required]
        public string TenChucNang { get; set; }
        [Required]
        public string TenController { get; set; }
        [Required]
        public string TenAction { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int? IdnguoiCapNhat { get; set; }

        [ForeignKey(nameof(IdmanHinh))]
        [InverseProperty(nameof(AclManHinh.AclActions))]
        public virtual AclManHinh IdmanHinhNavigation { get; set; }
        [InverseProperty(nameof(AclPhanQuyen.IdactionNavigation))]
        public virtual ICollection<AclPhanQuyen> AclPhanQuyens { get; set; }
    }
}
