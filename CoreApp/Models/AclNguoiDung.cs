using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApp.Models
{
    [Table("ACL_NguoiDung")]
    public partial class AclNguoiDung
    {
        public AclNguoiDung()
        {
            AclNhomNguoiDungs = new HashSet<AclNhomNguoiDung>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDNhanSu")]
        public int IdnhanSu { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsAdmin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [Column("IDNguoiTao")]
        public int IdnguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        [Column("IDNguoiCapNhat")]
        public int? IdnguoiCapNhat { get; set; }

        [ForeignKey(nameof(IdnhanSu))]
        [InverseProperty(nameof(NsNhanSu.AclNguoiDungs))]
        public virtual NsNhanSu IdnhanSuNavigation { get; set; }
        [InverseProperty(nameof(AclNhomNguoiDung.IdnguoiDungNavigation))]
        public virtual ICollection<AclNhomNguoiDung> AclNhomNguoiDungs { get; set; }
    }
}
