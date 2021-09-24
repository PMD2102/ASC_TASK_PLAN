using System;
using System.Collections.Generic;
using CoreApp.Models;

namespace CoreApp.Service
{
    public interface ICvCongViecThangService
    {
        public List<CvCongViecThang> TimCongViecThang(int id);

        public int ThemCongViecThang(int idThang, int idNhanSu);
    }
}
