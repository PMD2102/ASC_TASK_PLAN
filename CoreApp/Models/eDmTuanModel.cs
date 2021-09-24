using System;
namespace CoreApp.Models
{
    public class eDmTuanModel
    {
        public int Id { get; set; }
        public int Idthang { get; set; }
        public string TenTuan { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public int SoThuTu { get; set; }
        public int SoGioLam { get; set; }
        public bool IsDaKhoa { get; set; }
        public DateTime NgayTao { get; set; }
        public int IdnguoiTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public int? IdnguoiCapNhat { get; set; }
    }
}
