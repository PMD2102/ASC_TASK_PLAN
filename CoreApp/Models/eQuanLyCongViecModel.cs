using System;
using System.ComponentModel.DataAnnotations;

namespace CoreApp.Models
{
    public class eQuanLyCongViecModel
    {
        public eQuanLyCongViecModel()
        {
        }

        public eQuanLyCongViecModel(int idNhanVien, string tenNhanVien, eDmModuleModel eDmModuleModel)
        {
            this.idNhanVien = idNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.eDmModuleModel = eDmModuleModel;
        }

        public eQuanLyCongViecModel(int idNhanVien, string tenNhanVien, string Dev, string urlIssue, string tenCongViec, int thoiGianLam, DateTime tuNgay, DateTime denNgay, int idModule, int mucDoHoanThanh,NguonGocModel NguonGocModel, TrangThaiCongViecModel TrangThaiCongViecModel, eDmModuleModel eDmModuleModel, string ghiChu)
        {
            this.idNhanVien = idNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.Dev = Dev;
            this.urlIssue = urlIssue;
            this.tenCongViec = this.tenCongViec;
            this.thoiGianLam = thoiGianLam;
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
            this.idModule = idModule;
            this.mucDoHoanThanh = mucDoHoanThanh;
            this.NguonGocModel = NguonGocModel;
            this.TrangThaiCongViecModel = TrangThaiCongViecModel;
            this.eDmModuleModel = eDmModuleModel;
            this.ghiChu = ghiChu;
        }

        public eQuanLyCongViecModel(int idNhanVien, string tenNhanVien, int idGiaoViec, string Dev, string urlIssue, string tenCongViec, int thoiGianLam, DateTime tuNgay, DateTime denNgay, int idModule, int mucDoHoanThanh, bool isDaDuyet, bool isDaKhoa,NguonGocModel NguonGocModel, TrangThaiCongViecModel TrangThaiCongViecModel, eDmModuleModel eDmModuleModel, string ghiChu)
        {
            this.idNhanVien = idNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.idGiaoViec = idGiaoViec;
            this.Dev = Dev;
            this.urlIssue = urlIssue;
            this.tenCongViec = this.tenCongViec;
            this.thoiGianLam = thoiGianLam;
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
            this.idModule = idModule;
            this.mucDoHoanThanh = mucDoHoanThanh;
            this.isDaDuyet = isDaDuyet;
            this.isDaKhoa = isDaKhoa;
            this.NguonGocModel = NguonGocModel;
            this.TrangThaiCongViecModel = TrangThaiCongViecModel;
            this.eDmModuleModel = eDmModuleModel;
            this.ghiChu = ghiChu;
        }

        public eQuanLyCongViecModel(int idNhanVien, string tenNhanVien, int idGiaoViec, string dev, string urlIssue, string tenCongViec, int thoiGianLam, DateTime tuNgay, DateTime denNgay, int giaTriENumNguonGoc, int giaTriEnumTrangThai, int idModule, int mucDoHoanThanh, bool isDaDuyet, bool isDaKhoa, NguonGocModel nguonGocModel, TrangThaiCongViecModel trangThaiCongViecModel, eDmModuleModel eDmModuleModel, string ghiChu)
        {
            this.idNhanVien = idNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.idGiaoViec = idGiaoViec;
            this.Dev = dev;
            this.urlIssue = urlIssue;
            this.tenCongViec = tenCongViec;
            this.thoiGianLam = thoiGianLam;
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
            this.giaTriENumNguonGoc = giaTriENumNguonGoc;
            this.giaTriEnumTrangThai = giaTriEnumTrangThai;
            this.idModule = idModule;
            this.mucDoHoanThanh = mucDoHoanThanh;
            this.isDaDuyet = isDaDuyet;
            this.isDaKhoa = isDaKhoa;
            this.NguonGocModel = nguonGocModel;
            this.TrangThaiCongViecModel = trangThaiCongViecModel;
            this.eDmModuleModel = eDmModuleModel;
            this.ghiChu = ghiChu;
        }

        public int idNhanVien { get; set; }

        public string tenNhanVien { get; set; }

        public int idGiaoViec { get; set; }

        public string Dev { get; set; }

        [Required]
        public string urlIssue { get; set; }

        [Required]
        public string tenCongViec { get; set; }

        [Required]
        [Range(1, 9, ErrorMessage = "Thời gian ít nhất = 1 và nhiều nhất = 9")]
        public int thoiGianLam { get; set; }

        [Required]
        public DateTime tuNgay { get; set; }

        [Required]
        public DateTime denNgay { get; set; }

        public int giaTriENumNguonGoc { get; set; }

        public int giaTriEnumTrangThai { get; set; }

        public int idModule { get; set; }

        public int mucDoHoanThanh { get; set; }

        public bool isDaDuyet { get; set; }

        public bool isDaKhoa { get; set;}

        [UIHint("clientNguonGocModel")]
        public NguonGocModel NguonGocModel { get; set; }

        [UIHint("clientTrangThaiCongViecModel")]
        public TrangThaiCongViecModel TrangThaiCongViecModel { get; set; }

        [UIHint("clientModule")]

        public eDmModuleModel eDmModuleModel { get; set; }

        [Required]
        public string ghiChu { get; set; }
    }
}
