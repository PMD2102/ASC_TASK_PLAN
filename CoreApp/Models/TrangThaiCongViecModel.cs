using System;
namespace CoreApp.Models
{
    public class TrangThaiCongViecModel
    {
        public TrangThaiCongViecModel()
        {
        }


        public TrangThaiCongViecModel(int giaTriTrangThai, string tenTrangThai)
        {
            this.giaTriTrangThai = giaTriTrangThai;
            this.tenTrangThai = tenTrangThai;
        }

        public int giaTriTrangThai { get; set; }

        public string tenTrangThai { get; set; }
    }
}
