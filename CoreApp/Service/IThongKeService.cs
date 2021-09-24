using System;
using System.Collections.Generic;
using CoreApp.Models;

namespace CoreApp.Service
{
    public interface IThongKeService
    {
        public List<eThongKeModel> DanhSachThongKeTheoThang(List<CvCongViecThang> danhSachCongViecThang, List<DmTuan> danhSachTuanTrongThang, List<NsNhanSu> danhSachNhanSu, DmThang dmThang);
    
        public List<Nam> DanhSachNamThongKe();


    }
}
