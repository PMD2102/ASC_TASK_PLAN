using System;
using System.Collections.Generic;
using CoreApp.Models;

namespace CoreApp.Service
{
    public interface IDmModuleService
    {
        public List<DmModule> GetDanhSachModule();

        public DmModule TimModuleTheoId(int idModule);
    }
}
