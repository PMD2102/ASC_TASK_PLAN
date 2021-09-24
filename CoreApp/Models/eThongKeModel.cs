using System;
namespace CoreApp.Models
{
    public class eThongKeModel
    {
        public eThongKeModel()
        {
        }

        public eThongKeModel(int idTuan, int idNhanVien, int gioTrongTuan, string tenNhanVien, int soGiolam, decimal phanTram)
        {
            this.idTuan = idTuan;
            this.idNhanVien = idNhanVien;
            this.gioTrongTuan = gioTrongTuan;
            this.tenNhanVien = tenNhanVien;
            this.soGioLam = soGioLam;
            this.phanTram = phanTram;
        }

        public eThongKeModel(int idTuan, int idNhanVien, int gioTrongTuan, string tenNhanVien, int soGiolam)
        {
            this.idTuan = idTuan;
            this.tenNhanVien = tenNhanVien;
            this.gioTrongTuan = gioTrongTuan;
            this.soGioLam = soGioLam;
        }

        public eThongKeModel(int idTuan, int idNhanVien, int gioTrongTuan, string tenNhanVien, decimal phanTram)
        {
            this.idTuan = idTuan;
            this.tenNhanVien = tenNhanVien;
            this.gioTrongTuan = gioTrongTuan;
            this.phanTram = phanTram;
        }

        public eThongKeModel(string tenNhanVien, int gioTrongTuan, decimal phanTram)
        {
            this.tenNhanVien = tenNhanVien;
            this.gioTrongTuan = gioTrongTuan;
            this.phanTram = phanTram;
        }

        public eThongKeModel(string tenNhanVien, int gioTrongTuan, int soGioLam, decimal phanTram)
        {
            this.tenNhanVien = tenNhanVien;
            this.gioTrongTuan = gioTrongTuan;
            this.soGioLam = soGioLam;
            this.phanTram = phanTram;
        }

        public eThongKeModel(int idTuan, int idNhanVien, string nhanXetThang, string tenNhanVien, int gioTrongTuan, int soGioLam, decimal phanTram)
        {
            this.idTuan = idTuan;
            this.idNhanVien = idNhanVien;
            this.nhanXetThang = nhanXetThang;
            this.tenNhanVien = tenNhanVien;
            this.gioTrongTuan = gioTrongTuan;
            this.soGioLam = soGioLam;
            this.phanTram = phanTram;
        }

        public int idTuan { get; set; }

        public int idNhanVien { get; set; }

        public string nhanXetThang { get; set; }

        public string tenNhanVien { get; set; }

        public int gioTrongTuan { get; set; }

        public int soGioLam { get; set; }

        public decimal phanTram { get; set; }

        public string Print()
        {
            return "Id " + idTuan +" - Id nhan vien :" +idNhanVien +" - Ten " + tenNhanVien + " - soGio lam" + soGioLam +" - gioTrongTuan : " + gioTrongTuan + " - Nhan xet thang :" +nhanXetThang;
        }

    }
}
