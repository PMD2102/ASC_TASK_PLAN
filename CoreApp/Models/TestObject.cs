using System;
using System.Collections.Generic;

namespace CoreApp.Models
{
    public class TestEntity
    {
        public string Name { get; set; }
    }

    public class TestObject
    {
        public TestObject()
        {
            this.danhSachTuan = new List<eDmTuanModel>();
            this.thongKemOdel = new List<eThongKeModel>();
        }

        public List<eDmTuanModel> danhSachTuan { get; set; }
        public List<eThongKeModel> thongKemOdel { get; set; }
        public int soLuongNhanSu { get; set; }
        public int soLuongTuan { get; set; }
    }
}
