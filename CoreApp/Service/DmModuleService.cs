using System;
using System.Collections.Generic;
using System.Linq;
using CoreApp.Models;

namespace CoreApp.Service
{
    public class DmModuleService : IDmModuleService
    {
       
        public List<DmModule> GetDanhSachModule()
        {
           using(var context = new ASC_TASK_PLANNINGContext())
           {
                var danhSachModule = context.DmModules.ToList();
                return danhSachModule;
           }
        }

        public DmModule TimModuleTheoId(int idModule)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                DmModule dmModule = context.DmModules.Where(module => module.Id == idModule).FirstOrDefault();
                return dmModule;
            }
                
        }
    }
}
