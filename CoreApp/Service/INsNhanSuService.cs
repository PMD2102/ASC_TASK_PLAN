using System;
using System.Collections.Generic;
using CoreApp.Models;

namespace CoreApp.Service
{
    public interface INsNhanSuService
    {
        public List<NsNhanSu> DanhSachNhanSu();

        public NsNhanSu TimNhanSu(int id);

        public List<int> danhSachIdNhanSu(int idThang, int idTuan);


    }
}
