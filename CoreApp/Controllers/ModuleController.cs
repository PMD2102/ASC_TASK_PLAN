using System;
using CoreApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class ModuleController : Controller
    {
        public IDmModuleService _IDmModuleService; 

        public ModuleController(IDmModuleService IDmModuleService)
        {
            _IDmModuleService = IDmModuleService;
        }

        public JsonResult GetDanhSachModule()
        {
            return Json(_IDmModuleService.GetDanhSachModule());
        }
    }
}
