using System;
namespace CoreApp.Models
{
    public class KhoiLuongModel
    {
        public KhoiLuongModel()
        {

        }

        public KhoiLuongModel(int giaTrikhoiLuong, string tenKhoiLuong)
        {
            this.giaTrikhoiLuong = giaTrikhoiLuong;
            this.tenKhoiLuong = tenKhoiLuong;
        }

        public int giaTrikhoiLuong { get; set; }

        public string tenKhoiLuong { get; set; }

    }
}
